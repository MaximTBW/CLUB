using CLUB.API.ModelsRequest;
using CLUB.REPOSITORIES.CONTRACTS.Interface;
using CLUB.REPOSITORIES.Implementations;
using FluentValidation;

namespace CLUB.API.Validators.Service
{
    /// <summary>
    /// Валидатор класса <see cref="ServiceReqCreate"/>
    /// </summary>
    public class CreateServiceRequestValidator : AbstractValidator<ServiceReqCreate>
    {
        /// <summary>
        /// Инициализирую <see cref="CreateServiceRequestValidator"/>
        /// </summary>
        public CreateServiceRequestValidator()
        {
            RuleFor(x => x.ServiceName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Название услуги не может быть пуста или null");

            RuleFor(x => x.Price)
                .NotNull()
                .NotEmpty()
                .WithMessage("Цена услуги не может быть пуста или null");
        }
    }
}
