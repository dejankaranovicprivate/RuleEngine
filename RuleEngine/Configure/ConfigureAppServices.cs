using Microsoft.Extensions.DependencyInjection;
using RuleEngine.Interfaces;
using RuleEngine.Services;

namespace RuleEngine.Configure
{
    public static class ConfigureAppServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddSingleton<IInstancesGeneratorService, InstancesGeneratorService>();
            services.AddSingleton<ITurbineAggregationService, TurbineAggregationService>();

            return services;
        }
    }
}
