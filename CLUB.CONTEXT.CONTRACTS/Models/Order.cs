using CLUB.COMMON.ENTITY;
using CLUB.COMMON.ENTITY.EntityInterface;

namespace CLUB.CONTEXT.CONTRACTS.Models
{
    /// <summary>
    /// Бронирование
    /// </summary>
    public class Order : BaseAuditEntity
    {
        /// <summary>
        /// Номер свободного мужчины
        /// </summary>
        public Guid FreeMenId { get; set; }

        /// <summary>
        /// Cвязь один ко многим
        /// </summary>
        public FreeMen FreeMen { get; set; }

        /// <summary>
        /// Номер услуги
        /// </summary>
        public Guid ServiceId { get; set; }

        /// <summary>
        /// Cвязь один ко многим
        /// </summary>
        public Service Service { get; set; }

        /// <summary>
        /// Номер клиента
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// Cвязь один ко многим
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Номер места
        /// </summary>
        public Guid? PlaceId { get; set; }

        /// <summary>
        /// Cвязь один ко многим
        /// </summary>
        public WherePlace? WherePlace { get; set; }

        /// <summary>
        /// Номер оплаты
        /// </summary>
        public Guid? PayId { get; set; }

        /// <summary>
        /// Cвязь один ко многим
        /// </summary>
        public WherePay? WherePay { get; set; }

        /// <summary>
        /// Время заказа
        /// </summary>
        public DateTimeOffset OrderTime { get; set; } = DateTimeOffset.UtcNow;

        /// <summary>
        /// Комментарий к заказу
        /// </summary>
        public string? Comment { get; set; } = string.Empty;

    }
}
