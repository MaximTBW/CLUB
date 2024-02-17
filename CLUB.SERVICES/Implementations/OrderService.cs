using CLUB.COMMON.ENTITY.InterfaceDB;
using CLUB.REPOSITORIES.CONTRACTS.Interface;
using CLUB.SERVICES.Anchors;
using CLUB.SERVICES.CONTRACTS.Exceptions;
using CLUB.SERVICES.CONTRACTS.Interface;
using CLUB.SERVICES.CONTRACTS.ModelRequest;
using AutoMapper;
using System.Diagnostics;
using CLUB.CONTEXT.CONTRACTS.Models;

namespace CLUB.Services.Implementations
{
    public class OrderService : IOrderService, IServiceAnchor
    {
        private readonly IOrderRRep orderReadRepository;
        private readonly IOrderWRep orderWriteRepository;

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public OrderService(IOrderRRep orderReadRepository,
            IOrderWRep orderWriteRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.orderReadRepository = orderReadRepository;
            this.orderWriteRepository = orderWriteRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        async Task<IEnumerable<SERVICES.CONTRACTS.Models.Order>> IOrderService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await orderReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<SERVICES.CONTRACTS.Models.Order>>(result);
        }

        async Task<SERVICES.CONTRACTS.Models.Order?> IOrderService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await orderReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new AccessoriesEntityNotFoundException<Client>(id);
            }

            return mapper.Map<SERVICES.CONTRACTS.Models.Order>(item);
        }

        async Task<SERVICES.CONTRACTS.Models.Order> IOrderService.AddAsync(OrderReq source, CancellationToken cancellationToken)
        {


            var item = new Order
            {
                Id = Guid.NewGuid(),
                ClientId = source.ClientId,
                ServiceId = source.ServiceId,
                FreeMenId = source.FreeMenId,
                PayId = source.PayId,
                PlaceId = source.PlaceId,
                Comment = source.Comment
            };
            orderWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<SERVICES.CONTRACTS.Models.Order>(item);
        }



        async Task<SERVICES.CONTRACTS.Models.Order> IOrderService.EditAsync(OrderReq source, CancellationToken cancellationToken)
        {
            var targetPerson = await orderReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetPerson == null)
            {
                throw new AccessoriesEntityNotFoundException<Order>(source.Id);
            }

            targetPerson.ClientId = source.ClientId;
            targetPerson.ServiceId = source.ServiceId;
            targetPerson.FreeMenId = source.FreeMenId;
            targetPerson.PayId = source.PayId;
            targetPerson.PlaceId = source.PlaceId;
            targetPerson.Comment = source.Comment;

            orderWriteRepository.Update(targetPerson);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<SERVICES.CONTRACTS.Models.Order>(targetPerson);
        }
        async Task IOrderService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetAccessKey = await orderReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetAccessKey == null)
            {
                throw new AccessoriesEntityNotFoundException<Order>(id);
            }

            orderWriteRepository.Delete(targetAccessKey);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
