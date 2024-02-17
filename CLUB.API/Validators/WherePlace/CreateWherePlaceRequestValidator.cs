using CLUB.API.ModelsRequest;
using CLUB.REPOSITORIES.CONTRACTS.Interface;
using CLUB.REPOSITORIES.Implementations;
using FluentValidation;

namespace CLUB.API.Validators.WherePlace
{
    /// <summary>
    /// Валидатор класса <see cref="WherePlaceReqCreate"/>
    /// </summary>
    public class CreateWherePlaceRequestValidator : AbstractValidator<WherePlaceReqCreate>
    {
        /// <summary>
        /// Инициализирую <see cref="CreateWherePlaceRequestValidator"/>
        /// </summary>
        public CreateWherePlaceRequestValidator()
        {
            RuleFor(x => x.Adress)
                .NotNull()
                .NotEmpty()
                .WithMessage("Адресс не должно быть пустым или null");

            RuleFor(x => x.OpenTime)
                .NotNull()
                .NotEmpty()
                .WithMessage("Время открытия не должно быть пустым или null");

            RuleFor(x => x.CloseTime)
                .NotNull()
                .NotEmpty()
                .WithMessage("Время закрытия не должно быть пустым или null");

            RuleFor(x => x.PlaceName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Название места не должно быть пустым или null");
        }
    }
}
