using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CSharp_FinalExam.Infrastructure.CustomValidation;

namespace CSharp_FinalExam.Models;

[Table("LopHocPhans")]
public class LopHocPhan
{
    [Key] public int Id { get; set; }
    [Required] public string TenLop { get; set; }
    [Required] public int HocKy { get; set; }
    [Required] public int SoTinChi { get; set; }
    [Required] [DateVietFormat] public DateTime NgayBatDau { get; set; }
    [Required] [DateVietFormat] public DateTime NgayKetThuc { get; set; }
    [Required] [ForeignKey("GiaoVien")] public int GiaoVienId { get; set; }
    public GiaoVien GiaoVien { get; set; }
    public ICollection<DangKyHocPhan>? DangKyHocPhans { get; set; }
}