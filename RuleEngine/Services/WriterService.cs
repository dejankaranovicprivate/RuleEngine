using RuleEngine.Interfaces;
using RuleEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RuleEngine.Services
{
    public class WriterService : IWriterService
    {
        public void WriteDiagnosis(List<LiveEvent> liveEvents, List<Rule> rules)
        {
            foreach (var rule in from liveEvent in liveEvents
                                 from rule in rules
                                 where rule.TurbineIds.Contains(liveEvent.TurbineId)
                                 select rule)
            {
                Console.WriteLine(rule.Diagnosis);
            }
        }
    }
}
