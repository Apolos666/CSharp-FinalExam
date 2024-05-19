using AutoMapper;
using CSharp_FinalExam.Data;
using CSharp_FinalExam.DTOs.LopHocPhanDTOs;
using Microsoft.EntityFrameworkCore;

namespace CSharp_FinalExam.Repositories.LopHocPhan;

public class LopHocPhanRepository : ILopHocPhanRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public LopHocPhanRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<Models.LopHocPhan>> GetAllLopHocPhanAsync()
    {
        var lopHocPhans = await _dbContext.LopHocPhans.ToListAsync();
        
        if (lopHocPhans.Count == 0)
            return null;
        
        return lopHocPhans;
    }

    public async Task<Models.LopHocPhan?> GetLopHocPhanByIdAsync(int id)
    {
        var lopHocPhan = await _dbContext.LopHocPhans.FindAsync(id);

        return lopHocPhan;
    }

    public async Task<Models.LopHocPhan> CreateLopHocPhanAsync(CreateLopHocPhanDTO createLopHocPhanDto)
    {
        var lopHocPhan = _mapper.Map<Models.LopHocPhan>(createLopHocPhanDto);
        var result = await _dbContext.LopHocPhans.AddAsync(lopHocPhan);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Models.LopHocPhan> UpdateLopHocPhanAsync(Models.LopHocPhan updateLopHocPhan, int id)
    {
        var lopHocPhan = await _dbContext.LopHocPhans.FindAsync(id);

        if (lopHocPhan is null)
            return null;
        
        _mapper.Map(updateLopHocPhan, lopHocPhan);
        await _dbContext.SaveChangesAsync();
        return lopHocPhan;
    }

    public async Task<bool> DeleteLopHocPhanAsync(int id)
    {
        var lopHocPhan = await _dbContext.LopHocPhans.FindAsync(id);
        
        if (lopHocPhan is null)
            return false;
        
        _dbContext.LopHocPhans.Remove(lopHocPhan);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}