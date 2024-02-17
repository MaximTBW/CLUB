
using CLUB.SERVICES.CONTRACTS.Models;
using CLUB.SERVICES.CONTRACTS.ModelRequest;

namespace CLUB.SERVICES.CONTRACTS.Interface
{
    public interface IFreeMenService
    {
        /// <summary>
        /// Получить список всех <see cref="FreeMen"/>
        /// </summary>
        Task<IEnumerable<FreeMen>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="FreeMen"/> по идентификатору
        /// </summary>
        Task<FreeMen?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет нового клиента
        /// </summary>
        Task<FreeMen> AddAsync(FreeMenReq source, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующего клиента
        /// </summary>
        Task<FreeMen> EditAsync(FreeMenReq source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующего клиента
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
