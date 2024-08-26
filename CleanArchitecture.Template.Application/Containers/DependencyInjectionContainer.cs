using CleanArchitecture.Template.Application.Abstractions.Behaviors;
using CleanArchitecture.Template.Domain.DomainServices.Shared;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace CleanArchitecture.Template.Application.Containers
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjectionContainer).Assembly);
                configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(typeof(DependencyInjectionContainer).Assembly);

            services.AddTransient<PriceDomainService>();

            return services;
        }
    }
}
