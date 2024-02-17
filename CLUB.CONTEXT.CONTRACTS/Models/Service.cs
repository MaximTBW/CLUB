using CLUB.COMMON.ENTITY;
using CLUB.COMMON.ENTITY.EntityInterface;

namespace CLUB.CONTEXT.CONTRACTS.Models
{
    /// <summary>
    /// Мужчины, что "свободны"
    /// </summary>
    public class Service : BaseAuditEntity
    {
        /// <summary>
        /// Название услуги
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Описание услуги
        /// </summary>
        public string AboutService { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; } = 0;

        /// <summary>
        /// Навигация для связи 1 ко многим
        /// </summary>
        public ICollection<Order> Order { get; set; }




    }
}
