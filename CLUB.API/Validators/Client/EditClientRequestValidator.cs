using CLUB.API.ModelsRequest;
using CLUB.REPOSITORIES.CONTRACTS.Interface;
using FluentValidation;

namespace CLUB.API.Validators.Client
{
    /// <summary>
    /// Валидатор класса <see cref="ClientReqEdit"/>
    /// </summary>
    public class EditClientequestValidator : AbstractValidator<ClientReqEdit>
    {
        /// <summary>
        /// Инициализирую <see cref="EditClientequestValidator"/>
        /// </summary>
        public EditClientequestValidator()
        {
            RuleFor(x => x.Id)
               .NotNull()
               .NotEmpty()
               .WithMessage("Id не должен быть пустым или null");

            RuleFor(x => x.Nickname)
               .NotNull()
               .NotEmpty()
               .WithMessage("Никнейм не должен быть пустым или null!")
               .MaximumLength(80)
               .WithMessage("Никнейм должен быть не более 80 символов!");

            RuleFor(x => x.Age)
                .NotNull()
                .WithMessage("Возраст не должен быть null!");

            RuleFor(x => x.PhoneNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage("Телефон не должен быть пустым или null!")
                .MaximumLength(20)
                .WithMessage("Вносить в телефон не более 20 символов!");

            RuleFor(x => x.AboutHim)
               .NotNull()
               .WithMessage("Описание не может быть null!")
               .MaximumLength(200)
               .WithMessage("Описание должно быть не более 200 символов!");

            RuleFor(x => x.Email)
               .EmailAddress()
               .WithMessage("Неправильный формат почты!");
        }
    }
}
