using CLUB.API.ModelsRequest;
using CLUB.REPOSITORIES.CONTRACTS.Interface;
using CLUB.REPOSITORIES.Implementations;
using FluentValidation;

namespace CLUB.API.Validators.Order
{
    /// <summary>
    /// Валидатор класса <see cref="OrderReqEdit"/>
    /// </summary>
    public class EditOrderRequestValidator : AbstractValidator<OrderReqEdit>
    {
        /// <summary>
        /// Инициализирую <see cref="EditOrderRequestValidator"/>
        /// </summary>
        public EditOrderRequestValidator(IClientRRep clientReadRepository,
            IFreeMenRRep freeMenReadRepository,
            IServiceRRep serviceReadRepository,
            IWherePayRRep wherePayReadRepository,
            IWherePlaceRRep wherePlaceReadRepository)
        {
            RuleFor(x => x.Id)
               .NotNull()
               .NotEmpty()
               .WithMessage("Id не должен быть пустым или null");

            RuleFor(x => x.Client)
                .NotNull()
                .NotEmpty()
                .WithMessage("Клиент не должен быть пустым или null")
                .MustAsync(async (id, CancellationToken) =>
                {
                    var thisIsExists = await clientReadRepository.AnyByIdAsync(id, CancellationToken);
                    return thisIsExists;
                })
                .WithMessage("Такого клиента не существует!");
            RuleFor(x => x.FreeMen)
                .NotNull()
                .NotEmpty()
                .WithMessage("Малчик не должен быть пустым или null")
                .MustAsync(async (id, CancellationToken) =>
                {
                    var thisIsExists = await freeMenReadRepository.AnyByIdAsync(id, CancellationToken);
                    return thisIsExists;
                })
                .WithMessage("Такого мальчика не существует!");
            RuleFor(x => x.Service)
                .NotNull()
                .NotEmpty()
                .WithMessage("Услуга не должна быть пустой или null")
                .MustAsync(async (id, CancellationToken) =>
                {
                    var thisIsExists = await serviceReadRepository.AnyByIdAsync(id, CancellationToken);
                    return thisIsExists;
                })
                .WithMessage("Такой услуги не существует!");
            RuleFor(x => x.WherePay)
                .MustAsync(async (id, CancellationToken) =>
                {
                    var thisIsExists = await wherePayReadRepository.AnyByIdAsync(id, CancellationToken);
                    return thisIsExists;
                })
                .WithMessage("Такого места оплаты не существует!");
            RuleFor(x => x.WherePlace)
                .MustAsync(async (id, CancellationToken) =>
                {
                    var thisIsExists = await wherePlaceReadRepository.AnyByIdAsync(id, CancellationToken);
                    return thisIsExists;
                })
                .WithMessage("Такого места проведения не существует!");
        }
    }
}
