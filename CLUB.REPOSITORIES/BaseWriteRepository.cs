using CLUB.COMMON.ENTITY;
using CLUB.COMMON.ENTITY.EntityInterface;
using CLUB.COMMON.ENTITY.InterfaceDB;
using CLUB.REPOSITORIES.CONTRACTS;
using System.Diagnostics.CodeAnalysis;

namespace CLUB.REPOSITORIES
{
    public abstract class BaseWriteRepository<TEntity> : IRepositoryWriter<TEntity> where TEntity : class, IEntity
    {
        /// <inheritdoc cref="IDbWriterContext"/>
        private readonly IDbWriterContext writerContext;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="BaseWriteRepository{T}"/>
        /// </summary>
        public BaseWriteRepository(IDbWriterContext writerContext)
        {
            this.writerContext = writerContext;
        }

        /// <inheritdoc cref="IRepositoryWriter{T}"/>
        public void Add([NotNull] TEntity entity)
        {
            if (entity is IEntityWithId entityWithId &&
                 entityWithId.Id == Guid.Empty)
            {
                entityWithId.Id = Guid.NewGuid();
            }
            AuditForCreated(entity);
            AuditForUpdated(entity);
            writerContext.Writer.Add(entity);
        }

        /// <inheritdoc cref="IRepositoryWriter{T}"/>
        public void Update([NotNull] TEntity entity)
        {
            AuditForUpdated(entity);
            writerContext.Writer.Update(entity);
        }

        /// <inheritdoc cref="IRepositoryWriter{T}"/>
        public void Delete([NotNull] TEntity entity)
        {
            AuditForUpdated(entity);
            AuditForDeleted(entity);
            if (entity is IEntityAuditDeleted)
            {
                writerContext.Writer.Update(entity);
            }
            else
            {
                writerContext.Writer.Delete(entity);
            }
        }

        private void AuditForCreated([NotNull] TEntity entity)
        {
            if (entity is IEntityAuditCreated auditCreated)
            {
                auditCreated.CreatedAt = writerContext.DateTimeProvider.UtcNow;
                auditCreated.CreatedBy = writerContext.UserName;
            }
        }

        private void AuditForUpdated([NotNull] TEntity entity)
        {
            if (entity is IEntityAuditUpdated auditCreated)
            {
                auditCreated.UpdatedAt = writerContext.DateTimeProvider.UtcNow;
                auditCreated.UpdatedBy = writerContext.UserName;
            }
        }
        private void AuditForDeleted([NotNull] TEntity entity)
        {
            if (entity is IEntityAuditDeleted auditCreated)
            {
                auditCreated.DeletedAt = writerContext.DateTimeProvider.UtcNow;
            }
        }
    }
}
