using CLUB.API.ModelsRequest;
using CLUB.REPOSITORIES.CONTRACTS.Interface;
using CLUB.REPOSITORIES.Implementations;
using FluentValidation;

namespace CLUB.API.Validators.Service
{
    /// <summary>
    /// Валидатор класса <see cref="ServiceReqEdit"/>
    /// </summary>
    public class EditServiceRequestValidator : AbstractValidator<ServiceReqEdit>
    {
        /// <summary>
        /// Инициализирую <see cref="EditServiceRequestValidator"/>
        /// </summary>
        public EditServiceRequestValidator()
        {
            RuleFor(x => x.Id)
               .NotNull()
               .NotEmpty()
               .WithMessage("Id не должен быть пустым или null");

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
