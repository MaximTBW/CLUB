using CLUB.CONTEXT.CONTRACTS.Enums;
using CLUB.CONTEXT.CONTRACTS.Models;

namespace CLUB.REPOSITORIES.CONTRACTS.Interface
{
    /// <summary>
    /// Репозиторий чтения <see cref="Client"/>
    /// </summary>
    public interface IClientRRep
    {
        /// <summary>
        /// Получить список всех <see cref="Client"/>
        /// </summary>
        Task<IReadOnlyCollection<Client>> GetAllAsync(CancellationToken cancellationToken);
        Task<bool> AnyByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Client"/> по идентификатору id
        /// </summary>
        Task<Client?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
