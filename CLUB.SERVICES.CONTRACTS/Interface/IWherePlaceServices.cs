
using CLUB.SERVICES.CONTRACTS.Models;
using CLUB.SERVICES.CONTRACTS.ModelRequest;
namespace CLUB.SERVICES.CONTRACTS.Interface
{
    public interface IWherePlaceService
    {
        /// <summary>
        /// Получить список всех <see cref="WherePlaceModel"/>
        /// </summary>
        Task<IEnumerable<WherePlaceModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="WherePlaceModel"/> по идентификатору
        /// </summary>
        Task<WherePlaceModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет нового клиента
        /// </summary>
        Task<WherePlaceModel> AddAsync(WherePlaceModelReq source, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующего клиента
        /// </summary>
        Task<WherePlaceModel> EditAsync(WherePlaceModelReq source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующего клиента
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
