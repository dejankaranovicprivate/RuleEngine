using RuleEngine.Enums;
using RuleEngine.Model;
using System.Collections.Generic;

namespace RuleEngine.Interfaces
{
    public interface ITurbineAggregationService
    {
        List<int> GetTurbinesPerAggregation(List<Turbine> turbines, TurbineAggregation turbineAggregation);

        void GenerateLiveEventsBasedOnRule(Rule rule, List<LiveEvent> liveEvents, List<Event> events);
    }
}
