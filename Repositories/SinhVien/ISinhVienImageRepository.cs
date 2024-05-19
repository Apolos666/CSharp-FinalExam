using CSharp_FinalExam.Models;

namespace CSharp_FinalExam.Repositories.SinhVien;

public interface ISinhVienImageRepository
{
    Task<SinhVienImage> AddSinhVienAvatarImageAsync(int sinhVienId, string ImageUrl);
    Task<SinhVienTheSV> AddSinhVienTheImageAsync(int sinhVienId, string ImageUrl);
    Task<SinhVienCCCD> AddSinhVienCCCDImageAsync(int sinhVienId, string ImageUrl);
}