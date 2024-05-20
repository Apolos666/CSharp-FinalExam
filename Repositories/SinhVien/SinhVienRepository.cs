using AutoMapper;
using CSharp_FinalExam.Data;
using CSharp_FinalExam.DTOs.SinhVien;
using CSharp_FinalExam.Services.AzureServices.BlobStorage;
using CSharp_FinalExam.Utilities.TypeSafe;
using CSharp_FinalExam.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CSharp_FinalExam.Repositories.SinhVien;

public class SinhVienRepository : ISinhVienRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ISinhVienImageService _sinhVienImageService;

    public SinhVienRepository(
        ApplicationDbContext dbContext,
        IMapper mapper,
        ISinhVienImageService sinhVienImageService)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _sinhVienImageService = sinhVienImageService;
    }

    public async Task<IEnumerable<Models.SinhVien>> GetAllSinhVienAsync()
    {
        var sinhViens = await _dbContext.SinhViens.ToListAsync();
        
        return sinhViens;
    }

    public async Task<IEnumerable<Models.SinhVien>> GetAllSinhVienAsync(FilterSinhVienDTO filterSinhVienDto)
    {
        var sinhViens = _dbContext.SinhViens.AsQueryable();

        if (!string.IsNullOrEmpty(filterSinhVienDto.FilterTen))
            sinhViens = sinhViens.Where(sv => sv.HoTen.Contains(filterSinhVienDto.FilterTen));
        
        return await sinhViens.ToListAsync();
    }
    
    public async Task<Models.SinhVien?> GetSinhVienByIdAsync(int id)
    {
        var sinhVien = await _dbContext.SinhViens.FindAsync(id);
        
        return sinhVien;
    }

    public async Task<SinhVienDetailViewModel> GetSinhVienDetailViewModelAsync(int id)
    {
        var sinhVien = await GetSinhVienByIdAsync(id);
        var sinhVienImages = await _dbContext.SinhVienImages.Where(svi => svi.SinhVienId == id).ToListAsync();
        var sinhVienTheSvs = await _dbContext.SinhVienTheSvs.Where(svt => svt.SinhVienId == id).ToListAsync();
        var sinhVienCccds = await _dbContext.SinhVienCccds.Where(svcccd => svcccd.SinhVienId == id).ToListAsync();

        var sinhVienImage64S = (await Task.WhenAll(sinhVienImages.Select(svi =>
            _sinhVienImageService.DownloadSinhVienImageAsync(svi.ImageUrl,
                TypeSafe.BlobContainerName.SINH_VIEN_AVATAR)))).ToList();

        var sinhVienThe64S = (await Task.WhenAll(sinhVienTheSvs.Select(svt =>
            _sinhVienImageService.DownloadSinhVienImageAsync(svt.TheSVUrl,
                TypeSafe.BlobContainerName.SINH_VIEN_THE)))).ToList();
        
        var sinhVienCccd64S = (await Task.WhenAll(sinhVienCccds.Select(svcccd =>
            _sinhVienImageService.DownloadSinhVienImageAsync(svcccd.TheSVUrl,
                TypeSafe.BlobContainerName.SINH_VIEN_CCCD)))).ToList();

        var sinhVienDetailViewModel = new SinhVienDetailViewModel()
        {
            SinhVien = sinhVien,
            SinhVienImage64s = sinhVienImage64S,
            SinhVienThe64s = sinhVienThe64S,
            SinhVienCCCD64s = sinhVienCccd64S
        };

        return sinhVienDetailViewModel;
    }

    public async Task<Models.SinhVien> CreateSinhVienAsync(CreateSinhVienDTO createSinhVienDto)
    {
        var sinhVien = _mapper.Map<Models.SinhVien>(createSinhVienDto);
        var addResult = await _dbContext.SinhViens.AddAsync(sinhVien);
        await _dbContext.SaveChangesAsync();
        return addResult.Entity;
    }

    public async Task<Models.SinhVien> UpdateSinhVienAsync(Models.SinhVien updateSinhVien, int id)
    {
        var sinhVien = await GetSinhVienByIdAsync(id);
        _mapper.Map(updateSinhVien, sinhVien);
        await _dbContext.SaveChangesAsync();
        return sinhVien;
    }

    public async Task<bool> DeleteSinhVienAsync(int id)
    {
        var sinhVien = await GetSinhVienByIdAsync(id);
        if (sinhVien is null)
            return false;
        
        _dbContext.SinhViens.Remove(sinhVien);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}