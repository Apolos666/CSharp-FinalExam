using CSharp_FinalExam.DTOs.LopSinhHoat;
using CSharp_FinalExam.Models;
using CSharp_FinalExam.Repositories.LopSinhHoat;
using CSharp_FinalExam.Utilities.TypeSafe;
using CSharp_FinalExam.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_FinalExam.Controllers;

[Authorize(Roles = TypeSafe.Roles.Admin)]
public class QuanLyLopSinhHoatController : Controller
{
    private readonly ILopSinhHoatRepository _lopSinhHoatRepository;

    public QuanLyLopSinhHoatController(ILopSinhHoatRepository lopSinhHoatRepository)
    {
        _lopSinhHoatRepository = lopSinhHoatRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var lopSinhHoats = await _lopSinhHoatRepository.GetAllLopSinhHoatAsync();
        
        var lopSinhHoatViewModel = new LopSinhHoatViewModel()
        {
            LopSinhHoats = lopSinhHoats
        };
        
        return View(lopSinhHoatViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLopSinhHoat([FromForm] CreateLopSinhHoatDTO createLopSinhHoatDTO)
    {
        if (!ModelState.IsValid)
        {
            var lopSinhHoats = await _lopSinhHoatRepository.GetAllLopSinhHoatAsync();
            var lopSinhHoatViewModel = new LopSinhHoatViewModel()
            {
                LopSinhHoats = lopSinhHoats,
                CreateLopSinhHoatDTO = createLopSinhHoatDTO // giữ lại dữ liệu đã nhập
            };
            ViewData["ModelState"] = ModelState;
            return View("~/Views/QuanLyLopSinhHoat/Index.cshtml", lopSinhHoatViewModel);
        }
        
        await _lopSinhHoatRepository.CreateLopSinhHoatAsync(createLopSinhHoatDTO);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> EditLopSinhHoat([FromRoute] int id)
    {
        var lopSinhHoat = await _lopSinhHoatRepository.GetLopSinhHoatByIdAsync(id);
        return View("~/Views/QuanLyLopSinhHoat/UpdateLopSinhHoat.cshtml", lopSinhHoat);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateLopSinhHoat([FromForm] LopSinhHoat updatelLopSinhHoat, [FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return View("~/Views/QuanLyLopSinhHoat/UpdateLopSinhHoat.cshtml", updatelLopSinhHoat);
        
        await _lopSinhHoatRepository.UpdateLopSinhHoatAsync(updatelLopSinhHoat, id);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> DetailLopSinhHoat([FromRoute] int id)
    {
        var detailLopSinhHoat = await _lopSinhHoatRepository.GetLopSinhHoatByIdAsync(id);
        return View("~/Views/QuanLyLopSinhHoat/DetailLopSinhHoat.cshtml", detailLopSinhHoat);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteLopSinhHoat([FromRoute] int id)
    {
        var deleteResult = await _lopSinhHoatRepository.DeleteLopSinhHoatAsync(id);
        
        if (!deleteResult)
            return NotFound();

        return Ok();
    }
}