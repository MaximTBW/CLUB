using CLUB.COMMON.ENTITY.InterfaceDB;
using CLUB.CONTEXT.CONFIGURATIONS.Anchor;
using CLUB.CONTEXT.CONTRACTS.Interface;
using CLUB.CONTEXT.CONTRACTS.Models;
using Microsoft.EntityFrameworkCore;

namespace CLUB.CONTEXT
{
    /// <summary>
    /// Контекст работы с БД
    /// </summary>
    /// <remarks>
    /// 1) dotnet tool install --global dotnet-ef
    /// 2) dotnet tool update --global dotnet-ef
    /// 3) dotnet ef migrations add [name] --project CLUB.CONTEXT\CLUB.CONTEXT.csproj
    /// 4) dotnet ef database update --project CLUB.CONTEXT\CLUB.CONTEXT.csproj
    /// 5) dotnet ef database update [targetMigrationName] --CLUB.CONTEXT\CLUB.CONTEXT.csproj
    /// </remarks>
    /// 
    public class ClubContext : DbContext,
        IClubContext,
        IDbRead,
        IDbWriter,
        IUnitOfWork
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<FreeMen> FreeMens { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<WherePay> WherePays { get; set; }

        public DbSet<WherePlace> WherePlaces { get; set; }

        public ClubContext(DbContextOptions<ClubContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IContextConfigurationAnchor).Assembly);
        }

        IQueryable<TEntity> IDbRead.Read<TEntity>()
            => base.Set<TEntity>()
                .AsNoTracking()
                .AsQueryable();

        void IDbWriter.Add<TEntity>(TEntity entity)
            => base.Entry(entity).State = EntityState.Added;

        void IDbWriter.Update<TEntity>(TEntity entity)
            => base.Entry(entity).State = EntityState.Modified;

        void IDbWriter.Delete<TEntity>(TEntity entity)
            => base.Entry(entity).State = EntityState.Deleted;

        async Task<int> IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken)
        {
            var count = await base.SaveChangesAsync(cancellationToken);
            foreach (var entry in base.ChangeTracker.Entries().ToArray())
            {
                entry.State = EntityState.Detached;
            }
            return count;
        }
    }
}
