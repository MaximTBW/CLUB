using CLUB.CONTEXT.CONTRACTS.Enums;
using CLUB.CONTEXT.CONTRACTS.Models;
using System.Reflection.PortableExecutable;

namespace CLUB.REPOSITORIES.CONTRACTS.Interface
{
    /// <summary>
    /// Репозиторий чтения <see cref="FreeMen"/>
    /// </summary>
    public interface IFreeMenRRep
    {
        /// <summary>
        /// Получить список всех <see cref="FreeMen"/>
        /// </summary>
        Task<IReadOnlyCollection<FreeMen>> GetAllAsync(CancellationToken cancellationToken);

        Task<bool> AnyByIdAsync(Guid id, CancellationToken cancellationToken);
        /// <summary>
        /// Получить <see cref="FreeMen"/> по идентификатору id
        /// </summary>
        Task<FreeMen?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
