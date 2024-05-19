using CSharp_FinalExam.DTOs.LopHocPhanDTOs;
using CSharp_FinalExam.Models;

namespace CSharp_FinalExam.ViewModel;

public class LopHocPhanViewModel
{
    public IEnumerable<LopHocPhan> LopHocPhans { get; set; }
    public CreateLopHocPhanDTO CreateLopHocPhanDTO { get; set; }
}