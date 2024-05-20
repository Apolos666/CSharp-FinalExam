using Microsoft.AspNetCore.Identity;

namespace CSharp_FinalExam.Models.Identity;

public class ApplicationIdentityUser : IdentityUser
{
    public string? ProfileImageUrl { get; set; }
}