using CLUB.SHARED;

namespace CLUB.SERVICES.CONTRACTS.Exceptions
{
    /// <summary>
    /// Ошибки валидации
    /// </summary>
    public class AccessoriesValidationException : AccessoriesException
    {
        /// <summary>
        /// Ошибки
        /// </summary>
        public IEnumerable<InvalidateItemModel> Errors { get; }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="AccessoriesValidationException"/>
        /// </summary>
        public AccessoriesValidationException(IEnumerable<InvalidateItemModel> errors)
        {
            Errors = errors;
        }
    }
}
