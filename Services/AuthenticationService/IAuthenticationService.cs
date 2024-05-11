using CSharp_FinalExam.DTOs.IdentityDTOs;
using CSharp_FinalExam.Models.Authentication;
using CSharp_FinalExam.Models.Identity;

namespace CSharp_FinalExam.Services.AuthenticationService;

public interface IAuthenticationService
{
    Task<bool> AddUserRole(ApplicationIdentityUser user, string role);
    Task<(bool IsSuccess, ApplicationIdentityUser? User)> Login(UserLogin credentials);
    Task<(bool IsSuccess, ApplicationIdentityUser? User, IEnumerable<string>? errors)> RegisterUser(UserRegister user);
    Task<string> GenerateToken(ApplicationIdentityUser user, JwtConfiguration jwtConfig);
    void WriteAccessToken(string accessToken, bool isRememberMe);
}