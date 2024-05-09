using CSharp_FinalExam.Data;
using CSharp_FinalExam.DTOs.IdentityDTOs;
using CSharp_FinalExam.Models.Identity;
using CSharp_FinalExam.Utilities.TypeSafe;
using Microsoft.AspNetCore.Identity;

namespace CSharp_FinalExam.Services.AuthenticationService;

public class AuthenticationService : IAuthenticationService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationIdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<ApplicationIdentityUser> _signInManager;


    public AuthenticationService(
        ApplicationDbContext context,
        UserManager<ApplicationIdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        SignInManager<ApplicationIdentityUser> signInManager
        )
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
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
}