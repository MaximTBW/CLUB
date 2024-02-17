using CLUB.COMMON.ENTITY.InterfaceDB;
using CLUB.CONTEXT.CONTRACTS.Models;
using CLUB.REPOSITORIES.Anchors;
using CLUB.REPOSITORIES.CONTRACTS.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLUB.REPOSITORIES.Implementations
{
    public class ServiceWriteRepository : BaseWriteRepository<Service>,
       IServiceWRep,
       IReadRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ClientsWriteRepository"/>
        /// </summary>
        public ServiceWriteRepository(IDbWriterContext writerContext)
            : base(writerContext)
        {
        }
    }
}
