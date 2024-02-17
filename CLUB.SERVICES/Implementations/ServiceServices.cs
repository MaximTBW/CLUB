using AutoMapper;
using CLUB.COMMON.ENTITY.InterfaceDB;
using CLUB.CONTEXT.CONTRACTS.Models;
using CLUB.REPOSITORIES.CONTRACTS.Interface;
using CLUB.SERVICES.Anchors;
using CLUB.SERVICES.CONTRACTS.Exceptions;
using CLUB.SERVICES.CONTRACTS.Interface;
using CLUB.SERVICES.CONTRACTS.ModelRequest;
using CLUB.SERVICES.CONTRACTS.Models;


namespace CLUB.SERVICES.Implementations
{
    public class ServiceServices : IServiceService, IServiceAnchor
    {
        private readonly IServiceRRep serviceReadRepository;
        private readonly IServiceWRep serviceWriteRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ServiceServices(IServiceRRep clientsReadRepository,
            IServiceWRep clientsWriteRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.serviceReadRepository = clientsReadRepository;
            this.serviceWriteRepository = clientsWriteRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        async Task<IEnumerable<ServiceModel>> IServiceService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await serviceReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<ServiceModel>>(result);
        }

        async Task<ServiceModel?> IServiceService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await serviceReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new AccessoriesEntityNotFoundException<Service>(id);
            }

            return mapper.Map<ServiceModel>(item);
        }

        async Task<ServiceModel> IServiceService.AddAsync(ServiceModelReq source, CancellationToken cancellationToken)
        {
            var item = new Service
            {
                Id = Guid.NewGuid(),
                ServiceName = source.ServiceName,
                AboutService = source.AboutService,
                Price = source.Price
            };
            serviceWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<ServiceModel>(item);
        }

        async Task<ServiceModel> IServiceService.EditAsync(ServiceModelReq source, CancellationToken cancellationToken)
        {
            var targetPerson = await serviceReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetPerson == null)
            {
                throw new AccessoriesEntityNotFoundException<CONTEXT.CONTRACTS.Models.Client>(source.Id);
            }

            targetPerson.ServiceName = source.ServiceName;
            targetPerson.AboutService = source.AboutService;
            targetPerson.Price = source.Price;

            serviceWriteRepository.Update(targetPerson);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<ServiceModel>(targetPerson);
        }
        async Task IServiceService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetAccessKey = await serviceReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetAccessKey == null)
            {
                throw new AccessoriesEntityNotFoundException<CONTEXT.CONTRACTS.Models.Client>(id);
            }

            serviceWriteRepository.Delete(targetAccessKey);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
