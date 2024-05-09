using CSharp_FinalExam.Data;
using CSharp_FinalExam.Models.Identity;
using Microsoft.AspNetCore.Identity;

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
}