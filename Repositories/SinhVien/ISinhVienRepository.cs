namespace CSharp_FinalExam.Repositories.SinhVien;

public interface ISinhVienRepository
{
    Task<IEnumerable<Models.SinhVien>> GetAllSinhVienAsync();
    Task<Models.SinhVien> CreateSinhVienAsync(Models.SinhVien sinhVien);
}