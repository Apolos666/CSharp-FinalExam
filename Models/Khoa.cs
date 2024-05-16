using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CSharp_FinalExam.Infrastructure.CustomValidation;

namespace CSharp_FinalExam.Models;

[Table("Khoas")]
public class Khoa
{
    [Key] public int Id { get; set; }
    [Required] public string TenKhoa { get; set; }
    [Required] [DateVietFormat] public DateTime NgayThanhLap { get; set; }
    [Required] [ForeignKey("Truong")] public int TruongId { get; set; }
    public Truong Truong { get; set; }
    public ICollection<GiaoVien> GiaoViens { get; set; }
    public ICollection<LopSinhHoat> LopSinhHoats { get; set; }
}