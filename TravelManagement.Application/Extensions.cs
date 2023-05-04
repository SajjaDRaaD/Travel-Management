using Microsoft.Extensions.DependencyInjection;
using TravelManagement.Domain.Factories;
using TravelManagement.Domain.Policies;
using TravelManagement.Shared.Commands;

namespace TravelManagement.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommands();
            services.AddScoped<ITravelerCheckListFactory, TravelerCheckListFactory>();

            services.Scan(s => s.FromAssemblies(typeof(ITravelerItemPolicy).Assembly)
            .AddClasses(c => c.AssignableTo<ITravelerItemPolicy>())
            .AsImplementedInterfaces()
            .WithSingletonLifetime());

            return services;
        }
    }
}
