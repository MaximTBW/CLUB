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
    public class WherePayWriteRepository : BaseWriteRepository<WherePay>,
     IWherePayWRep,
     IReadRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ClientsWriteRepository"/>
        /// </summary>
        public WherePayWriteRepository(IDbWriterContext writerContext)
            : base(writerContext)
        {
        }
    }
}
