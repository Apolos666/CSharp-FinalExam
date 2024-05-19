using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CSharp_FinalExam.Infrastructure.CustomValidation;

namespace CSharp_FinalExam.DTOs.DangKyHocPhanDTOs;

public class CreateDangKyHocPhanDTO
{
    [Required] [DisplayName("Sinh viên id")] public int SinhVienId { get; set; }
    [Required] [DisplayName("Lớp học phần id")] public int LopHocPhanId { get; set; }
    [DisplayName("Ngày đăng ký")] [DateVietFormat] public DateTime? NgayDangKy { get; set; } = DateTime.Now;
}