using EfCoreWebAPIs.Application.Interfaces;
using EfCoreWebAPIs.Core.Options;
using EfCoreWebAPIs.Infrastructure.Data;
using EfCoreWebAPIs.Infrastructure.Repositories.EmployeeRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Infrastructure
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            // Register infrastructure services here
            // Example: services.AddScoped<IMyInfrastructureService, MyInfrastructureService>();
            // Register DbContext
            services.AddDbContext<AppDbContext>((provider, options) =>
            {
                //options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                options.UseSqlServer(provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value.DefaultConnection);
            });


            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            //registering the external endpoints

            services.AddHttpClient("");

            return services;
        }
    }
}
