using CSharp_FinalExam.Models;

namespace CSharp_FinalExam.ViewModel;

public class SinhVienDetailViewModel
{
    public SinhVien SinhVien { get; set; }
    public List<string> SinhVienImage64s { get; set; }
    public List<string> SinhVienThe64s { get; set; }
    public List<string> SinhVienCCCD64s { get; set; }
}