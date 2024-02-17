using CLUB.COMMON.ENTITY;
using CLUB.COMMON.ENTITY.EntityInterface;

namespace CLUB.CONTEXT.CONTRACTS.Models
{
    /// <summary>
    /// Место платежа от клиентов
    /// </summary>
    public class WherePay : BaseAuditEntity
    {
        /// <summary>
        /// Название банка
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// Кому платят
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Номер карты
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Навигация для связи 1 ко многим
        /// </summary>
        public ICollection<Order> Order { get; set; }

    }
}
