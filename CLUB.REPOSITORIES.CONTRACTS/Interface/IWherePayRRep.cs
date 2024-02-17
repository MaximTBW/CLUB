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
    /// Репозиторий чтения <see cref="WherePay"/>
    /// </summary>
    public interface IWherePayRRep
    {
        /// <summary>
        /// Получить список всех <see cref="Client"/>
        /// </summary>
        Task<IReadOnlyCollection<WherePay>> GetAllAsync(CancellationToken cancellationToken);
        Task<bool> AnyByIdAsync(Guid? id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Client"/> по идентификатору id
        /// </summary>
        Task<WherePay?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
