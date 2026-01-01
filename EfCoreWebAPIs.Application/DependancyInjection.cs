using EfCoreWebAPIs.Application.Interfaces;
using EfCoreWebAPIs.Application.Mappings;
using EfCoreWebAPIs.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Application
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            // Register application services here
            // Example: services.AddScoped<IMyService, MyService>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependancyInjection).Assembly));
            services.AddAutoMapper(typeof(BookProfile).Assembly);

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ILanguageService, LanguageService>();
            return services;
        }
    }
}
