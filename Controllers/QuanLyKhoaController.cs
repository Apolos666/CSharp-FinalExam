using CSharp_FinalExam.DTOs.KhoaDTOs;
using CSharp_FinalExam.Models;
using CSharp_FinalExam.Repositories.Khoa;
using CSharp_FinalExam.Utilities.TypeSafe;
using CSharp_FinalExam.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_FinalExam.Controllers;

[Authorize(Roles = TypeSafe.Roles.Admin)]
public class QuanLyKhoaController : Controller
{
    private readonly IKhoaRepository _khoaRepository;

    public QuanLyKhoaController(IKhoaRepository khoaRepository)
    {
        _khoaRepository = khoaRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var khoas = await _khoaRepository.GetAllKhoaAsync();
        
        var khoaViewModel = new KhoaViewModel()
        {
            Khoas = khoas
        };
        
        return View(khoaViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateKhoa([FromForm] CreateKhoaDTO createKhoaDto)
    {
        if (!ModelState.IsValid)
        {
            var khoas = await _khoaRepository.GetAllKhoaAsync();
            var khoaViewModel = new KhoaViewModel()
            {
                Khoas = khoas,
                CreateKhoaDTO = createKhoaDto // giữ lại dữ liệu đã nhập
            };
            ViewData["ModelState"] = ModelState;
            return View("~/Views/QuanLyKhoa/Index.cshtml", khoaViewModel);
        }
        
        await _khoaRepository.CreateKhoaAsync(createKhoaDto);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> EditKhoa([FromRoute] int id)
    {
        var khoa = await _khoaRepository.GetKhoaByIdAsync(id);
        return View("~/Views/QuanLyKhoa/UpdateKhoa.cshtml", khoa);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateKhoa([FromForm] Khoa updateKhoa, [FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return View("~/Views/QuanLyKhoa/UpdateKhoa.cshtml", updateKhoa);
        
        await _khoaRepository.UpdateKhoaAsync(updateKhoa, id);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> DetailKhoa([FromRoute] int id)
    {
        var detailKhoa = await _khoaRepository.GetKhoaByIdAsync(id);
        return View("~/Views/QuanLyKhoa/DetailKhoa.cshtml", detailKhoa);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteKhoa([FromRoute] int id)
    {
        var deleteResult = await _khoaRepository.DeleteKhoaAsync(id);
        
        if (!deleteResult)
            return NotFound();

        return Ok();
    }
}