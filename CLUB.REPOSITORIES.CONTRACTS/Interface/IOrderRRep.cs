using CLUB.CONTEXT.CONTRACTS.Enums;
using CLUB.CONTEXT.CONTRACTS.Models;

namespace CLUB.REPOSITORIES.CONTRACTS.Interface
{
    /// <summary>
    /// Репозиторий чтения <see cref="Order"/>
    /// </summary>
    public interface IOrderRRep
    {
        /// <summary>
        /// Получить список всех <see cref="Order"/>
        /// </summary>
        Task<IReadOnlyCollection<Order>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Order"/> по идентификатору id
        /// </summary>
        Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
