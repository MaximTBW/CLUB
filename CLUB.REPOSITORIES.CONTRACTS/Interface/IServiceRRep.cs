using CLUB.CONTEXT.CONTRACTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CLUB.REPOSITORIES.CONTRACTS.Interface
{
    /// <summary>
    /// Репозиторий чтения <see cref="Service"/>
    /// </summary>
    public interface IServiceRRep
    {
        /// <summary>
        /// Получить список всех <see cref="Client"/>
        /// </summary>
        Task<IReadOnlyCollection<Service>> GetAllAsync(CancellationToken cancellationToken);
        Task<bool> AnyByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Client"/> по идентификатору id
        /// </summary>
        Task<Service?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
