using CLUB.COMMON.ENTITY.InterfaceDB;
using CLUB.COMMON.ENTITY.Repositories;
using CLUB.CONTEXT.CONTRACTS.Models;
using CLUB.REPOSITORIES.Anchors;
using CLUB.REPOSITORIES.CONTRACTS.Interface;
using Microsoft.EntityFrameworkCore;

namespace CLUB.REPOSITORIES.Implementations
{
    public class ServiceReadRepository : IServiceRRep, IReadRepositoryAnchor
    {
        private readonly IDbRead reader;

        public ServiceReadRepository(IDbRead reader)
        {
            this.reader = reader;
        }

        Task<IReadOnlyCollection<Service>> IServiceRRep.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<Service>()
                .NotDeletedAt()
                .OrderBy(x => x.ServiceName)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<bool> IServiceRRep.AnyByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Service>()
                .NotDeletedAt()
                .AnyAsync(x => x.Id == id, cancellationToken);
        Task<Service?> IServiceRRep.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Service>()
                .NotDeletedAt()
                .ById(id)
                .FirstOrDefaultAsync(cancellationToken);

    }
}
