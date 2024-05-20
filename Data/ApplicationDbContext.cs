using CSharp_FinalExam.Configurations.ModelConfigurations;
using CSharp_FinalExam.Models;
using CSharp_FinalExam.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CSharp_FinalExam.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationIdentityUser>(options)
{
    public DbSet<SinhVien> SinhViens { get; set; }
    public DbSet<LopSinhHoat> LopSinhHoats { get; set; }
    public DbSet<LopHocPhan> LopHocPhans { get; set; }
    public DbSet<GiaoVien> GiaoViens { get; set; }
    public DbSet<Khoa> Khoas { get; set; }
    public DbSet<Truong> Truongs { get; set; }
    public DbSet<DangKyHocPhan> DangKyHocPhans { get; set; }
    public DbSet<SinhVienImage> SinhVienImages { get; set; }
    public DbSet<SinhVienTheSV> SinhVienTheSvs { get; set; }
    public DbSet<SinhVienCCCD> SinhVienCccds { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new DangKyHocPhanConfiguration());
        builder.ApplyConfiguration(new LopSinhHoatConfiguration());
    }
}