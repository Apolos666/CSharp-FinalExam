using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharp_FinalExam.Models;

public class SinhVienImage
{
    [Key] public int Id { get; set; }
    [Required] public string ImageUrl { get; set; }
    [Required] [ForeignKey("SinhVien")] public int SinhVienId { get; set; }
    public SinhVien? SinhVien { get; set; }
}