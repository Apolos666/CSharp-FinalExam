using CSharp_FinalExam.DTOs.SinhVien;
using CSharp_FinalExam.Models;
using CSharp_FinalExam.Repositories.SinhVien;
using CSharp_FinalExam.Utilities.TypeSafe;
using CSharp_FinalExam.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_FinalExam.Controllers;

[Authorize(Roles = TypeSafe.Roles.Admin)]
public class QuanLySinhVienController : Controller
{
    private readonly ISinhVienRepository _sinhVienRepository;

    public QuanLySinhVienController(ISinhVienRepository sinhVienRepository)
    {
        _sinhVienRepository = sinhVienRepository;
    }

    public async Task<IActionResult> Index()
    {
        var sinhViens = await _sinhVienRepository.GetAllSinhVienAsync();
        
        var sinhVienViewModel = new SinhVienViewModel
        {
            SinhViens = sinhViens
        };
        
        return View(sinhVienViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSinhVien([FromForm] CreateSinhVienDTO createSinhVienDto)
    {
        if (!ModelState.IsValid)
        {
            var sinhViens = await _sinhVienRepository.GetAllSinhVienAsync();
            var sinhVienViewModel = new SinhVienViewModel
            {
                SinhViens = sinhViens,
                CreateSinhVienDTO = createSinhVienDto // giữ lại dữ liệu đã nhập
            };
            ViewData["ModelState"] = ModelState;
            return View("~/Views/QuanLySinhVien/Index.cshtml", sinhVienViewModel);
        }
        
        await _sinhVienRepository.CreateSinhVienAsync(createSinhVienDto);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> EditSinhVien([FromRoute] int id)
    {
        var sinhVien = await _sinhVienRepository.GetSinhVienByIdAsync(id);
        return View("~/Views/QuanLySinhVien/UpdateSinhVien.cshtml", sinhVien);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateSinhVien([FromForm] SinhVien updateSinhVienDto, [FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return View("~/Views/QuanLySinhVien/UpdateSinhVien.cshtml", updateSinhVienDto);
        
        await _sinhVienRepository.UpdateSinhVienAsync(updateSinhVienDto, id);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> DetailSinhVien([FromRoute] int id)
    {
        var detailSinhVien = await _sinhVienRepository.GetSinhVienByIdAsync(id);
        return View("~/Views/QuanLySinhVien/DetailSinhVien.cshtml", detailSinhVien);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteSinhVien([FromRoute] int id)
    {
        var deleteResult = await _sinhVienRepository.DeleteSinhVienAsync(id);
        
        if (!deleteResult)
            return NotFound();

        return Ok();
    }
}