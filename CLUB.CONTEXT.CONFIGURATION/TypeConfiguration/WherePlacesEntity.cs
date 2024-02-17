using CLUB.CONTEXT.CONTRACTS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CLUB.CONTEXT.CONFIGURATIONS.TypeConfiguration
{
    public class WherePlacesEntity : IEntityTypeConfiguration<WherePlace>
    {
        public void Configure(EntityTypeBuilder<WherePlace> builder)
        {
            builder.ToTable("WherePlaces");
            builder.HasIdAsKey();
            builder.PropertyAuditConfiguration();

            builder.Property(x => x.Adress).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PlaceName).IsRequired().HasMaxLength(40);
            builder.Property(x => x.OpenTime).IsRequired();
            builder.Property(x => x.CloseTime).IsRequired();


        }
    }
}