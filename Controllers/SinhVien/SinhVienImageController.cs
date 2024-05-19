using CSharp_FinalExam.DTOs.SinhVien;
using CSharp_FinalExam.Repositories.SinhVien;
using CSharp_FinalExam.Services.AzureServices.BlobStorage;
using CSharp_FinalExam.Utilities.TypeSafe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_FinalExam.Controllers;

[Authorize(Roles = TypeSafe.Roles.Admin)]
public class SinhVienImageController : Controller
{
    private readonly ISinhVienImageService _sinhVienImageService;
    private readonly ISinhVienImageRepository _sinhVienImageRepository;

    public SinhVienImageController(
        ISinhVienImageService sinhVienImageService, 
        ISinhVienImageRepository sinhVienImageRepository
        )
    {
        _sinhVienImageService = sinhVienImageService;
        _sinhVienImageRepository = sinhVienImageRepository;
    }
    
    [HttpPost]
    public async Task<IActionResult> UploadSinhVienAvatarImage([FromForm] AddSinhVienImageDTO addSinhVienImageDto)
    {
        var imageFile = addSinhVienImageDto.ImageFile;
        
        var fileName = $"{addSinhVienImageDto.SinhVienId}_{DateTime.UtcNow:yyyyMMddHHmmss}{Path.GetExtension(imageFile.FileName)}";

        using var ms = new MemoryStream();
        await imageFile.CopyToAsync(ms);
        var fileBytes = ms.ToArray();

        var imageUrl =
            await _sinhVienImageService.UploadSinhVienImageAsync(fileBytes, fileName,
                TypeSafe.BlobContainerName.SINH_VIEN_AVATAR);
        
        await _sinhVienImageRepository.AddSinhVienAvatarImageAsync(addSinhVienImageDto.SinhVienId, imageUrl);
        
        return RedirectToAction("Index", "QuanLySinhVien");
    }
    
    [HttpPost]
    public async Task<IActionResult> UploadSinhVienTheImage([FromForm] AddSinhVienImageDTO addSinhVienImageDto)
    {
        var imageFile = addSinhVienImageDto.ImageFile;
        
        var fileName = $"{addSinhVienImageDto.SinhVienId}_{DateTime.UtcNow:yyyyMMddHHmmss}{Path.GetExtension(imageFile.FileName)}";

        using var ms = new MemoryStream();
        await imageFile.CopyToAsync(ms);
        var fileBytes = ms.ToArray();

        var imageUrl =
            await _sinhVienImageService.UploadSinhVienImageAsync(fileBytes, fileName,
                TypeSafe.BlobContainerName.SINH_VIEN_THE);
        
        await _sinhVienImageRepository.AddSinhVienTheImageAsync(addSinhVienImageDto.SinhVienId, imageUrl);
        
        return RedirectToAction("Index", "QuanLySinhVien");
    }
    
    [HttpPost]
    public async Task<IActionResult> UploadSinhVienCCCDImage([FromForm] AddSinhVienImageDTO addSinhVienImageDto)
    {
        var imageFile = addSinhVienImageDto.ImageFile;
        
        var fileName = $"{addSinhVienImageDto.SinhVienId}_{DateTime.UtcNow:yyyyMMddHHmmss}{Path.GetExtension(imageFile.FileName)}";

        using var ms = new MemoryStream();
        await imageFile.CopyToAsync(ms);
        var fileBytes = ms.ToArray();

        var imageUrl =
            await _sinhVienImageService.UploadSinhVienImageAsync(fileBytes, fileName,
                TypeSafe.BlobContainerName.SINH_VIEN_CCCD);
        
        await _sinhVienImageRepository.AddSinhVienCCCDImageAsync(addSinhVienImageDto.SinhVienId, imageUrl);
        
        return RedirectToAction("Index", "QuanLySinhVien");
    }
}