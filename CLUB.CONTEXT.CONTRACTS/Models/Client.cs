using CLUB.COMMON.ENTITY;
using CLUB.COMMON.ENTITY.EntityInterface;

namespace CLUB.CONTEXT.CONTRACTS.Models
{
    /// <summary>
    /// Клиенты
    /// </summary>
    public class Client : BaseAuditEntity
    {
        /// <summary>
        /// ФИО Клиента
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// E-почта
        /// </summary>
        public string? Email { get; set; } = string.Empty;

        /// <summary>
        /// О клиенте
        /// </summary>
        public string AboutHim { get; set; }

        /// <summary>
        /// Навигация для связи 1 ко многим
        /// </summary>
        public ICollection<Order> Order { get; set; }

    }
}
