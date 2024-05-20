using CSharp_FinalExam.DTOs.LopSinhHoat;
using CSharp_FinalExam.Models;

namespace CSharp_FinalExam.ViewModel;

public class LopSinhHoatViewModel
{
    public IEnumerable<LopSinhHoat> LopSinhHoats { get; set; }
    public CreateLopSinhHoatDTO CreateLopSinhHoatDTO { get; set; }
}