using AutoMapper;
using CLUB.COMMON.ENTITY.InterfaceDB;
using CLUB.CONTEXT.CONTRACTS.Models;
using CLUB.REPOSITORIES.CONTRACTS.Interface;
using CLUB.SERVICES.Anchors;
using CLUB.SERVICES.CONTRACTS.Exceptions;
using CLUB.SERVICES.CONTRACTS.Interface;
using CLUB.SERVICES.CONTRACTS.ModelRequest;
using CLUB.SERVICES.CONTRACTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLUB.SERVICES.Implementations
{
    public class WherePayServices : IWherePayService, IServiceAnchor
    {
        private readonly IWherePayRRep wherePayReadRepository;
        private readonly IWherePayWRep wherePayWriteRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public WherePayServices(IWherePayRRep wherePayReadRepository,
            IWherePayWRep wherePayWriteRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.wherePayReadRepository = wherePayReadRepository;
            this.wherePayWriteRepository = wherePayWriteRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        async Task<IEnumerable<WherePayModel>> IWherePayService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await wherePayReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<WherePayModel>>(result);
        }

        async Task<WherePayModel> IWherePayService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await wherePayReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new AccessoriesEntityNotFoundException<WherePayModel>(id);
            }

            return mapper.Map<WherePayModel>(item);
        }

        async Task<WherePayModel> IWherePayService.AddAsync(WherePayModelReq source, CancellationToken cancellationToken)
        {
            var item = new WherePay
            {
                Id = Guid.NewGuid(),
                BankName = source.BankName,
                Nickname = source.Nickname,
                CardNumber = source.CardNumber
            };
            wherePayWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<WherePayModel>(item);
        }

        async Task<WherePayModel> IWherePayService.EditAsync(WherePayModelReq source, CancellationToken cancellationToken)
        {
            var targetPerson = await wherePayReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetPerson == null)
            {
                throw new AccessoriesEntityNotFoundException<WherePayModel>(source.Id);
            }
            targetPerson.BankName = source.BankName;
            targetPerson.Nickname = source.Nickname;
            targetPerson.CardNumber = source.CardNumber;

            wherePayWriteRepository.Update(targetPerson);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<WherePayModel>(targetPerson);
        }
        async Task IWherePayService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetAccessKey = await wherePayReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetAccessKey == null)
            {
                throw new AccessoriesEntityNotFoundException<WherePayModel>(id);
            }

            wherePayWriteRepository.Delete(targetAccessKey);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
