using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CSharp_FinalExam.Data;
using CSharp_FinalExam.DTOs.IdentityDTOs;
using CSharp_FinalExam.Models.Authentication;
using CSharp_FinalExam.Models.Identity;
using CSharp_FinalExam.Utilities.TypeSafe;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace CSharp_FinalExam.Services.AuthenticationService;

public class AuthenticationService : IAuthenticationService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationIdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<ApplicationIdentityUser> _signInManager;
    private readonly IHttpContextAccessor _httpContext;

    public AuthenticationService(
        ApplicationDbContext context,
        UserManager<ApplicationIdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        SignInManager<ApplicationIdentityUser> signInManager,
        IHttpContextAccessor httpContext
        )
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
        _httpContext = httpContext;
    }

    public async Task<bool> AddUserRole(ApplicationIdentityUser user, string role)
    {
        var addToRoleResult = await _userManager.AddToRoleAsync(user, role);
        
        return addToRoleResult.Succeeded;
    }

    public async Task<(bool IsSuccess, ApplicationIdentityUser? User)> Login(UserLogin credentials)
    {
        var user = await _userManager.FindByEmailAsync(credentials.UserOrEmail) ??
                   await _userManager.FindByNameAsync(credentials.UserOrEmail);

        if (user is not null)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, credentials.Password, false);
            if (result.Succeeded)
            {
                await _signInManager.PasswordSignInAsync(user, credentials.Password, false, false);
                return (true, user);
            }
        }
        
        return (false, null);
    }

    public async Task<(bool, ApplicationIdentityUser?)> ExternalLogin(ExternalLoginInfo externalLoginInfo)
    {
        var signResult = await _signInManager.ExternalLoginSignInAsync(
            externalLoginInfo.LoginProvider, externalLoginInfo.ProviderKey, true, true);
        
        if (signResult.Succeeded)
        {
            var user = await _userManager.FindByLoginAsync(externalLoginInfo.LoginProvider, externalLoginInfo.ProviderKey);
            return (true, user);
        }
        
        var email = externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Email);
        
        if (email is not null)
        {
            var user = await _userManager.FindByEmailAsync(email);
        
            if (user is null)
            {
                user = new ApplicationIdentityUser()
                {
                    UserName = externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Name).Replace(" ", ""),
                    Email = externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Email),
                };
        
                var createUser = await _userManager.CreateAsync(user);
                var addRole = await AddUserRole(user, TypeSafe.Roles.Admin);
            }
        
            await _userManager.AddLoginAsync(user, externalLoginInfo);
            await _signInManager.SignInAsync(user, true);
            return (true, user);
        }
        
        return (false, null);
    }

    public async Task<(bool IsSuccess, ApplicationIdentityUser? User, IEnumerable<string>? errors)> RegisterUser(UserRegister user)
    {
        var identityUser = new ApplicationIdentityUser()
        {
            Email = user.UserEmail,
            UserName = user.UserName
        };

        var result = await _userManager.CreateAsync(identityUser, user.Password);
        var errors = result.Errors.Select(e => e.Description);

        if (result.Succeeded)
        {
            var addRoleResult = await AddUserRole(identityUser, TypeSafe.Roles.Admin);
            if (addRoleResult)
                return (true, identityUser, errors);
            
            return (false, null, ["Failed to add role to user."]);
        }
        
        return (false, null, errors);
    }

    public async Task<string> GenerateToken(ApplicationIdentityUser user, JwtConfiguration jwtConfig)
    {
        var claims = await AuthenticationHelper.GetClaims(user, _userManager);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Secret));

        var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

        var securityTokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Issuer = jwtConfig.Issuer,
            Audience = jwtConfig.Audience,
            Expires = DateTime.Now.AddDays(jwtConfig.ExpiresDay),
            SigningCredentials = signingCred
        };
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(securityTokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public void WriteAccessToken(string accessToken, bool isRememberMe)
    {
        _httpContext.HttpContext?.Response.Cookies.Append(TypeSafe.CookiesName.Token, accessToken, new CookieOptions
        {
            Expires = isRememberMe ? DateTime.Now.AddDays(60) : (DateTime?)null,
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            IsEssential = true,
        });
    }
}