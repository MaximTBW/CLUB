using CLUB.COMMON.ENTITY.InterfaceDB;
using CLUB.COMMON.ENTITY.Repositories;
using CLUB.CONTEXT.CONTRACTS.Enums;
using CLUB.CONTEXT.CONTRACTS.Models;
using CLUB.REPOSITORIES.Anchors;
using CLUB.REPOSITORIES.CONTRACTS.Interface;
using Microsoft.EntityFrameworkCore;

namespace CLUB.REPOSITORIES.Implementations
{
    public class OrderReadRepository : IOrderRRep, IReadRepositoryAnchor
    {
        private readonly IDbRead reader;

        public OrderReadRepository(IDbRead reader)
        {
            this.reader = reader;
        }

        Task<IReadOnlyCollection<Order>> IOrderRRep.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<Order>()
                .NotDeletedAt()
                .OrderBy(x => x.OrderTime)
                .ToReadOnlyCollectionAsync(cancellationToken);
        Task<Order?> IOrderRRep.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Order>()
                .NotDeletedAt()
                .ById(id)
                .FirstOrDefaultAsync(cancellationToken);

    }
}
