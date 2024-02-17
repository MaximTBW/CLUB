using CLUB.COMMON.ENTITY.InterfaceDB;
using CLUB.REPOSITORIES.CONTRACTS.Interface;
using CLUB.SERVICES.Anchors;
using CLUB.SERVICES.CONTRACTS.Exceptions;
using CLUB.SERVICES.CONTRACTS.Interface;
using CLUB.SERVICES.CONTRACTS.ModelRequest;
using AutoMapper;
using System.Diagnostics;

namespace CLUB.Services.Implementations
{
    public class FreeMensService : IFreeMenService, IServiceAnchor
    {
        private readonly IFreeMenRRep freeMenReadRepository;
        private readonly IFreeMenWRep freeMenWriteRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public FreeMensService(IFreeMenRRep freeMenReadRepository,
            IFreeMenWRep freeMenWriteRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.freeMenReadRepository = freeMenReadRepository;
            this.freeMenWriteRepository = freeMenWriteRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        async Task<IEnumerable<SERVICES.CONTRACTS.Models.FreeMen>> IFreeMenService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await freeMenReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<SERVICES.CONTRACTS.Models.FreeMen>>(result);
        }

        async Task<SERVICES.CONTRACTS.Models.FreeMen?> IFreeMenService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await freeMenReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new AccessoriesEntityNotFoundException<CONTEXT.CONTRACTS.Models.Client>(id);
            }

            return mapper.Map<SERVICES.CONTRACTS.Models.FreeMen>(item);
        }

        async Task<SERVICES.CONTRACTS.Models.FreeMen> IFreeMenService.AddAsync(FreeMenReq source, CancellationToken cancellationToken)
        {
            var item = new CONTEXT.CONTRACTS.Models.FreeMen
            {
                Id = Guid.NewGuid(),
                Nickname = source.Nickname,
                Age = source.Age,
                OpenTime = source.OpenTime,
                CloseTime = source.CloseTime,
                MainTongue = source.MainTongue,
                Grade = (CONTEXT.CONTRACTS.Enums.GradeTypes)source.Grade,
                AboutHim = source.AboutHim
            };
            freeMenWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<SERVICES.CONTRACTS.Models.FreeMen>(item);
        }



        async Task<SERVICES.CONTRACTS.Models.FreeMen> IFreeMenService.EditAsync(FreeMenReq source, CancellationToken cancellationToken)
        {
            var targetPerson = await freeMenReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetPerson == null)
            {
                throw new AccessoriesEntityNotFoundException<CONTEXT.CONTRACTS.Models.FreeMen>(source.Id);
            }

            targetPerson.Nickname = source.Nickname;
            targetPerson.Age = source.Age;
            targetPerson.OpenTime = source.OpenTime;
            targetPerson.CloseTime = source.CloseTime;
            targetPerson.MainTongue = source.MainTongue;
            targetPerson.Grade = (CONTEXT.CONTRACTS.Enums.GradeTypes)source.Grade;
            targetPerson.AboutHim = source.AboutHim;

            freeMenWriteRepository.Update(targetPerson);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<SERVICES.CONTRACTS.Models.FreeMen>(targetPerson);
        }
        async Task IFreeMenService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetAccessKey = await freeMenReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetAccessKey == null)
            {
                throw new AccessoriesEntityNotFoundException<CONTEXT.CONTRACTS.Models.FreeMen>(id);
            }

            freeMenWriteRepository.Delete(targetAccessKey);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
