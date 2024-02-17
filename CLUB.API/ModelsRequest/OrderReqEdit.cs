namespace CLUB.API.ModelsRequest
{
    /// <summary>
    /// Модель запроса изменения брони
    /// </summary>
    public class OrderReqEdit : OrderReqCreate
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
