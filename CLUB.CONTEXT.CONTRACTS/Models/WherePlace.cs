using CLUB.COMMON.ENTITY;
using CLUB.COMMON.ENTITY.EntityInterface;

namespace CLUB.CONTEXT.CONTRACTS.Models
{
    /// <summary>
    /// Место бронирования
    /// </summary>
    public class WherePlace : BaseAuditEntity
    {
        /// <summary>
        /// Адрес
        /// </summary>
        public string Adress { get; set; }

        /// <summary>
        /// Название места
        /// </summary>
        public string PlaceName { get; set; }

        /// <summary>
        /// Со скольки открыто
        /// </summary>
        public DateTimeOffset OpenTime { get; set; }

        /// <summary>
        /// До скольки открыто
        /// </summary>
        public DateTimeOffset CloseTime { get; set; }

        /// <summary>
        /// Навигация для связи 1 ко многим
        /// </summary>
        public ICollection<Order> Order { get; set; }

    }
}
