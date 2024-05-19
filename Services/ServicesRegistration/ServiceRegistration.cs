using CSharp_FinalExam.Configurations;
using CSharp_FinalExam.Data;
using CSharp_FinalExam.Repositories;
using CSharp_FinalExam.Repositories.GiaoVien;
using CSharp_FinalExam.Repositories.Khoa;
using CSharp_FinalExam.Repositories.LopHocPhan;
using CSharp_FinalExam.Repositories.LopSinhHoat;
using CSharp_FinalExam.Repositories.SinhVien;
using CSharp_FinalExam.Services.AuthenticationService;
using CSharp_FinalExam.Services.AzureServices.BlobStorage;
using Microsoft.EntityFrameworkCore;

namespace CSharp_FinalExam.Services.ServicesRegistration;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationRepositories(this IServiceCollection service,
        DatabaseConfig databaseConfig)
    {
        service.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(databaseConfig.ConnectionString);
            options.EnableDetailedErrors(databaseConfig.DetailedErrors);
            options.EnableSensitiveDataLogging(databaseConfig.SensitiveDataLogging);
        });

        service.AddScoped<ISinhVienRepository, SinhVienRepository>()
            .AddScoped<IGiaoVienRepository, GiaoVienRepository>()
            .AddScoped<ILopSinhHoatRepository, LopSinhHoatRepository>()
            .AddScoped<IKhoaRepository, KhoaRepository>()
            .AddScoped<ILopHocPhanRepository, LopHocPhanRepository>()
            .AddScoped<IDangKyHocPhanRepository, DangKyHocPhanRepository>()
            .AddScoped<ISinhVienImageRepository, SinhVienImageRepository>();

        return service;
    }
    
    public static IServiceCollection AddApplicationServices(this IServiceCollection service)
    {
        service.AddScoped<IAuthenticationService, AuthenticationService.AuthenticationService>();

        service.AddScoped<ISinhVienImageService, SinhVienImageService>();
        
        return service;
    }
    
    public static IServiceCollection AddThirdPartyServices(this IServiceCollection service)
    {
        service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        service.AddAzureServices();
        
        return service;
    }
}