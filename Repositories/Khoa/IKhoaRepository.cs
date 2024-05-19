using CSharp_FinalExam.DTOs.KhoaDTOs;

namespace CSharp_FinalExam.Repositories.Khoa;

public interface IKhoaRepository
{
    Task<IEnumerable<Models.Khoa>> GetAllKhoaAsync();
    Task<Models.Khoa?> GetKhoaByIdAsync(int id);
    Task<Models.Khoa> CreateKhoaAsync(CreateKhoaDTO createKhoaDto);
    Task<Models.Khoa> UpdateKhoaAsync(Models.Khoa updateKhoa, int id);
    Task<bool> DeleteKhoaAsync(int id);
}