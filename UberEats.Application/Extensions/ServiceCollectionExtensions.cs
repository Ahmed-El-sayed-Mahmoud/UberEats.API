using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace UberEats.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            var appAssembly = typeof(ServiceCollectionExtensions).Assembly;

            services.AddAutoMapper(appAssembly);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(appAssembly));

        }
    }
}