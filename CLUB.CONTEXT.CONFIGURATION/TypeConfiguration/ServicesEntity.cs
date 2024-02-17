using CLUB.CONTEXT.CONTRACTS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CLUB.CONTEXT.CONFIGURATIONS.TypeConfiguration
{
    public class ServicesEntity: IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");
            builder.HasIdAsKey();
            builder.PropertyAuditConfiguration();

            builder.Property(x => x.ServiceName).IsRequired();
            builder.Property(x => x.AboutService).IsRequired().HasMaxLength(70);
            builder.Property(x => x.Price).IsRequired();


        }
    }
}