using AutoMapper;

namespace CSharp_FinalExam.Configurations.AutoMapperConfig;

public class SinhVienAutoMapperConfig : Profile
{
    public SinhVienAutoMapperConfig()
    {
        CreateMap<DTOs.SinhVien.CreateSinhVienDTO, Models.SinhVien>();
    }
}