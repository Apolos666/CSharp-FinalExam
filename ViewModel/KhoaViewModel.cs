using CSharp_FinalExam.DTOs.KhoaDTOs;
using CSharp_FinalExam.Models;

namespace CSharp_FinalExam.ViewModel;

public class KhoaViewModel
{
    public IEnumerable<Khoa> Khoas { get; set; }
    public CreateKhoaDTO CreateKhoaDTO { get; set; }
}