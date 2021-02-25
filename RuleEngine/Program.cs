using Microsoft.Extensions.DependencyInjection;
using RuleEngine.Configure;
using RuleEngine.Enums;
using RuleEngine.Interfaces;
using System;
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
            var writerService = provider.GetService<IWriterService>();

            instanceGeneratorService.CreateInstances();
            foreach(var turbineAggregation in Enum.GetValues(typeof(TurbineAggregation)))
            {
                instanceGeneratorService.AddRule((TurbineAggregation)turbineAggregation);
            }

            do
            {
                instanceGeneratorService.GenerateLiveEvents();

                var liveEvents = instanceGeneratorService.GetLiveEvents();
                var rules = instanceGeneratorService.GetRules();

                writerService.WriteDiagnosis(liveEvents, rules);

                instanceGeneratorService.ResetLiveEvents();
                Thread.Sleep(600 * 1000);
            } 
            while (true);
        }
    }
}
