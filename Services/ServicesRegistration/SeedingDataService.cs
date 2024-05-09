using CSharp_FinalExam.Utilities.TypeSafe;
using Microsoft.AspNetCore.Identity;

namespace CSharp_FinalExam.Services.ServicesRegistration;

public static class SeedingDataService
{
    public static async Task<IApplicationBuilder> SeedDataAsync(this WebApplication app)
    {
        // using var scope = app.Services.CreateScope();
        // var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        //
        // var adminRole = new IdentityRole(TypeSafe.Roles.Admin);
        //     
        // await roleManager.CreateAsync(adminRole);
        
        return app;
    }
}