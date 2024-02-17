


namespace CLUB.SERVICES.CONTRACTS.ModelRequest
{
    /// <summary>
    /// Бронирование
    /// </summary>
    public class OrderReq
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Номер свободного мужчины
        /// </summary>
        public Guid FreeMenId { get; set; }

        /// <summary>
        /// Номер услуги
        /// </summary>
        public Guid ServiceId { get; set; }

        /// <summary>
        /// Номер клиента
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// Номер места
        /// </summary>
        public Guid? PlaceId { get; set; }

        /// <summary>
        /// Номер оплаты
        /// </summary>
        public Guid? PayId { get; set; }

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
