using CLUB.COMMON.ENTITY.InterfaceDB;
using CLUB.COMMON.ENTITY.Repositories;
using CLUB.CONTEXT.CONTRACTS.Enums;
using CLUB.CONTEXT.CONTRACTS.Models;
using CLUB.REPOSITORIES.Anchors;
using CLUB.REPOSITORIES.CONTRACTS.Interface;
using Microsoft.EntityFrameworkCore;

namespace CLUB.REPOSITORIES.Implementations
{
    public class FreeMensReadRepository : IFreeMenRRep, IReadRepositoryAnchor
    {
        private readonly IDbRead reader;

        public FreeMensReadRepository(IDbRead reader)
        {
            this.reader = reader;
        }

        Task<IReadOnlyCollection<FreeMen>> IFreeMenRRep.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<FreeMen>()
                .NotDeletedAt()
                .OrderBy(x => x.Nickname)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<bool> IFreeMenRRep.AnyByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<FreeMen>()
                .NotDeletedAt()
                .AnyAsync(x => x.Id == id, cancellationToken);
        Task<FreeMen?> IFreeMenRRep.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<FreeMen>()
                .NotDeletedAt()
                .ById(id)
                .FirstOrDefaultAsync(cancellationToken);

    }
}
