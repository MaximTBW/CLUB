namespace CLUB.API.ModelsRequest
{
    /// <summary>
    /// Модель запроса изменения клиента 
    /// </summary>
    public class FreeMenReqEdit : FreeMenReqCreate
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
