using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharp_FinalExam.Models;

[Table("LopSinhHoats")]
public class LopSinhHoat
{
    [Key] public int Id { get; set; }
    [Required] public string TenLop { get; set; }
    [Required] public int HocKy { get; set; }
    [Required] [ForeignKey("GiaoVien")] public int GiaoVienChuNhiemId { get; set; }
    public GiaoVien? GiaoVien { get; set; }
    [Required] [ForeignKey("Khoa")] public int KhoaId { get; set; }
    public Khoa? Khoa { get; set; }
    public ICollection<SinhVien>? SinhViens { get; set; }
}