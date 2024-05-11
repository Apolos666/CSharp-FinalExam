using Microsoft.AspNetCore.Mvc;

namespace CSharp_FinalExam.Controllers;

[Route("[controller]")]
public class ErrorController : Controller
{
    [Route("access-denied")]
    public IActionResult AccessDenied()
    {
        return View("~/Views/Shared/AccessDenied.cshtml");
    }
}