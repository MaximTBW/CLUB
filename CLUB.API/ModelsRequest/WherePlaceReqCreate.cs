


namespace CLUB.API.ModelsRequest
{
    /// <summary>
    /// Место бронирования
    /// </summary>
    public class WherePlaceReqCreate
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
        public DateTimeOffset OpenTime { get; set; } = DateTimeOffset.UtcNow;

        /// <summary>
        /// До скольки открыто
        /// </summary>
        public DateTimeOffset CloseTime { get; set; } = DateTimeOffset.UtcNow;

    }
}
