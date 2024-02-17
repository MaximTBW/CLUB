using CLUB.API.ModelsRequest;
using CLUB.REPOSITORIES.CONTRACTS.Interface;
using CLUB.REPOSITORIES.Implementations;
using FluentValidation;

namespace CLUB.API.Validators.WherePlace
{
    /// <summary>
    /// Валидатор класса <see cref="WherePlaceReqEdit"/>
    /// </summary>
    public class EditWherePlaceRequestValidator : AbstractValidator<WherePlaceReqEdit>
    {
        /// <summary>
        /// Инициализирую <see cref="EditWherePlaceRequestValidator"/>
        /// </summary>
        public EditWherePlaceRequestValidator()
        {
            RuleFor(x => x.Id)
               .NotNull()
               .NotEmpty()
               .WithMessage("Id не должен быть пустым или null");

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
