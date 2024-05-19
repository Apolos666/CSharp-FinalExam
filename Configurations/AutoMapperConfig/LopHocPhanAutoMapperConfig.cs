using AutoMapper;
using CSharp_FinalExam.DTOs.LopHocPhanDTOs;
using CSharp_FinalExam.Models;

namespace CSharp_FinalExam.Configurations.AutoMapperConfig;

public class LopHocPhanAutoMapperConfig : Profile
{
    public LopHocPhanAutoMapperConfig()
    {
        CreateMap<CreateLopHocPhanDTO, LopHocPhan>();
        CreateMap<LopHocPhan, LopHocPhan>();
    }
}