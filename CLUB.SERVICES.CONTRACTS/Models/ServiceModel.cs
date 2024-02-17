


namespace CLUB.SERVICES.CONTRACTS.Models
{
    /// <summary>
    /// Мужчины, что "свободны"
    /// </summary>
    public class ServiceModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

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




    }
}
