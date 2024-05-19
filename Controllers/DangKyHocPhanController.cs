using CSharp_FinalExam.DTOs.DangKyHocPhanDTOs;
using CSharp_FinalExam.Models;
using CSharp_FinalExam.Repositories;
using CSharp_FinalExam.Utilities.TypeSafe;
using CSharp_FinalExam.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_FinalExam.Controllers;

[Authorize(Roles = TypeSafe.Roles.Admin)]
public class DangKyHocPhanController : Controller
{
    private readonly IDangKyHocPhanRepository _dangKyHocPhanRepository;

    public DangKyHocPhanController(IDangKyHocPhanRepository dangKyHocPhanRepository)
    {
        _dangKyHocPhanRepository = dangKyHocPhanRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var dangKyHocPhans = await _dangKyHocPhanRepository.GetAllDangKyHocPhanAsync();
        
        var dangKyHocPhanViewModel = new DangKyHocPhanViewModel()
        {
            DangKyHocPhans = dangKyHocPhans
        };
        
        return View(dangKyHocPhanViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDangKyHocPhan([FromForm] CreateDangKyHocPhanDTO createDangKyHocPhanDto)
    {
        if (!ModelState.IsValid)
        {
            var dangKyHocPhans = await _dangKyHocPhanRepository.GetAllDangKyHocPhanAsync();
            var dangKyHocPhanViewModel = new DangKyHocPhanViewModel()
            {
                DangKyHocPhans = dangKyHocPhans,
                CreateDangKyHocPhanDTO = createDangKyHocPhanDto // giữ lại dữ liệu đã nhập
            };
            ViewData["ModelState"] = ModelState;
            return View("~/Views/DangKyHocPhan/Index.cshtml", dangKyHocPhanViewModel);
        }
        
        await _dangKyHocPhanRepository.CreateDangKyHocPhanAsync(createDangKyHocPhanDto);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> EditDangKyHocPhan([FromRoute] int id)
    {
        var dangKyHocPhan = await _dangKyHocPhanRepository.GetDangKyHocPhanByIdAsync(id);
        return View("~/Views/DangKyHocPhan/UpdateDangKyHocPhan.cshtml", dangKyHocPhan);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateDangKyHocPhan([FromForm] DangKyHocPhan updateDangKyHocPhan, [FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return View("~/Views/DangKyHocPhan/UpdateDangKyHocPhan.cshtml", updateDangKyHocPhan);
        
        await _dangKyHocPhanRepository.UpdateDangKyHocPhanAsync(updateDangKyHocPhan, id);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> DetailDangKyHocPhan([FromRoute] int id)
    {
        var detailDangKyHocPhan = await _dangKyHocPhanRepository.GetDangKyHocPhanByIdAsync(id);
        return View("~/Views/DangKyHocPhan/DetailDangKyHocPhan.cshtml", detailDangKyHocPhan);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteDangKyHocPhan([FromRoute] int id)
    {
        var deleteResult = await _dangKyHocPhanRepository.DeleteDangKyHocPhanAsync(id);
        
        if (!deleteResult)
            return NotFound();

        return Ok();
    }
}