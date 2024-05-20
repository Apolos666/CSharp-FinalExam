using AutoMapper;
using CSharp_FinalExam.Data;
using CSharp_FinalExam.DTOs.GiaoVien;
using Microsoft.EntityFrameworkCore;

namespace CSharp_FinalExam.Repositories.GiaoVien;

public class GiaoVienRepository : IGiaoVienRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GiaoVienRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<Models.GiaoVien>> GetAllGiaoVienAsync()
    {
        var giaoViens = await _dbContext.GiaoViens.ToListAsync();
        
        if (giaoViens.Count == 0)
            return null;
        
        return giaoViens;
    }

    public async Task<Models.GiaoVien?> GetGiaoVienByIdAsync(int id)
    {
        var giaoVien = await _dbContext.GiaoViens.FindAsync(id);
        
        if (giaoVien is null)
            return null;
        
        return giaoVien;
    }

    public async Task<Models.GiaoVien> CreateGiaoVienAsync(CreateGiaoVienDTO createGiaoVien)
    {
        var giaoVien = _mapper.Map<Models.GiaoVien>(createGiaoVien);
        var addResult = await _dbContext.GiaoViens.AddAsync(giaoVien);
        await _dbContext.SaveChangesAsync();
        return addResult.Entity;
    }

    public async Task<Models.GiaoVien> UpdateGiaoVienAsync(Models.GiaoVien updateGiaoVien, int id)
    {
        var giaoVien = await GetGiaoVienByIdAsync(id);
        _mapper.Map(updateGiaoVien, giaoVien);
        await _dbContext.SaveChangesAsync();
        return giaoVien;
    }

    public async Task<bool> DeleteGiaoVienAsync(int id)
    {
        var giaoVien = await GetGiaoVienByIdAsync(id);
        
        if (giaoVien is null)
            return false;
        
        _dbContext.GiaoViens.Remove(giaoVien);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}