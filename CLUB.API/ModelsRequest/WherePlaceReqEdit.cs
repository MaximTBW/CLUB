namespace CLUB.API.ModelsRequest
{
    /// <summary>
    /// Модель запроса изменения мест платежа
    /// </summary>
    public class WherePlaceReqEdit : WherePlaceReqCreate
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
