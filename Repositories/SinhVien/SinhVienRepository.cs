using AutoMapper;
using CSharp_FinalExam.Data;
using CSharp_FinalExam.DTOs.SinhVien;
using Microsoft.EntityFrameworkCore;

namespace CSharp_FinalExam.Repositories.SinhVien;

public class SinhVienRepository : ISinhVienRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public SinhVienRepository(
        ApplicationDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<Models.SinhVien>> GetAllSinhVienAsync()
    {
        var sinhViens = await _dbContext.SinhViens.ToListAsync();
        return sinhViens;
    }
    
    public async Task<Models.SinhVien?> GetSinhVienByIdAsync(int id)
    {
        var sinhVien = await _dbContext.SinhViens.FindAsync(id);
        
        return sinhVien;
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