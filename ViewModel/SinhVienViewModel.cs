using CSharp_FinalExam.DTOs.SinhVien;
using CSharp_FinalExam.Models;

namespace CSharp_FinalExam.ViewModel;

public class SinhVienViewModel
{
    public IEnumerable<SinhVien> SinhViens { get; set; }
    public CreateSinhVienDTO CreateSinhVienDTO { get; set; }
    public AddSinhVienImageDTO? AddSinhVienImageDto { get; set; }
    public FilterSinhVienDTO? FilterSinhVienDto { get; set; }
}