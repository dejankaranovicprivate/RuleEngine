using System;
using System.Collections.Generic;

namespace RuleEngine.Model
{
    public class LiveEvent
    {
        public int TurbineId { get; set; }
        public List<int> EventIds { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
