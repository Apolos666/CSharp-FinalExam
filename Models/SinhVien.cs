using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CSharp_FinalExam.Infrastructure.CustomValidation;

namespace CSharp_FinalExam.Models;

[Table("SinhViens")]
public class SinhVien
{
    [Key] public int Id { get; set; }
    [Required] public string MaSinhVien { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 10, ErrorMessage = "Họ tên sinh viên phải có từ 10 đến 50 ký tự.")]
    public string HoTen { get; set; }

    [Required] [DateVietFormat] public DateTime NgaySinh { get; set; }
    [Required] [VietPhoneNumber] public string SoDienThoai { get; set; }
    [Required] [EmailAddress] public string Email { get; set; }
    [Required] public string DiaChi { get; set; }
    [Required] public GioiTinhEnum GioiTinh { get; set; }

    [Required]
    [Range(0, 4, ErrorMessage = "GPA phải từ 0 đến 4.")]
    public double GPA { get; set; }

    [Required] [ForeignKey("LopSinhHoat")] public int LopSinhHoatId { get; set; }
    public LopSinhHoat? LopSinhHoat { get; set; }
    public ICollection<DangKyHocPhan>? DangKyHocPhans { get; set; }
}