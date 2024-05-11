using System.Security.Claims;
using CSharp_FinalExam.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace CSharp_FinalExam.Services.AuthenticationService;

public static class AuthenticationHelper
{
    public static async Task<List<Claim>> GetClaims(ApplicationIdentityUser user, UserManager<ApplicationIdentityUser> userManager)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName)
        };

        var roles = await userManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));        
        }

        return claims;
    }
}