using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CSharp_FinalExam.Infrastructure.CustomValidation;

namespace CSharp_FinalExam.Models;

[Table("SinhViens")]
public class SinhVien
{
    [Key] public int Id { get; set; }
    [Required] [DisplayName("Mã sinh viên")] public string MaSinhVien { get; set; }

    [Required] 
    [DisplayName("Họ tên")]
    [StringLength(50, MinimumLength = 10, ErrorMessage = "Họ tên sinh viên phải có từ 10 đến 50 ký tự.")]
    public string HoTen { get; set; }

    [Required] [DisplayName("Ngày sinh")] [DateVietFormat] public DateTime NgaySinh { get; set; }
    [Required] [DisplayName("Số điện thoại")] [VietPhoneNumber] public string SoDienThoai { get; set; }
    [Required] [EmailAddress] public string Email { get; set; }
    [Required] [DisplayName("Địa chỉ")] public string DiaChi { get; set; }
    [Required] [DisplayName("Giới tính")] public GioiTinhEnum GioiTinh { get; set; }

    [Required]
    [Range(0, 4, ErrorMessage = "GPA phải từ 0 đến 4.")]
    public double GPA { get; set; }

    [Required] [DisplayName("Lớp sinh hoạt")] [ForeignKey("LopSinhHoat")] public int LopSinhHoatId { get; set; }
    public LopSinhHoat? LopSinhHoat { get; set; }
    public ICollection<DangKyHocPhan>? DangKyHocPhans { get; set; }
}