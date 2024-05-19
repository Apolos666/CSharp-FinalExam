using AutoMapper;
using CSharp_FinalExam.Data;
using CSharp_FinalExam.DTOs.KhoaDTOs;
using Microsoft.EntityFrameworkCore;

namespace CSharp_FinalExam.Repositories.Khoa;

public class KhoaRepository : IKhoaRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public KhoaRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<Models.Khoa>> GetAllKhoaAsync()
    {
        var khoas = await _dbContext.Khoas.ToListAsync();
        
        if (khoas.Count == 0)
            return null;
        
        return khoas;
    }

    public async Task<Models.Khoa?> GetKhoaByIdAsync(int id)
    {
        var khoa = await _dbContext.Khoas.FindAsync(id);
        
        if (khoa is null)
            return null;
        
        return khoa;
    }

    public async Task<Models.Khoa> CreateKhoaAsync(CreateKhoaDTO createKhoaDto)
    {
        var khoa = _mapper.Map<Models.Khoa>(createKhoaDto);
        var addResult = await _dbContext.Khoas.AddAsync(khoa);
        await _dbContext.SaveChangesAsync();
        return addResult.Entity;
    }

    public async Task<Models.Khoa> UpdateKhoaAsync(Models.Khoa updateKhoa, int id)
    {
        var khoa = await GetKhoaByIdAsync(id);
        _mapper.Map(updateKhoa, khoa);
        await _dbContext.SaveChangesAsync();
        return khoa;
    }

    public async Task<bool> DeleteKhoaAsync(int id)
    {
        var khoa = await GetKhoaByIdAsync(id);
        if (khoa is null)
            return false;
        
        _dbContext.Khoas.Remove(khoa);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}