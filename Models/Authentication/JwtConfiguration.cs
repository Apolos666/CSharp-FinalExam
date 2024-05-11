namespace CSharp_FinalExam.Models.Authentication;

public class JwtConfiguration
{
    public string Secret { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int ExpiresDay { get; set; }
}