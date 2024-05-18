using AutoMapper;
using CSharp_FinalExam.DTOs.GiaoVien;
using CSharp_FinalExam.Models;

namespace CSharp_FinalExam.Configurations.AutoMapperConfig;

public class GiaoVienAutoMapperConfig : Profile
{
    public GiaoVienAutoMapperConfig()
    {
        CreateMap<CreateGiaoVienDTO, GiaoVien>();
        CreateMap<GiaoVien, GiaoVien>();
    }
}