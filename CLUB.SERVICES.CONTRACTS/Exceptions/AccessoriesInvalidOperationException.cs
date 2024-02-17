namespace CLUB.SERVICES.CONTRACTS.Exceptions
{
    /// <summary>
    /// Ошибка выполнения операции
    /// </summary>
    public class AccessoriesInvalidOperationException : AccessoriesException
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="AccessoriesInvalidOperationException"/>
        /// с указанием сообщения об ошибке
        /// </summary>
        public AccessoriesInvalidOperationException(string message)
            : base(message)
        {

        }
    }
}
