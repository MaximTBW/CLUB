using CLUB.COMMON.ENTITY.InterfaceDB;
using CLUB.COMMON.ENTITY.Repositories;
using CLUB.CONTEXT.CONTRACTS.Models;
using CLUB.REPOSITORIES.Anchors;
using CLUB.REPOSITORIES.CONTRACTS.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLUB.REPOSITORIES.Implementations
{
    public class WherePlaceReadRepository : IWherePlaceRRep, IReadRepositoryAnchor
    {
        private readonly IDbRead reader;

        public WherePlaceReadRepository(IDbRead reader)
        {
            this.reader = reader;
        }

        Task<IReadOnlyCollection<WherePlace>> IWherePlaceRRep.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<WherePlace>()
                .NotDeletedAt()
                .OrderBy(x => x.PlaceName)
                .ToReadOnlyCollectionAsync(cancellationToken);
        Task<bool> IWherePlaceRRep.AnyByIdAsync(Guid? id, CancellationToken cancellationToken)
            => reader.Read<WherePlace>()
                .NotDeletedAt()
                .AnyAsync(x => (x.Id == id) || (id == Guid.Empty) || (id == null), cancellationToken);

        Task<WherePlace?> IWherePlaceRRep.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<WherePlace>()
                .NotDeletedAt()
                .ById(id)
                .FirstOrDefaultAsync(cancellationToken);

    }
}
