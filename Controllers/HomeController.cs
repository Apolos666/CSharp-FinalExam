using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSharp_FinalExam.Models;
using CSharp_FinalExam.Utilities.TypeSafe;
using Microsoft.AspNetCore.Authorization;

namespace CSharp_FinalExam.Controllers;

[Authorize(Roles = TypeSafe.Roles.Admin)]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}
