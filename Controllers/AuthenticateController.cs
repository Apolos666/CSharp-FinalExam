using CSharp_FinalExam.DTOs.IdentityDTOs;
using CSharp_FinalExam.Services.AuthenticationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_FinalExam.Controllers;

[Route("authenticate")]
[AllowAnonymous]
public class AuthenticateController : Controller
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticateController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
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
    public async Task<IActionResult> LoginUser(UserLogin credentials)
    {
        if (!ModelState.IsValid)
        {
            return View("~/Views/Authenticate/LoginView.cshtml", credentials);
        }

        var result = await _authenticationService.Login(credentials);
        
        if (!result.IsSuccess)
        {
            return View("~/Views/Authenticate/LoginView.cshtml", credentials);
        }
        
        return RedirectToAction("Index", "Home");
    }
    
    [HttpPost]
    [Route("registeruser")]
    public async Task<IActionResult> RegisterUser(UserRegister user)
    {
        if (!ModelState.IsValid)
        {
            return View("~/Views/Authenticate/RegisterView.cshtml", user);
        }

        var result = await _authenticationService.RegisterUser(user);
        
        if (!result.IsSuccess)
        {
            user.ErrorMessage = result.errors;
            return View("~/Views/Authenticate/RegisterView.cshtml", user);
        }
        
        return RedirectToAction("LoginView");
    }
}