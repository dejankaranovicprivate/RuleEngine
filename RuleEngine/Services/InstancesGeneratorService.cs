using RuleEngine.Enums;
using RuleEngine.Interfaces;
using RuleEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RuleEngine.Services
{
    public class InstancesGeneratorService : IInstancesGeneratorService
    {
        private readonly List<Turbine> turbines = new List<Turbine>();
        private readonly List<Event> events = new List<Event>();
        private readonly List<Rule> rules = new List<Rule>();
        private readonly List<LiveEvent> liveEvents = new List<LiveEvent>();

        public void CreateInstances()
        {
            turbines.Add(new Turbine { Id = "1", Name = "Turbine 1" });
            turbines.Add(new Turbine { Id = "2", Name = "Turbine 2" });
            turbines.Add(new Turbine { Id = "3", Name = "Turbine 3" });

            events.Add(new Event { Id = "1", Description = "Generator is running out of oil." });
            events.Add(new Event { Id = "2", Description = "Rotor blade is damaged." });
            events.Add(new Event { Id = "3", Description = "Rotor hum is damaged." });
            events.Add(new Event { Id = "4", Description = "Gearbox requires servicing." });
            events.Add(new Event { Id = "5", Description = "Connection to the electric grid is broken." });
            events.Add(new Event { Id = "6", Description = "Wind orientation control can't receive right information." });
        }

        public void AddRule(TurbineAggregation turbineAggregation)
        {
            rules.Add(new Rule()
            {
                TurbineIds = turbines.Select(t => t.Id).ToList(),
                TurbineAggregation = turbineAggregation,
                ForbiddenEvents = new List<string>(),
                RequiredEvents = events.Where(e => e.Id.Equals("1")).Select(e => e.Id).ToList(), // at least one required event
                Diagnosis = "Diagnosis for " + turbineAggregation.ToString() + " rule"
            });
        }

        public void GenerateLiveEvents()
        {
            foreach(var rule in rules)
            {
                GenerateLiveEventsBasedOnRule(rule.TurbineAggregation);
            }
        }

        private void GenerateLiveEventsBasedOnRule(TurbineAggregation turbineAggregation)
        {
            if (turbineAggregation == TurbineAggregation.All)
            {
                foreach(var turbine in turbines)
                {
                    liveEvents.Add(new LiveEvent()
                    {
                        TurbineId = turbine.Id,
                        EventIds = events.Select(e => e.Id).ToList(),
                        Timestamp = DateTime.Now
                    });
                }
            }
        }

        public List<LiveEvent> GetLiveEvents()
        {
            return liveEvents;
        }
    }
}
