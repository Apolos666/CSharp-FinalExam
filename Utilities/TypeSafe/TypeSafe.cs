namespace CSharp_FinalExam.Utilities.TypeSafe;

public class TypeSafe
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string User = "User";
        public const string Contributor = "Contributor";
    }
    
    public static class Policies
    {
        public const string AdminRequirement = "Admin";
    }

    public static class CookiesName
    {
        public static string Token = "ACCESS-TOKEN";
    }
}