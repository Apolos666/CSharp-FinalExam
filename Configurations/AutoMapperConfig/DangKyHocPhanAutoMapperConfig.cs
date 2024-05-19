using AutoMapper;
using CSharp_FinalExam.DTOs.DangKyHocPhanDTOs;
using CSharp_FinalExam.Models;

namespace CSharp_FinalExam.Configurations.AutoMapperConfig;

public class DangKyHocPhanAutoMapperConfig : Profile
{
    public DangKyHocPhanAutoMapperConfig()
    {
        CreateMap<CreateDangKyHocPhanDTO, DangKyHocPhan>();
        CreateMap<DangKyHocPhan, DangKyHocPhan>();
    }
}