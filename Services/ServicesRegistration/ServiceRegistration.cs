using CSharp_FinalExam.Configurations;
using CSharp_FinalExam.Data;
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

        return service;
    }
}