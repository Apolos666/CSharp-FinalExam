using System.ComponentModel.DataAnnotations;

namespace CSharp_FinalExam.DTOs.LopSinhHoat;

public class CreateLopSinhHoatDTO
{
    [Required] public string TenLop { get; set; }
    [Required] public int HocKy { get; set; }
    [Required] public int GiaoVienChuNhiemId { get; set; }
    [Required] public int KhoaId { get; set; }
}