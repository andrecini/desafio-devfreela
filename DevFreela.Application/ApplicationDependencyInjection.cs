using Microsoft.Extensions.DependencyInjection;
using System;

namespace DevFreela.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            return services;
        }
    }
}
