
using CLUB.SERVICES.CONTRACTS.Models;
using CLUB.SERVICES.CONTRACTS.ModelRequest;

namespace CLUB.SERVICES.CONTRACTS.Interface
{
    public interface IWherePayService
    {
        /// <summary>
        /// Получить список всех <see cref="WherePayModel"/>
        /// </summary>
        Task<IEnumerable<WherePayModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="WherePayModel"/> по идентификатору
        /// </summary>
        Task<WherePayModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет нового клиента
        /// </summary>
        Task<WherePayModel> AddAsync(WherePayModelReq source, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующего клиента
        /// </summary>
        Task<WherePayModel> EditAsync(WherePayModelReq source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующего клиента
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
