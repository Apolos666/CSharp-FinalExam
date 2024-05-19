using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CSharp_FinalExam.Infrastructure.CustomValidation;

namespace CSharp_FinalExam.DTOs.LopHocPhanDTOs;

public class CreateLopHocPhanDTO
{
    [Required] [DisplayName("Tên lớp")] public string TenLop { get; set; }
    [Required] [DisplayName("Học kỳ")] public int HocKy { get; set; }
    [Required] [DisplayName("Số tín chỉ")] public int SoTinChi { get; set; }
    [Required] [DisplayName("Ngày bắt đầu")] [DateVietFormat] [DateLessThan("NgayKetThuc")] public DateTime NgayBatDau { get; set; } // Todo: Đảm bảo giá trị của NgayBatDau < NgayKetThuc
    [Required] [DisplayName("Ngày kết thúc")] [DateVietFormat] public DateTime NgayKetThuc { get; set; }
    [Required] public int GiaoVienId { get; set; }
}