using CLUB.COMMON.ENTITY.InterfaceDB;
using CLUB.CONTEXT.CONTRACTS.Models;
using CLUB.REPOSITORIES.Anchors;
using CLUB.REPOSITORIES.CONTRACTS.Interface;

namespace CLUB.REPOSITORIES.Implementations
{
    public class ClientsWriteRepository : BaseWriteRepository<Client>,
        IClientWRep,
        IReadRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ClientsWriteRepository"/>
        /// </summary>
        public ClientsWriteRepository(IDbWriterContext writerContext)
            : base(writerContext)
        {
        }
    }
}
