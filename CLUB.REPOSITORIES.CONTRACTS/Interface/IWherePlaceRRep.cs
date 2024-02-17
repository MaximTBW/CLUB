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
    /// Репозиторий чтения <see cref="WherePlace"/>
    /// </summary>
    public interface IWherePlaceRRep
    {
        /// <summary>
        /// Получить список всех <see cref="Client"/>
        /// </summary>
        Task<IReadOnlyCollection<WherePlace>> GetAllAsync(CancellationToken cancellationToken);

        Task<bool> AnyByIdAsync(Guid? id, CancellationToken cancellationToken);
        /// <summary>
        /// Получить <see cref="Client"/> по идентификатору id
        /// </summary>
        Task<WherePlace?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
