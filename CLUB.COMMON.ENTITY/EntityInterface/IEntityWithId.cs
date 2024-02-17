namespace CLUB.COMMON.ENTITY.EntityInterface
{
    /// <summary>
    /// Сущность с идентификатором
    /// </summary>
    public interface IEntityWithId
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
