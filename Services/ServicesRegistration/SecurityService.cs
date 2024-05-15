using System.Security.Claims;
using System.Text;
using Azure.Security.KeyVault.Secrets;
using CSharp_FinalExam.Data;
using CSharp_FinalExam.Infrastructure.Policies.Admin;
using CSharp_FinalExam.Models.Authentication;
using CSharp_FinalExam.Models.Identity;
using CSharp_FinalExam.Utilities.TypeSafe;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace CSharp_FinalExam.Services.ServicesRegistration;

public static class SecurityService
{
    public static IdentityBuilder AddApplicationIdentity(this IServiceCollection service)
    {
        return service.AddDefaultIdentity<ApplicationIdentityUser>(options =>
            {
                // Sign in settings
                options.SignIn.RequireConfirmedAccount = false;

                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(60);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            }).AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
    }

    public static IServiceCollection AddApplicationJwtAuthentication(this IServiceCollection service,
        JwtConfiguration jwtConfig, SecretClient secretClient)
    {
        service.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddGoogle(options =>
            {
                options.ClientId = secretClient.GetSecret("GoogleClientId").Value.Value;
                options.ClientSecret = secretClient.GetSecret("GoogleClientSecret").Value.Value;
                options.SaveTokens = true;
                options.Scope.Add("https://www.googleapis.com/auth/userinfo.profile");

                options.Events = new OAuthEvents()
                {
                    OnRedirectToAuthorizationEndpoint = context =>
                    {
                        context.Response.Redirect(context.RedirectUri + "&prompt=select_account");
                        return Task.CompletedTask;
                    },
                    OnCreatingTicket = context =>
                    {
                        context.Identity.AddClaim(new Claim("user_image", context.User.GetProperty("picture").ToString()));
                        context.Identity.AddClaim(new Claim("access_token", context.AccessToken));
                        return Task.CompletedTask;
                    }
                };
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateActor = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfig.Issuer,
                    ValidAudience = jwtConfig.Audience,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Secret))
                };

                options.Events = new JwtBearerEvents()
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies[TypeSafe.CookiesName.Token];
                        return Task.CompletedTask;
                    }
                };
            });

        return service;
    }

    public static IServiceCollection AddApplicationAuthorization(this IServiceCollection service)
    {
        // service.AddSingleton<IAuthorizationHandler, AdminRequirementHandler>();
        //
        // service.AddAuthorization(options =>
        // {
        //     options.AddPolicy(TypeSafe.Policies.AdminRequirement, 
        //         policy => policy.Requirements.Add(new AdminRequirements())
        //         );
        // });

        return service;
    }
}