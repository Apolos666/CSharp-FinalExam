using AutoMapper;
using CSharp_FinalExam.DTOs.KhoaDTOs;
using CSharp_FinalExam.Models;

namespace CSharp_FinalExam.Configurations.AutoMapperConfig;

public class KhoaAutoMapperConfig : Profile
{
    public KhoaAutoMapperConfig()
    {
        CreateMap<CreateKhoaDTO, Khoa>();
        CreateMap<Khoa, Khoa>();
    }
}