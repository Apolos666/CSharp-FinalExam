using CSharp_FinalExam.DTOs.SinhVien;

namespace CSharp_FinalExam.Repositories.SinhVien;

public interface ISinhVienRepository
{
    Task<IEnumerable<Models.SinhVien>> GetAllSinhVienAsync();
    Task<Models.SinhVien?> GetSinhVienByIdAsync(int id);
    Task<Models.SinhVien> CreateSinhVienAsync(CreateSinhVienDTO createSinhVienDto);
    Task<Models.SinhVien> UpdateSinhVienAsync(Models.SinhVien updateSinhVien, int id);
}