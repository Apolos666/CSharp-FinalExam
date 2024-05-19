using CSharp_FinalExam.DTOs.LopHocPhanDTOs;

namespace CSharp_FinalExam.Repositories.LopHocPhan;

public interface ILopHocPhanRepository
{
    Task<IEnumerable<Models.LopHocPhan>> GetAllLopHocPhanAsync();
    Task<Models.LopHocPhan?> GetLopHocPhanByIdAsync(int id);
    Task<Models.LopHocPhan> CreateLopHocPhanAsync(CreateLopHocPhanDTO createLopHocPhanDto);
    Task<Models.LopHocPhan> UpdateLopHocPhanAsync(Models.LopHocPhan updateLopHocPhan, int id);
    Task<bool> DeleteLopHocPhanAsync(int id);
}