using Microsoft.AspNetCore.Mvc;

namespace CSharp_FinalExam.ViewComponents;

public class LeftNavbarViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}