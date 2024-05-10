using CSharp_FinalExam.Configurations;
using CSharp_FinalExam.Models.Authentication;
using CSharp_FinalExam.Services.ServicesRegistration;

var builder = WebApplication.CreateBuilder(args);

var dbConfig = new DatabaseConfig();
builder.Configuration.Bind("DatabaseConfig", dbConfig);

builder.Services.AddApplicationRepositories(dbConfig);
builder.Services.AddApplicationServices();
builder.Services.AddApplicationIdentity();

var jwtConfig = new JwtConfiguration();
builder.Configuration.Bind("JwtConfig", jwtConfig);
builder.Services.AddSingleton(jwtConfig);
builder.Services.AddApplicationJwtAuthentication(jwtConfig);

builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

await app.SeedDataAsync();

app.Run();
