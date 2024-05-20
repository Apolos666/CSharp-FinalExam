using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CSharp_FinalExam.Infrastructure.CustomValidation;

namespace CSharp_FinalExam.DTOs.KhoaDTOs;

public class CreateKhoaDTO
{
    [Required] [DisplayName("Tên khoa")] public string TenKhoa { get; set; }
    [Required] [DisplayName("Ngày thành lập")] [DateVietFormat] public DateTime NgayThanhLap { get; set; }
    [Required] [DisplayName("Trường id")] public int TruongId { get; set; }
}