using AutoMapper;
using CSharp_FinalExam.Data;
using CSharp_FinalExam.DTOs.LopSinhHoat;
using Microsoft.EntityFrameworkCore;

namespace CSharp_FinalExam.Repositories.LopSinhHoat;

public class LopSinhHoatRepository : ILopSinhHoatRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public LopSinhHoatRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<Models.LopSinhHoat>?> GetAllLopSinhHoatAsync()
    {
        var lopSinhHoats = await _dbContext.LopSinhHoats.ToListAsync();
        
        if (lopSinhHoats.Count == 0)
            return null;
        
        return lopSinhHoats;
    }

    public async Task<Models.LopSinhHoat?> GetLopSinhHoatByIdAsync(int id)
    {
        var lopSinhHoat = await _dbContext.LopSinhHoats.FindAsync(id);
        
        if (lopSinhHoat is null)
            return null;
        
        return lopSinhHoat;
    }

    public async Task<Models.LopSinhHoat> CreateLopSinhHoatAsync(CreateLopSinhHoatDTO createLopSinhHoatDto)
    {
        var lopSinhHoat = _mapper.Map<Models.LopSinhHoat>(createLopSinhHoatDto);
        var addResult = await _dbContext.LopSinhHoats.AddAsync(lopSinhHoat);
        await _dbContext.SaveChangesAsync();
        return addResult.Entity;
    }

    public async Task<Models.LopSinhHoat> UpdateLopSinhHoatAsync(Models.LopSinhHoat updateLopSinhHoat, int id)
    {
        var lopSinhHoat = await GetLopSinhHoatByIdAsync(id);
        _mapper.Map(updateLopSinhHoat, lopSinhHoat);
        await _dbContext.SaveChangesAsync();
        return lopSinhHoat;
    }

    public async Task<bool> DeleteLopSinhHoatAsync(int id)
    {
        var lopSinhHoat = await GetLopSinhHoatByIdAsync(id);
        
        if (lopSinhHoat is null)
            return false;
        
        _dbContext.LopSinhHoats.Remove(lopSinhHoat);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}