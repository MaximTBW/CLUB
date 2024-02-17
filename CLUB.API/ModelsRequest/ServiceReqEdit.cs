namespace CLUB.API.ModelsRequest
{
    /// <summary>
    /// Модель запроса изменения услуги
    /// </summary>
    public class ServiceReqEdit : ServiceReqCreate
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
