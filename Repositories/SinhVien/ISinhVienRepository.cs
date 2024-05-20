using CSharp_FinalExam.DTOs.SinhVien;
using CSharp_FinalExam.ViewModel;

namespace CSharp_FinalExam.Repositories.SinhVien;

public interface ISinhVienRepository
{
    Task<IEnumerable<Models.SinhVien>> GetAllSinhVienAsync();
    Task<IEnumerable<Models.SinhVien>> GetAllSinhVienAsync(FilterSinhVienDTO filterSinhVienDto);
    Task<Models.SinhVien?> GetSinhVienByIdAsync(int id);
    Task<SinhVienDetailViewModel> GetSinhVienDetailViewModelAsync(int id);
    Task<Models.SinhVien> CreateSinhVienAsync(CreateSinhVienDTO createSinhVienDto);
    Task<Models.SinhVien> UpdateSinhVienAsync(Models.SinhVien updateSinhVien, int id);
    Task<bool> DeleteSinhVienAsync(int id);
}