using Microsoft.Extensions.DependencyInjection;
using RuleEngine.Configure;
using RuleEngine.Enums;
using RuleEngine.Interfaces;
using System.Threading;

namespace RuleEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddOptions();
            services.AddCoreServices();

            var provider = services.BuildServiceProvider();

            var instanceGeneratorService = provider.GetService<IInstancesGeneratorService>();

            instanceGeneratorService.CreateInstances();
            instanceGeneratorService.AddRule(TurbineAggregation.All); // For this simulation purpose I'm using All rule (can be Any and Single as well)

            do
            {
                instanceGeneratorService.GenerateLiveEvents();
                var liveEvents = instanceGeneratorService.GetLiveEvents();
                Thread.Sleep(600 * 1000);
            } while (true);
        }
    }
}
