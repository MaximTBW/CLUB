namespace CLUB.API.ModelsRequest
{
    /// <summary>
    /// Модель запроса изменения клиента 
    /// </summary>
    public class ClientReqEdit : ClientReqCreate
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
