using CLUB.COMMON.ENTITY.InterfaceDB;
using CLUB.COMMON.ENTITY.Repositories;
using CLUB.CONTEXT.CONTRACTS.Enums;
using CLUB.CONTEXT.CONTRACTS.Models;
using CLUB.REPOSITORIES.Anchors;
using CLUB.REPOSITORIES.CONTRACTS.Interface;
using Microsoft.EntityFrameworkCore;

namespace CLUB.REPOSITORIES.Implementations
{
    public class ClientsReadRepository : IClientRRep, IReadRepositoryAnchor
    {
        private readonly IDbRead reader;

        public ClientsReadRepository(IDbRead reader)
        {
            this.reader = reader;
        }

        Task<IReadOnlyCollection<Client>> IClientRRep.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<Client>()
                .NotDeletedAt()
                .OrderBy(x => x.Nickname)
                .ToReadOnlyCollectionAsync(cancellationToken);
        Task<bool> IClientRRep.AnyByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Client>()
                .NotDeletedAt()
                .AnyAsync(x => x.Id == id, cancellationToken);

        Task<Client?> IClientRRep.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Client>()
                .NotDeletedAt()
                .ById(id)
                .FirstOrDefaultAsync(cancellationToken);

    }
}
