using CLUB.COMMON;
using CLUB.SERVICES.Anchors;
using Microsoft.Extensions.DependencyInjection;
using CLUB.SHARED;
using CLUB.SERVICES.Automappers;

namespace CLUB.SERVICES
{

    public class ServiceModule : Module
    {
        public override void CreateModule(IServiceCollection service)
        {
            service.AssemblyInterfaceAssignableTo<IServiceAnchor>(ServiceLifetime.Scoped);

            service.RegisterAutoMapperProfile<ServiceProfile>();
        }
    }
}
