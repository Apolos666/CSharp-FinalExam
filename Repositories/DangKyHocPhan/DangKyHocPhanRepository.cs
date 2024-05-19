using AutoMapper;
using CSharp_FinalExam.Data;
using CSharp_FinalExam.DTOs.DangKyHocPhanDTOs;
using CSharp_FinalExam.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharp_FinalExam.Repositories;

public class DangKyHocPhanRepository : IDangKyHocPhanRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public DangKyHocPhanRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<DangKyHocPhan>> GetAllDangKyHocPhanAsync()
    {
        var dangKyHocPhans = await _dbContext.DangKyHocPhans.ToListAsync();
        
        return dangKyHocPhans;
    }

    public async Task<DangKyHocPhan?> GetDangKyHocPhanByIdAsync(int id)
    {
        var dangKyHocPhan = await _dbContext.DangKyHocPhans.FirstOrDefaultAsync(dangKyHocPhan => dangKyHocPhan.Id == id);

        return dangKyHocPhan;
    }

    public async Task<DangKyHocPhan> CreateDangKyHocPhanAsync(CreateDangKyHocPhanDTO createDangKyHocPhanDto)
    {
        createDangKyHocPhanDto.NgayDangKy = DateTime.Now;
        var dangKyHocPhan = _mapper.Map<DangKyHocPhan>(createDangKyHocPhanDto);
        var result = await _dbContext.DangKyHocPhans.AddAsync(dangKyHocPhan);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<DangKyHocPhan> UpdateDangKyHocPhanAsync(DangKyHocPhan updateDangKyHocPhan, int id)
    {
        var dangKyHocPhan = await GetDangKyHocPhanByIdAsync(id);
        updateDangKyHocPhan.NgayDangKy = DateTime.Now;
        _mapper.Map(updateDangKyHocPhan, dangKyHocPhan);
        await _dbContext.SaveChangesAsync();
        return dangKyHocPhan;
    }

    public async Task<bool> DeleteDangKyHocPhanAsync(int id)
    {
        var dangKyHocPhan = await GetDangKyHocPhanByIdAsync(id);
        
        if (dangKyHocPhan is null)
            return false;
        
        _dbContext.DangKyHocPhans.Remove(dangKyHocPhan);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}