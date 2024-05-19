using CSharp_FinalExam.DTOs.DangKyHocPhanDTOs;

namespace CSharp_FinalExam.Repositories;

public interface IDangKyHocPhanRepository
{
    Task<IEnumerable<Models.DangKyHocPhan>> GetAllDangKyHocPhanAsync();
    Task<Models.DangKyHocPhan?> GetDangKyHocPhanByIdAsync(int id);
    Task<Models.DangKyHocPhan> CreateDangKyHocPhanAsync(CreateDangKyHocPhanDTO createDangKyHocPhanDto);
    Task<Models.DangKyHocPhan> UpdateDangKyHocPhanAsync(Models.DangKyHocPhan updateDangKyHocPhan, int id);
    Task<bool> DeleteDangKyHocPhanAsync(int id);
}