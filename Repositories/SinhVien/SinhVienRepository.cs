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

    public async Task<Models.SinhVien> CreateSinhVienAsync(CreateSinhVienDTO createSinhVienDto)
    {
        var sinhVien = _mapper.Map<Models.SinhVien>(createSinhVienDto);
        var addResult = await _dbContext.SinhViens.AddAsync(sinhVien);
        await _dbContext.SaveChangesAsync();
        return addResult.Entity;
    }
}