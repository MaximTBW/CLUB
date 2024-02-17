


namespace CLUB.API.Models
{
    /// <summary>
    /// Бронирование
    /// </summary>
    public class OrderResp
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Номер свободного мужчины
        /// </summary>
        public Guid FreeMen { get; set; }

        /// <summary>
        /// Номер услуги
        /// </summary>
        public Guid Service { get; set; }

        /// <summary>
        /// Номер клиента
        /// </summary>
        public Guid Client { get; set; }

        /// <summary>
        /// Номер места
        /// </summary>
        public Guid? WherePlace { get; set; }

        /// <summary>
        /// Номер оплаты
        /// </summary>
        public Guid? WherePay { get; set; }

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
