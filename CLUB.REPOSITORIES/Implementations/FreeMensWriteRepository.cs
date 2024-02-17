using CLUB.COMMON.ENTITY.InterfaceDB;
using CLUB.CONTEXT.CONTRACTS.Models;
using CLUB.REPOSITORIES.Anchors;
using CLUB.REPOSITORIES.CONTRACTS.Interface;

namespace CLUB.REPOSITORIES.Implementations
{
    public class FreeMensWriteRepository : BaseWriteRepository<FreeMen>,
        IFreeMenWRep,
        IReadRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="FreeMensWriteRepository"/>
        /// </summary>
        public FreeMensWriteRepository(IDbWriterContext writerContext)
            : base(writerContext)
        {
        }
    }
}
