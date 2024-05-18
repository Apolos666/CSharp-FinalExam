using CSharp_FinalExam.DTOs.GiaoVien;
using CSharp_FinalExam.Models;
using CSharp_FinalExam.Repositories.GiaoVien;
using CSharp_FinalExam.Utilities.TypeSafe;
using CSharp_FinalExam.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_FinalExam.Controllers;

[Authorize(Roles = TypeSafe.Roles.Admin)]
public class QuanLyGiaoVienController : Controller
{
    private readonly IGiaoVienRepository _giaoVienRepository;

    public QuanLyGiaoVienController(IGiaoVienRepository giaoVienRepository)
    {
        _giaoVienRepository = giaoVienRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var giaoViens = await _giaoVienRepository.GetAllGiaoVienAsync();
        
        var giaoVienViewModel = new GiaoVienViewModel()
        {
            GiaoViens = giaoViens
        };
        
        return View(giaoVienViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateGiaoVien([FromForm] CreateGiaoVienDTO createGiaoVienDto)
    {
        if (!ModelState.IsValid)
        {
            var giaoViens = await _giaoVienRepository.GetAllGiaoVienAsync();
            var giaoVienViewModel = new GiaoVienViewModel()
            {
                GiaoViens = giaoViens,
                CreateGiaoVienDTO = createGiaoVienDto // giữ lại dữ liệu đã nhập
            };
            ViewData["ModelState"] = ModelState;
            return View("~/Views/QuanLyGiaoVien/Index.cshtml", giaoVienViewModel);
        }
        
        await _giaoVienRepository.CreateGiaoVienAsync(createGiaoVienDto);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> EditGiaoVien([FromRoute] int id)
    {
        var giaoVien = await _giaoVienRepository.GetGiaoVienByIdAsync(id);
        return View("~/Views/QuanLyGiaoVien/UpdateGiaoVien.cshtml", giaoVien);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateGiaoVien([FromForm] GiaoVien updateGiaoVienDto, [FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return View("~/Views/QuanLyGiaoVien/UpdateGiaoVien.cshtml", updateGiaoVienDto);
        
        await _giaoVienRepository.UpdateGiaoVienAsync(updateGiaoVienDto, id);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> DetailGiaoVien([FromRoute] int id)
    {
        var detailGiaoVien = await _giaoVienRepository.GetGiaoVienByIdAsync(id);
        return View("~/Views/QuanLyGiaoVien/DetailGiaoVien.cshtml", detailGiaoVien);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteGiaoVien([FromRoute] int id)
    {
        var deleteResult = await _giaoVienRepository.DeleteGiaoVienAsync(id);
        
        if (!deleteResult)
            return NotFound();

        return Ok();
    }
}