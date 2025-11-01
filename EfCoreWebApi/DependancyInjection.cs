using EfCoreWebAPIs.Application;
using EfCoreWebAPIs.Core;
using EfCoreWebAPIs.Infrastructure;

namespace EfCoreWebApi
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI()
                    .AddInfrastructureDI(configuration)
                    .AddCoreDI(configuration);
            return services;
        }
    }
}
