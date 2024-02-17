using CLUB.CONTEXT.CONTRACTS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CLUB.CONTEXT.CONFIGURATIONS.TypeConfiguration
{
    public class ClientsEntity : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("TClient");
            builder.HasIdAsKey();
            builder.PropertyAuditConfiguration();

            builder.Property(x => x.Nickname).IsRequired().HasMaxLength(80);
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(20);
            builder.Property(x => x.AboutHim).HasMaxLength(100);

            builder
                .HasMany(x => x.Order)
                .WithOne(x => x.Client)
                .HasForeignKey(x => x.ClientId);

            builder.HasIndex(x => x.Email)
                .HasFilter($"{nameof(Client.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(Client)}_" +
                                 $"{nameof(Client.Email)}");

            builder.HasIndex(x => x.PhoneNumber)
                .HasFilter($"{nameof(Client.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(Client)}_" +
                                 $"{nameof(Client.PhoneNumber)}");
        }
    }
}