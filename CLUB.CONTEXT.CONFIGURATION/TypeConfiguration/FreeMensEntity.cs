using CLUB.CONTEXT.CONTRACTS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CLUB.CONTEXT.CONFIGURATIONS.TypeConfiguration
{
    public class FreeMensEntity : IEntityTypeConfiguration<FreeMen>
    {
        public void Configure(EntityTypeBuilder<FreeMen> builder)
        {
            builder.ToTable("FreeMens");
            builder.HasIdAsKey();
            builder.PropertyAuditConfiguration();

            builder.Property(x => x.Nickname).IsRequired().HasMaxLength(80);
            builder.Property(x => x.AboutHim).HasMaxLength(100);
            builder.Property(x => x.MainTongue).IsRequired().HasMaxLength(30);
            builder.Property(x => x.OpenTime).IsRequired();
            builder.Property(x => x.CloseTime).IsRequired();


        }
    }
}