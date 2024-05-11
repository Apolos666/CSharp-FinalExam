using CSharp_FinalExam.DTOs.IdentityDTOs;
using CSharp_FinalExam.Models.Authentication;
using CSharp_FinalExam.Models.Identity;
using CSharp_FinalExam.Services.AuthenticationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_FinalExam.Controllers;

[Route("authenticate")]
[AllowAnonymous]
public class AuthenticateController : Controller
{
    private readonly IAuthenticationService _authenticationService;
    private readonly JwtConfiguration _jwtConfig;

    public AuthenticateController(IAuthenticationService authenticationService, JwtConfiguration jwtConfig)
    {
        _authenticationService = authenticationService;
        _jwtConfig = jwtConfig;
    }
    
    [Route("login-view")]
    public IActionResult LoginView()
    {
        return View();
    }
    
    [Route("register-view")]
    public IActionResult RegisterView()
    {
        return View();
    }
    
    [HttpPost]
    [Route("loginuser")]
    public async Task<IActionResult> LoginUser([FromForm] UserLogin userLogin)
    {
        if (!ModelState.IsValid)
        {
            return View("~/Views/Authenticate/LoginView.cshtml", userLogin);
        }

        var result = await _authenticationService.Login(userLogin);
        
        if (!result.IsSuccess)
        {
            userLogin.ErrorMessage = "Login failed. Please check your username and password.";
            return View("~/Views/Authenticate/LoginView.cshtml", userLogin);
        }
        
        await GenerateAndWriteToken(result.User, userLogin.IsRememberMe);
        
        return RedirectToAction("Index", "Home");
    }
    
    [HttpPost]
    [Route("registeruser")]
    public async Task<IActionResult> RegisterUser([FromForm] UserRegister userRegister)
    {
        if (!ModelState.IsValid)
        {
            return View("~/Views/Authenticate/RegisterView.cshtml", userRegister);
        }

        var result = await _authenticationService.RegisterUser(userRegister);
        
        if (!result.IsSuccess)
        {
            userRegister.ErrorMessage = result.errors;
            return View("~/Views/Authenticate/RegisterView.cshtml", userRegister);
        }
        
        return RedirectToAction("LoginView");
    }

    private async Task GenerateAndWriteToken(ApplicationIdentityUser user, bool isRememberMe)
    {
        var accessToken = await _authenticationService.GenerateToken(user, _jwtConfig);
        _authenticationService.WriteAccessToken(accessToken, isRememberMe);
    }
}