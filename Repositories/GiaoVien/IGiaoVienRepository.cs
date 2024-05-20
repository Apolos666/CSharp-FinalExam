using CSharp_FinalExam.DTOs.GiaoVien;

namespace CSharp_FinalExam.Repositories.GiaoVien;

public interface IGiaoVienRepository
{
    Task<IEnumerable<Models.GiaoVien>> GetAllGiaoVienAsync();
    Task<Models.GiaoVien?> GetGiaoVienByIdAsync(int id);
    Task<Models.GiaoVien> CreateGiaoVienAsync(CreateGiaoVienDTO createGiaoVien);
    Task<Models.GiaoVien> UpdateGiaoVienAsync(Models.GiaoVien updateGiaoVien, int id);
    Task<bool> DeleteGiaoVienAsync(int id);
}