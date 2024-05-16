using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CSharp_FinalExam.Infrastructure.CustomValidation;

namespace CSharp_FinalExam.Models;

[Table("GiaoViens")]
public class GiaoVien
{
    [Key] public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 10, ErrorMessage = "Họ tên sinh viên phải có từ 10 đến 50 ký tự.")]
    public string HoTen { get; set; }

    [Required] [DateVietFormat] public DateTime NgaySinh { get; set; }
    [Required] [VietPhoneNumber] public string SoDienThoai { get; set; }
    [Required] [EmailAddress] public string Email { get; set; }
    [Required] public string DiaChi { get; set; }
    [Required] public GioiTinhEnum GioiTinh { get; set; }
    [Required] [ForeignKey("Khoa")] public int KhoaId { get; set; }
    public Khoa Khoa { get; set; }
}