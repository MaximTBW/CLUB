
using CLUB.SERVICES.CONTRACTS.Models;
using CLUB.SERVICES.CONTRACTS.ModelRequest;
namespace CLUB.SERVICES.CONTRACTS.Interface
{
    public interface IOrderService
    {
        /// <summary>
        /// Получить список всех <see cref="Order"/>
        /// </summary>
        Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Order"/> по идентификатору
        /// </summary>
        Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет нового клиента
        /// </summary>
        Task<Order> AddAsync(OrderReq source, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующего клиента
        /// </summary>
        Task<Order> EditAsync(OrderReq source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующего клиента
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
