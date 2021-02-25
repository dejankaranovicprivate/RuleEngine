using RuleEngine.Enums;
using System.Collections.Generic;

namespace RuleEngine.Model
{
    public class Rule
    {
        public List<int> TurbineIds { get; set; }
        public TurbineAggregation TurbineAggregation { get; set; }
        public List<int> ForbiddenEvents { get; set; }
        public List<int> RequiredEvents { get; set; }
        public string Diagnosis { get; set; }
    }
}
