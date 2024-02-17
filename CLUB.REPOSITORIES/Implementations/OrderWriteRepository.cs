using CLUB.COMMON.ENTITY.InterfaceDB;
using CLUB.CONTEXT.CONTRACTS.Models;
using CLUB.REPOSITORIES.Anchors;
using CLUB.REPOSITORIES.CONTRACTS.Interface;

namespace CLUB.REPOSITORIES.Implementations
{
    public class OrderWriteRepository : BaseWriteRepository<Order>,
        IOrderWRep,
        IReadRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="OrderWriteRepository"/>
        /// </summary>
        public OrderWriteRepository(IDbWriterContext writerContext)
            : base(writerContext)
        {
        }
    }
}
