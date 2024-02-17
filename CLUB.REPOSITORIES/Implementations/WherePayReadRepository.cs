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
    public class WherePayReadRepository : IWherePayRRep, IReadRepositoryAnchor
    {
        private readonly IDbRead reader;

        public WherePayReadRepository(IDbRead reader)
        {
            this.reader = reader;
        }

        Task<IReadOnlyCollection<WherePay>> IWherePayRRep.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<WherePay>()
                .NotDeletedAt()
                .OrderBy(x => x.BankName)
                .ToReadOnlyCollectionAsync(cancellationToken);
        Task<bool> IWherePayRRep.AnyByIdAsync(Guid? id, CancellationToken cancellationToken)
            => reader.Read<WherePay>()
                .NotDeletedAt()
                .AnyAsync(x => (x.Id == id) || (id == Guid.Empty) || (id == null), cancellationToken);

        Task<WherePay?> IWherePayRRep.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<WherePay>()
                .NotDeletedAt()
                .ById(id)
                .FirstOrDefaultAsync(cancellationToken);

    }
}
