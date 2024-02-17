using CLUB.CONTEXT.CONTRACTS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CLUB.CONTEXT.CONFIGURATIONS.TypeConfiguration
{
    public class OrdersEntity: IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasIdAsKey();
            builder.PropertyAuditConfiguration();

            builder.Property(x => x.ClientId).IsRequired();
            builder.Property(x => x.ServiceId).IsRequired();
            builder.Property(x => x.FreeMenId).IsRequired();
            builder.Property(x => x.OrderTime).IsRequired();
            builder.Property(x => x.Comment).HasMaxLength(100);


        }
    }
}