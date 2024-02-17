using Microsoft.Extensions.DependencyInjection;

namespace CLUB.COMMON
{
    public abstract class Module
    {
        /// <summary>
        /// Создаёт зависимости
        /// </summary>
        public abstract void CreateModule(IServiceCollection service);
    }
}
