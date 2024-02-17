using CLUB.COMMON;
using CLUB.COMMON.ENTITY.InterfaceDB;
using CLUB.CONTEXT.CONTRACTS.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CLUB.CONTEXT
{
    public class ContextModule : Module
    {
        public override void CreateModule(IServiceCollection service)
        {
            service.TryAddScoped<IClubContext>
                (provider => provider.GetRequiredService<ClubContext>());
            service.TryAddScoped<IDbRead>
                (provider => provider.GetRequiredService<ClubContext>());
            service.TryAddScoped<IDbWriter>
                (provider => provider.GetRequiredService<ClubContext>());
            service.TryAddScoped<IUnitOfWork>
                (provider => provider.GetRequiredService<ClubContext>());
        }
    }
}
