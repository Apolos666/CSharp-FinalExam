using CSharp_FinalExam.Data;
using CSharp_FinalExam.Models;

namespace CSharp_FinalExam.Repositories.SinhVien;

public class SinhVienImageRepository : ISinhVienImageRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SinhVienImageRepository(
        ApplicationDbContext dbContext
    )
    {
        _dbContext = dbContext;
    }

    public async Task<SinhVienImage> AddSinhVienAvatarImageAsync(int sinhVienId, string ImageUrl)
    {
        var sinhVienImage = new SinhVienImage
        {
            SinhVienId = sinhVienId,
            ImageUrl = ImageUrl
        };

        var result = await _dbContext.SinhVienImages.AddAsync(sinhVienImage);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<SinhVienTheSV> AddSinhVienTheImageAsync(int sinhVienId, string ImageUrl)
    {
        var sinhVienTheSv = new SinhVienTheSV()
        {
            SinhVienId = sinhVienId,
            TheSVUrl = ImageUrl
        };

        var result = await _dbContext.SinhVienTheSvs.AddAsync(sinhVienTheSv);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<SinhVienCCCD> AddSinhVienCCCDImageAsync(int sinhVienId, string ImageUrl)
    {
        var sinhVienCccd = new SinhVienCCCD()
        {
            SinhVienId = sinhVienId,
            TheSVUrl = ImageUrl
        };

        var result = await _dbContext.SinhVienCccds.AddAsync(sinhVienCccd);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }
}