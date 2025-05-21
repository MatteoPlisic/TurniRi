using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TurniRi.Application.Interfaces;
using TurniRi.Infrastructure.FileManager.Contexts;
using TurniRi.Infrastructure.FileManager.Services;

namespace TurniRi.Infrastructure.FileManager
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddFileManagerInfrastructure(this IServiceCollection services, IConfiguration configuration, bool useInMemoryDatabase)
        {
            if (useInMemoryDatabase)
            {
                services.AddDbContext<FileManagerDbContext>(options =>
                    options.UseInMemoryDatabase(nameof(FileManagerDbContext)));
            }
            else
            {
                services.AddDbContext<FileManagerDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("FileManagerConnection")));
            }

            services.AddScoped<IFileManagerService, FileManagerService>();

            return services;
        }
    }
}
