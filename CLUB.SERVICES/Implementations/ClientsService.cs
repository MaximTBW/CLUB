using CLUB.COMMON.ENTITY.InterfaceDB;
using CLUB.REPOSITORIES.CONTRACTS.Interface;
using CLUB.SERVICES.Anchors;
using CLUB.SERVICES.CONTRACTS.Exceptions;
using CLUB.SERVICES.CONTRACTS.Interface;
using CLUB.SERVICES.CONTRACTS.ModelRequest;
using AutoMapper;

namespace CLUB.Services.Implementations
{
    public class ClientsService : IClientsService, IServiceAnchor
    {
        private readonly IClientRRep clientsReadRepository;
        private readonly IClientWRep clientsWriteRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ClientsService(IClientRRep clientsReadRepository,
            IClientWRep clientsWriteRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.clientsReadRepository = clientsReadRepository;
            this.clientsWriteRepository = clientsWriteRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        async Task<IEnumerable<SERVICES.CONTRACTS.Models.Client>> IClientsService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await clientsReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<SERVICES.CONTRACTS.Models.Client>>(result);
        }

        async Task<SERVICES.CONTRACTS.Models.Client?> IClientsService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await clientsReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new AccessoriesEntityNotFoundException<CONTEXT.CONTRACTS.Models.Client>(id);
            }

            return mapper.Map<SERVICES.CONTRACTS.Models.Client>(item);
        }

        async Task<SERVICES.CONTRACTS.Models.Client> IClientsService.AddAsync(ClientReq source, CancellationToken cancellationToken)
        {
            var item = new CONTEXT.CONTRACTS.Models.Client
            {
                Id = Guid.NewGuid(),
                Nickname = source.Nickname,
                Age = source.Age,
                PhoneNumber = source.PhoneNumber,
                Email = source.Email,
                AboutHim = source.AboutHim
            };
            clientsWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<SERVICES.CONTRACTS.Models.Client>(item);
        }



        async Task<SERVICES.CONTRACTS.Models.Client> IClientsService.EditAsync(ClientReq source, CancellationToken cancellationToken)
        {
            var targetPerson = await clientsReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetPerson == null)
            {
                throw new AccessoriesEntityNotFoundException<CONTEXT.CONTRACTS.Models.Client>(source.Id);
            }

            targetPerson.Nickname = source.Nickname;
            targetPerson.Age = source.Age;
            targetPerson.PhoneNumber = source.PhoneNumber;
            targetPerson.Email = source.Email;
            targetPerson.AboutHim = source.AboutHim;

            clientsWriteRepository.Update(targetPerson);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<SERVICES.CONTRACTS.Models.Client>(targetPerson);
        }
        async Task IClientsService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetAccessKey = await clientsReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetAccessKey == null)
            {
                throw new AccessoriesEntityNotFoundException<CONTEXT.CONTRACTS.Models.Client>(id);
            }

            clientsWriteRepository.Delete(targetAccessKey);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
