using Microsoft.Extensions.DependencyInjection;
using TurniRi.Application.Interfaces;
using TurniRi.Infrastructure.Resources.Services;

namespace TurniRi.Infrastructure.Resources
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddResourcesInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<ITranslator, Translator>();

            return services;
        }
    }
}
