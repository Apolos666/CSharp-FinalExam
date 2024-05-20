using CSharp_FinalExam.DTOs.LopHocPhanDTOs;
using CSharp_FinalExam.Models;
using CSharp_FinalExam.Repositories.LopHocPhan;
using CSharp_FinalExam.Utilities.TypeSafe;
using CSharp_FinalExam.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_FinalExam.Controllers;

[Authorize(Roles = TypeSafe.Roles.Admin)]
public class QuanLyLopHocPhanController : Controller
{
    private readonly ILopHocPhanRepository _lopHocPhanRepository;

    public QuanLyLopHocPhanController(ILopHocPhanRepository lopHocPhanRepository)
    {
        _lopHocPhanRepository = lopHocPhanRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var lopHocPhans = await _lopHocPhanRepository.GetAllLopHocPhanAsync();
        
        var lopHocPhanViewModel = new LopHocPhanViewModel()
        {
            LopHocPhans = lopHocPhans
        };
        
        return View(lopHocPhanViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLopHocPhan([FromForm] CreateLopHocPhanDTO createLopHocPhanDto)
    {
        if (!ModelState.IsValid)
        {
            var lopHocPhans = await _lopHocPhanRepository.GetAllLopHocPhanAsync();
            var lopHocPhanViewModel = new LopHocPhanViewModel()
            {
                LopHocPhans = lopHocPhans,
                CreateLopHocPhanDTO = createLopHocPhanDto // giữ lại dữ liệu đã nhập
            };
            ViewData["ModelState"] = ModelState;
            return View("~/Views/QuanLyLopHocPhan/Index.cshtml", lopHocPhanViewModel);
        }
        
        await _lopHocPhanRepository.CreateLopHocPhanAsync(createLopHocPhanDto);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> EditLopHocPhan([FromRoute] int id)
    {
        var lopHocPhan = await _lopHocPhanRepository.GetLopHocPhanByIdAsync(id);
        return View("~/Views/QuanLyLopHocPhan/UpdateLopHocPhan.cshtml", lopHocPhan);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateLopHocPhan([FromForm] LopHocPhan updateLopHocPhan, [FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return View("~/Views/QuanLyLopHocPhan/UpdateLopHocPhan.cshtml", updateLopHocPhan);
        
        await _lopHocPhanRepository.UpdateLopHocPhanAsync(updateLopHocPhan, id);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> DetailLopHocPhan([FromRoute] int id)
    {
        var detailLopHocPhan = await _lopHocPhanRepository.GetLopHocPhanByIdAsync(id);
        return View("~/Views/QuanLyLopHocPhan/DetailLopHocPhan.cshtml", detailLopHocPhan);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteLopHocPhan([FromRoute] int id)
    {
        var deleteResult = await _lopHocPhanRepository.DeleteLopHocPhanAsync(id);
        
        if (!deleteResult)
            return NotFound();

        return Ok();
    }
}