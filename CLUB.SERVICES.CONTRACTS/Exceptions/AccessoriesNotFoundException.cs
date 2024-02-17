namespace CLUB.SERVICES.CONTRACTS.Exceptions
{
    /// <summary>
    /// Запрашиваемый ресурс не найден
    /// </summary>
    public class AccessoriesNotFoundException : AccessoriesException
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="AccessoriesNotFoundException"/> с указанием
        /// сообщения об ошибке
        /// </summary>
        public AccessoriesNotFoundException(string message)
            : base(message)
        { }
    }
}
