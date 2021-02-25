using RuleEngine.Enums;
using RuleEngine.Interfaces;
using RuleEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RuleEngine.Services
{
    public class TurbineAggregationService : ITurbineAggregationService
    {
        #region Public Methods

        public List<int> GetTurbinesPerAggregation(List<Turbine> turbines, TurbineAggregation turbineAggregation)
        {
            var turbinesPerAggregation = new List<int>();

            switch (turbineAggregation)
            {
                case TurbineAggregation.All:
                    {
                        turbinesPerAggregation = turbines.Select(t => t.Id).Take(5).ToList(); // Taking first five for simulation purpose
                        break;
                    }
                case TurbineAggregation.Any:
                    {
                        turbinesPerAggregation = turbines.Skip(5).Take(3).Select(t => t.Id).ToList(); // Taking between the sixth and eighth for simulation purpose
                        break;
                    }
                case TurbineAggregation.Single:
                    {
                        turbinesPerAggregation = turbines.Skip(8).Select(t => t.Id).ToList(); // Taking last two for simulation purpose
                        break;
                    }
            }

            return turbinesPerAggregation;
        }

        public void GenerateLiveEventsBasedOnRule(Rule rule, List<LiveEvent> liveEvents, List<Event> events)
        {
            switch (rule.TurbineAggregation)
            {
                case TurbineAggregation.All:
                    {
                        foreach (var turbineId in rule.TurbineIds)
                        {
                            AddLiveEventToList(rule, liveEvents, events, turbineId);
                        }
                        break;
                    }
                case TurbineAggregation.Any:
                    {
                        foreach (var turbineId in rule.TurbineIds.Take(2)) // Taking two turbines for testing purpose
                        {
                            AddLiveEventToList(rule, liveEvents, events, turbineId);
                        }
                        break;
                    }
                case TurbineAggregation.Single:
                    {
                        foreach (var turbineId in rule.TurbineIds.Take(1))
                        {
                            AddLiveEventToList(rule, liveEvents, events, turbineId);
                        }
                        break;
                    }
            }
        }

        #endregion

        #region Private Methods

        private void AddLiveEventToList(Rule rule, List<LiveEvent> liveEvents, List<Event> events, int turbineId)
        {
            liveEvents.Add(new LiveEvent()
            {
                TurbineId = turbineId,
                EventIds = events.Where(e => rule.RequiredEvents.Contains(e.Id) && !rule.ForbiddenEvents.Contains(e.Id)).Select(e => e.Id).ToList(),
                Timestamp = DateTime.Now
            });
        }

        #endregion
    }
}
