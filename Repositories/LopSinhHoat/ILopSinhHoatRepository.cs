using CSharp_FinalExam.DTOs.LopSinhHoat;

namespace CSharp_FinalExam.Repositories.LopSinhHoat;

public interface ILopSinhHoatRepository
{
    Task<IEnumerable<Models.LopSinhHoat>?> GetAllLopSinhHoatAsync();
    Task<Models.LopSinhHoat?> GetLopSinhHoatByIdAsync(int id);
    Task<Models.LopSinhHoat> CreateLopSinhHoatAsync(CreateLopSinhHoatDTO createLopSinhHoatDto);
    Task<Models.LopSinhHoat> UpdateLopSinhHoatAsync(Models.LopSinhHoat updateLopSinhHoat, int id);
    Task<bool> DeleteLopSinhHoatAsync(int id);
}