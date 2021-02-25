using RuleEngine.Enums;
using RuleEngine.Model;
using System.Collections.Generic;

namespace RuleEngine.Interfaces
{
    public interface IInstancesGeneratorService
    {
        void CreateInstances();

        void AddRule(TurbineAggregation turbineAggregation);

        void GenerateLiveEvents();

        List<LiveEvent> GetLiveEvents();

        List<Rule> GetRules();

        void ResetLiveEvents();
    }
}
