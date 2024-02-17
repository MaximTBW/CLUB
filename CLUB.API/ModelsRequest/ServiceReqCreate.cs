


namespace CLUB.API.ModelsRequest
{
    /// <summary>
    /// Услуга
    /// </summary>
    public class ServiceReqCreate
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




    }
}
