using AutoMapper;
using CSharp_FinalExam.DTOs.SinhVien;
using CSharp_FinalExam.Models;

namespace CSharp_FinalExam.Configurations.AutoMapperConfig;

public class SinhVienAutoMapperConfig : Profile
{
    public SinhVienAutoMapperConfig()
    {
        CreateMap<CreateSinhVienDTO, SinhVien>();
        CreateMap<SinhVien, SinhVien>();
    }
}