using CSharp_FinalExam.DTOs.SinhVien;
using CSharp_FinalExam.Repositories.SinhVien;
using CSharp_FinalExam.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_FinalExam.Controllers;

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
}