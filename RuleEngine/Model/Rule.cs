using RuleEngine.Enums;
using System.Collections.Generic;

namespace RuleEngine.Model
{
    public class Rule
    {
        public List<string> TurbineIds { get; set; }
        public TurbineAggregation TurbineAggregation { get; set; }
        public List<string> ForbiddenEvents { get; set; }
        public List<string> RequiredEvents { get; set; }
        public string Diagnosis { get; set; }
    }
}
