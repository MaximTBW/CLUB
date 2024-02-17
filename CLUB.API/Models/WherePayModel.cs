


namespace CLUB.API.Models
{
    /// <summary>
    /// Место платежа от клиентов
    /// </summary>
    public class WherePayResp
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название банка
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// Кому платят
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Номер карты
        /// </summary>
        public string CardNumber { get; set; }

    }
}
