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
        private readonly ITurbineAggregationService _turbineAggregationService;

        private readonly List<Turbine> turbines = new List<Turbine>();
        private readonly List<Event> events = new List<Event>();
        private readonly List<Rule> rules = new List<Rule>();
        private readonly List<LiveEvent> liveEvents = new List<LiveEvent>();

        public InstancesGeneratorService(ITurbineAggregationService turbineAggregationService)
        {
            _turbineAggregationService = turbineAggregationService;
        }

        public void CreateInstances()
        {
            turbines.Add(new Turbine { Id = 1, Name = "Turbine 1" });
            turbines.Add(new Turbine { Id = 2, Name = "Turbine 2" });
            turbines.Add(new Turbine { Id = 3, Name = "Turbine 3" });
            turbines.Add(new Turbine { Id = 4, Name = "Turbine 4" });
            turbines.Add(new Turbine { Id = 5, Name = "Turbine 5" });
            turbines.Add(new Turbine { Id = 6, Name = "Turbine 6" });
            turbines.Add(new Turbine { Id = 7, Name = "Turbine 7" });
            turbines.Add(new Turbine { Id = 8, Name = "Turbine 8" });
            turbines.Add(new Turbine { Id = 9, Name = "Turbine 9" });
            turbines.Add(new Turbine { Id = 10, Name = "Turbine 10" });

            events.Add(new Event { Id = 1, Description = "Generator is running out of oil." });
            events.Add(new Event { Id = 2, Description = "Rotor blade is damaged." });
            events.Add(new Event { Id = 3, Description = "Rotor hum is damaged." });
            events.Add(new Event { Id = 4, Description = "Gearbox requires servicing." });
            events.Add(new Event { Id = 5, Description = "Connection to the electric grid is broken." });
            events.Add(new Event { Id = 6, Description = "Wind orientation control can't receive right information." });
            events.Add(new Event { Id = 7, Description = "Blade pitch control is broken." });
            events.Add(new Event { Id = 8, Description = "Anemometer requires repair." });
            events.Add(new Event { Id = 9, Description = "The tower is detected an earthquake." });
            events.Add(new Event { Id = 10, Description = "Nacelle is broken." });
        }

        public void AddRule(TurbineAggregation turbineAggregation)
        {
            rules.Add(new Rule()
            {
                TurbineIds = _turbineAggregationService.GetTurbinesPerAggregation(turbines, turbineAggregation),
                TurbineAggregation = turbineAggregation,
                ForbiddenEvents = events.Take(2).Select(e => e.Id).ToList(), // Taking first two for simulation purpose
                RequiredEvents = events.Take(5).Select(e => e.Id).ToList(), // Taking first five for simulation purpose
                Diagnosis = "Diagnosis for " + turbineAggregation.ToString() + " rule"
            });
        }

        public void GenerateLiveEvents()
        {
            foreach(var rule in rules)
            {
                _turbineAggregationService.GenerateLiveEventsBasedOnRule(rule, liveEvents, events);
            }
        }

        public List<LiveEvent> GetLiveEvents()
        {
            return liveEvents;
        }
    }
}
