using CSharp_FinalExam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSharp_FinalExam.Configurations.ModelConfigurations;

public class LopSinhHoatConfiguration : IEntityTypeConfiguration<LopSinhHoat>
{
    public void Configure(EntityTypeBuilder<LopSinhHoat> builder)
    {
        builder.HasOne(lsh => lsh.Khoa)
            .WithMany(k => k.LopSinhHoats)
            .HasForeignKey(lsh => lsh.KhoaId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}