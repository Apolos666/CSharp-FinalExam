using AutoMapper;
using CSharp_FinalExam.DTOs.IdentityDTOs;
using CSharp_FinalExam.Models.Identity;

namespace CSharp_FinalExam.Configurations.AutoMapperConfig;

public class UserAutoMapperConfig : Profile
{
    public UserAutoMapperConfig()
    {
        CreateMap<ApplicationIdentityUser, UserView>();
    }
}