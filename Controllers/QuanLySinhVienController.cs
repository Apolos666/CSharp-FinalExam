using Microsoft.AspNetCore.Mvc;

namespace CSharp_FinalExam.Controllers;

public class QuanLySinhVienController : Controller
{
    public QuanLySinhVienController()
    {
        
    }

    public IActionResult Index()
    {
        return View();
    }
}