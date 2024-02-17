


namespace CLUB.SERVICES.CONTRACTS.ModelRequest
{
    /// <summary>
    /// Место бронирования
    /// </summary>
    public class WherePlaceModelReq
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
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

    }
}
