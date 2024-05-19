using CSharp_FinalExam.DTOs.DangKyHocPhanDTOs;
using CSharp_FinalExam.Models;

namespace CSharp_FinalExam.ViewModel;

public class DangKyHocPhanViewModel
{
    public IEnumerable<DangKyHocPhan> DangKyHocPhans { get; set; }
    public CreateDangKyHocPhanDTO CreateDangKyHocPhanDTO { get; set; }
}