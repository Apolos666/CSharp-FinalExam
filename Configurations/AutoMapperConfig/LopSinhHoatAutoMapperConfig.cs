using AutoMapper;
using CSharp_FinalExam.DTOs.LopSinhHoat;
using CSharp_FinalExam.Models;

namespace CSharp_FinalExam.Configurations.AutoMapperConfig;

public class LopSinhHoatAutoMapperConfig : Profile
{
    public LopSinhHoatAutoMapperConfig()
    {
        CreateMap<CreateLopSinhHoatDTO, LopSinhHoat>();
        CreateMap<LopSinhHoat, LopSinhHoat>();
    }
}