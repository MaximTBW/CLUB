using AutoMapper;
using AutoMapper.Configuration.Conventions;
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
    public class WherePlaceServices : IWherePlaceService, IServiceAnchor
    {
        private readonly IWherePlaceRRep wherePlaceReadRepository;
        private readonly IWherePlaceWRep wherePlaceWriteRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public WherePlaceServices(IWherePlaceRRep wherePayReadRepository,
            IWherePlaceWRep wherePayWriteRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.wherePlaceReadRepository = wherePayReadRepository;
            this.wherePlaceWriteRepository = wherePayWriteRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        async Task<IEnumerable<WherePlaceModel>> IWherePlaceService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await wherePlaceReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<WherePlaceModel>>(result);
        }

        async Task<WherePlaceModel> IWherePlaceService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await wherePlaceReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new AccessoriesEntityNotFoundException<WherePlace>(id);
            }

            return mapper.Map<WherePlaceModel>(item);
        }

        async Task<WherePlaceModel> IWherePlaceService.AddAsync(WherePlaceModelReq source, CancellationToken cancellationToken)
        {
            var item = new WherePlace
            {
                Id = Guid.NewGuid(),
                Adress = source.Adress,
                PlaceName = source.PlaceName,
                OpenTime = source.OpenTime,
                CloseTime = source.CloseTime
            };
            wherePlaceWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<WherePlaceModel>(item);
        }

        async Task<WherePlaceModel> IWherePlaceService.EditAsync(WherePlaceModelReq source, CancellationToken cancellationToken)
        {
            var targetPerson = await wherePlaceReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetPerson == null)
            {
                throw new AccessoriesEntityNotFoundException<WherePlace>(source.Id);
            }

            targetPerson.Adress = source.Adress;
            targetPerson.PlaceName = source.PlaceName;
            targetPerson.OpenTime = source.OpenTime;
            targetPerson.CloseTime = source.CloseTime;

            wherePlaceWriteRepository.Update(targetPerson);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<WherePlaceModel>(targetPerson);
        }
        async Task IWherePlaceService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetAccessKey = await wherePlaceReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetAccessKey == null)
            {
                throw new AccessoriesEntityNotFoundException<WherePlace>(id);
            }

            wherePlaceWriteRepository.Delete(targetAccessKey);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
