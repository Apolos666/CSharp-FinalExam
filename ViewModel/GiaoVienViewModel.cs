using CSharp_FinalExam.DTOs.GiaoVien;
using CSharp_FinalExam.Models;

namespace CSharp_FinalExam.ViewModel;

public class GiaoVienViewModel
{
    public IEnumerable<GiaoVien> GiaoViens { get; set; }
    public CreateGiaoVienDTO CreateGiaoVienDTO { get; set; }
}