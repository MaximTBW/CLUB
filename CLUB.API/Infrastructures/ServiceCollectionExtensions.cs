//using CLUB.API.Infrastructures.Validator;
using CLUB.API.Infrastructures.Validator;
using CLUB.COMMON;
using CLUB.COMMON.ENTITY.InterfaceDB;
using CLUB.CONTEXT;
using CLUB.REPOSITORIES;
using CLUB.SERVICES;
using CLUB.SHARED;

namespace CLUB.API.Infrastructures
{
    /// <summary>
    /// Работа с регистрацией
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Регистрация всех абстракций с имплементацией
        /// </summary>
        public static void AddDependences(this IServiceCollection services)
        {
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            services.AddTransient<IDbWriterContext, DbWriterContext>();
            services.AddTransient<IApiValidatorService, ApiValidatorService>();
            services.RegisterAutoMapperProfile<ApiProfile>();

            services.RegisterModule<ServiceModule>();
            services.RegisterModule<ReadRepositoryModule>();
            services.RegisterModule<ContextModule>();

            services.RegisterAutoMapper();
        }

    }
}
