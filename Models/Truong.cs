using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharp_FinalExam.Models;

[Table("Truong")]
public class Truong
{
    [Key] public int Id { get; set; }
    [Required] public string TenTruong { get; set; }
    public ICollection<Khoa> Khoas { get; set; }
}