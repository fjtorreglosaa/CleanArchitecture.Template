using CleanArchitecture.Template.Domain.DomainServices.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Template.Application.Containers
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjectionContainer).Assembly);
            });

            services.AddTransient<PriceDomainService>();

            return services;
        }
    }
}
