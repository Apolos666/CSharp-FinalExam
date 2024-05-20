using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CSharp_FinalExam.DTOs.SinhVien;

public class AddSinhVienImageDTO
{
    [Required] [DisplayName("Sinh Viên id")] public int SinhVienId { get; set; }
    [Required] [DisplayName("Image file")] public IFormFile ImageFile { get; set; }
}