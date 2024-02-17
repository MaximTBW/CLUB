using CLUB.COMMON;
using CLUB.REPOSITORIES.Anchors;
using CLUB.SHARED;
using Microsoft.Extensions.DependencyInjection;

namespace CLUB.REPOSITORIES
{
    public class ReadRepositoryModule : Module
    {
        public override void CreateModule(IServiceCollection service)
        {
            service.AssemblyInterfaceAssignableTo<IReadRepositoryAnchor>(ServiceLifetime.Scoped);
        }
    }
}
