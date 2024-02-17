using CLUB.API.ModelsRequest;
using CLUB.REPOSITORIES.CONTRACTS.Interface;
using CLUB.REPOSITORIES.Implementations;
using FluentValidation;

namespace CLUB.API.Validators.WherePay
{
    /// <summary>
    /// Валидатор класса <see cref="WherePayReqCreate"/>
    /// </summary>
    public class CreateWherePayRequestValidator : AbstractValidator<WherePayReqCreate>
    {
        /// <summary>
        /// Инициализирую <see cref="CreateWherePayRequestValidator"/>
        /// </summary>
        public CreateWherePayRequestValidator()
        {
            RuleFor(x => x.BankName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Название банка не должно быть пустым или null");

            RuleFor(x => x.CardNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage("Номер карты не должен быть пустым или null")
                .MustAsync(async (num,x) => {
                    bool a = true;
                    await Task.Run(() =>
                    {
                        foreach (char c in num)
                            if (!"1234567890".Contains(c)) a = false;
                    });
                    return a;
                }).WithMessage("Номер карты должен состоять из цифр!");

            RuleFor(x => x.Nickname)
                .NotNull()
                .NotEmpty()
                .WithMessage("ФИО получателя не должно быть пустым или null");
        }
    }
}
