using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CSharp_FinalExam.DTOs.LopSinhHoat;

public class CreateLopSinhHoatDTO
{
    [Required] [DisplayName("Tên lớp")] public string TenLop { get; set; }
    [Required] [DisplayName("Học kỳ")] public int HocKy { get; set; }
    [Required] [DisplayName("Giáo viên chủ nhiệm id")] public int GiaoVienChuNhiemId { get; set; }
    [Required] [DisplayName("Khoa id")] public int KhoaId { get; set; }
}