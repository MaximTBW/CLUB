using CLUB.API.Validators.Client;
using CLUB.API.Validators.FreeMen;
using CLUB.API.Validators.Order;
using CLUB.API.Validators.Service;
using CLUB.API.Validators.WherePay;
using CLUB.API.Validators.WherePlace;
using CLUB.REPOSITORIES.CONTRACTS.Interface;
using CLUB.SERVICES.CONTRACTS.Exceptions;
using CLUB.SHARED;
using FluentValidation;

namespace CLUB.API.Infrastructures.Validator
{
    public sealed class ApiValidatorService : IApiValidatorService
    {
        private readonly Dictionary<Type, IValidator> validators = new Dictionary<Type, IValidator>();

        public ApiValidatorService(IClientRRep clientRRep,
            IFreeMenRRep freeMenRRep,
            IServiceRRep serviceRRep,
            IWherePayRRep wherePayRRep,
            IWherePlaceRRep wherePlaceRRep)
        {
            Register<CreateClientRequestValidator>();
            Register<EditClientequestValidator>();
            Register<CreateFreeMenRequestValidator>();
            Register<EditFreeMenRequestValidator>();
            Register<CreateOrderRequestValidator>(clientRRep, freeMenRRep, serviceRRep, wherePayRRep, wherePlaceRRep);
            Register<EditOrderRequestValidator>(clientRRep, freeMenRRep, serviceRRep, wherePayRRep, wherePlaceRRep);
            Register<CreateServiceRequestValidator>();
            Register<EditServiceRequestValidator>();
            Register<CreateWherePayRequestValidator>();
            Register<EditWherePayRequestValidator>();
            Register<CreateWherePlaceRequestValidator>();
            Register<EditWherePlaceRequestValidator>();

        }

        /// <summary>
        /// Регистрирует валидатор в словаре
        /// </summary>
        public void Register<TValidator>(params object[] constructorParams)
            where TValidator : IValidator
        {
            var validatorType = typeof(TValidator);
            var innerType = validatorType.BaseType?.GetGenericArguments()[0];
            if (innerType == null)
            {
                throw new ArgumentNullException($"Указанный валидатор {validatorType} должен быть generic от типа IValidator");
            }

            if (constructorParams?.Any() == true)
            {
                var validatorObject = Activator.CreateInstance(validatorType, constructorParams);
                if (validatorObject is IValidator validator)
                {
                    validators.TryAdd(innerType, validator);
                }
            }
            else
            {
                validators.TryAdd(innerType, Activator.CreateInstance<TValidator>());
            }
        }

        public async Task ValidateAsync<TModel>(TModel model, CancellationToken cancellationToken)
            where TModel : class
        {
            var modelType = model.GetType();
            if (!validators.TryGetValue(modelType, out var validator))
            {
                throw new InvalidOperationException($"Не найден валидатор для модели {modelType}");
            }

            var context = new ValidationContext<TModel>(model);
            var result = await validator.ValidateAsync(context, cancellationToken);

            if (!result.IsValid)
            {
                throw new AccessoriesValidationException(result.Errors.Select(x =>
                InvalidateItemModel.New(x.PropertyName, x.ErrorMessage)));
            }
        }
    }
}
