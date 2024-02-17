using CLUB.API.Enums;

namespace CLUB.API.ModelsRequest
{
    /// <summary>
    /// Модель запроса создания мужчины 
    /// </summary>
    public class FreeMenReqCreate
    {
        /// <summary>
        /// ФИО Мужчины
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// О мужчине
        /// </summary>
        public string? AboutHim { get; set; } = string.Empty;

        /// <summary>
        /// Со скольки доступен
        /// </summary>
        public DateTimeOffset OpenTime { get; set; }

        /// <summary>
        /// До скольки доступен
        /// </summary>
        public DateTimeOffset CloseTime { get; set; }

        /// <summary>
        /// Основной язык
        /// </summary>
        public string MainTongue { get; set; }

        /// <summary>
        /// Уровень мастерства
        /// </summary>
        public GradeTypes Grade { get; set; }

    }
}
