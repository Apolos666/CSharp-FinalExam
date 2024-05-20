using CSharp_FinalExam.Services.AuthenticationService;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_FinalExam.ViewComponents;

public class HeaderNavbarViewComponent : ViewComponent
{
    private readonly IAuthenticationService _authenticationService;

    public HeaderNavbarViewComponent(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var userView = await _authenticationService.GetMe();
        return View(userView);
    }
}