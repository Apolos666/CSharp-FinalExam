using CSharp_FinalExam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSharp_FinalExam.Configurations.ModelConfigurations;

public class DangKyHocPhanConfiguration : IEntityTypeConfiguration<DangKyHocPhan>
{
    public void Configure(EntityTypeBuilder<DangKyHocPhan> builder)
    {
        builder.HasKey(dkhp => new { dkhp.Id, dkhp.LopHocPhanId, dkhp.SinhVienId });
        builder.HasIndex(dkhp => new { dkhp.LopHocPhanId, dkhp.SinhVienId }).IsUnique();
        builder.Property(dkhp => dkhp.Id).ValueGeneratedOnAdd();

        builder.HasOne(dkhp => dkhp.SinhVien)
            .WithMany(sv => sv.DangKyHocPhans)
            .HasForeignKey(dkhp => dkhp.SinhVienId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(dkhp => dkhp.LopHocPhan)
            .WithMany(lhp => lhp.DangKyHocPhans)
            .HasForeignKey(dkhp => dkhp.LopHocPhanId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}