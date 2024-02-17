using CLUB.API.ModelsRequest;
using CLUB.REPOSITORIES.CONTRACTS.Interface;
using FluentValidation;

namespace CLUB.API.Validators.FreeMen
{
    /// <summary>
    /// Валидатор класса <see cref="FreeMenReqCreate"/>
    /// </summary>
    public class CreateFreeMenRequestValidator : AbstractValidator<FreeMenReqCreate>
    {
        /// <summary>
        /// Инициализирую <see cref="CreateFreeMenRequestValidator"/>
        /// </summary>
        public CreateFreeMenRequestValidator()
        {
            RuleFor(x => x.Nickname)
               .NotNull()
               .NotEmpty()
               .WithMessage("Никнейм не должен быть пустым или null!")
               .MaximumLength(80)
               .WithMessage("Никнейм должен быть не более 80 символов!");

            RuleFor(x => x.Age)
                .NotNull()
                .WithMessage("Возраст не должен быть null!")
                .GreaterThan(17)
                .WithMessage("Возраст не должен быть в пределах 18-40 лет")
                .LessThan(41)
                .WithMessage("Возраст не должен быть в пределах 18-40 лет");

            RuleFor(x => x.AboutHim)
               .NotNull()
               .WithMessage("Описание не может быть null!")
               .MaximumLength(200)
               .WithMessage("Описание должно быть не более 200 символов!");
        }
    }
}
