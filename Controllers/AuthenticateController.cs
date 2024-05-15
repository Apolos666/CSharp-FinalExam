using CSharp_FinalExam.DTOs.IdentityDTOs;
using CSharp_FinalExam.Models.Authentication;
using CSharp_FinalExam.Models.Identity;
using CSharp_FinalExam.Services.AuthenticationService;
using CSharp_FinalExam.Utilities.TypeSafe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_FinalExam.Controllers;

[Route("authenticate")]
[AllowAnonymous]
public class AuthenticateController : Controller
{
    private readonly IAuthenticationService _authenticationService;
    private readonly JwtConfiguration _jwtConfig;
    private readonly SignInManager<ApplicationIdentityUser> _signInManager;

    public AuthenticateController(IAuthenticationService authenticationService, JwtConfiguration jwtConfig, SignInManager<ApplicationIdentityUser> signInManager)
    {
        _authenticationService = authenticationService;
        _jwtConfig = jwtConfig;
        _signInManager = signInManager;
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
    
    [HttpGet]
    [Route("get-me")]
    [Authorize(Roles = TypeSafe.Roles.Admin)]
    public async Task<IActionResult> GetMe()
    {
        var user = await _authenticationService.GetMe();
        return Ok(user);
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
    
    [HttpPost]
    [Route("logout")]
    public async Task<IActionResult> Logout()
    {
        await _authenticationService.Logout();
        return RedirectToAction("LoginView");
    }
    
    [HttpPost]
    public IActionResult ExternalLogin(string provider, string returnUrl)
    {
        var redirectUrl = Url.Action("ExternalLoginCallback", "Authenticate", new { ReturnUrl = returnUrl});
        var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        return new ChallengeResult(provider, properties);
    }
    
    public async Task<IActionResult> ExternalLoginCallback([FromQuery] string? returnUrl, [FromQuery] string? remoteError)
    {
        var externalLoginInfo = await _signInManager.GetExternalLoginInfoAsync();

        var result = await _authenticationService.ExternalLogin(externalLoginInfo);
        
        await GenerateAndWriteToken(result.User, true);
        
        returnUrl ??= Url.Content("~/");
        // Tạm thời đưa về RedirectView để Token kịp lưu rồi mới chuyển tới returnUrl
        return View("RedirectView", new RedirectViewModel { returnUrl = returnUrl });
    }
    
    private async Task GenerateAndWriteToken(ApplicationIdentityUser user, bool isRememberMe)
    {
        var accessToken = await _authenticationService.GenerateToken(user, _jwtConfig);
        _authenticationService.WriteAccessToken(accessToken, isRememberMe);
    }
}