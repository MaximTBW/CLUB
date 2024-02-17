using CLUB.CONTEXT.CONTRACTS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CLUB.CONTEXT.CONFIGURATIONS.TypeConfiguration
{
    public class WherePaysEntity : IEntityTypeConfiguration<WherePay>
    {
        public void Configure(EntityTypeBuilder<WherePay> builder)
        {
            builder.ToTable("WherePays");
            builder.HasIdAsKey();
            builder.PropertyAuditConfiguration();

            builder.Property(x => x.BankName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Nickname).IsRequired().HasMaxLength(70);
            builder.Property(x => x.CardNumber).IsRequired().HasMaxLength(30);


        }
    }
}