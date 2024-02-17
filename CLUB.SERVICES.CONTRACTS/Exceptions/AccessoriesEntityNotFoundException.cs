namespace CLUB.SERVICES.CONTRACTS.Exceptions
{
    /// <summary>
    /// Запрашиваемая сущность не найдена
    /// </summary>
    public class AccessoriesEntityNotFoundException<TEntity> : AccessoriesNotFoundException
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="AccessoriesEntityNotFoundException{TEntity}"/>
        /// </summary>
        public AccessoriesEntityNotFoundException(Guid id)
            : base($"Сущность {typeof(TEntity)} c id = {id} не найдена.")
        {
        }
    }
}
