using RuleEngine.Model;
using System.Collections.Generic;

namespace RuleEngine.Interfaces
{
    public interface IWriterService
    {
        void WriteDiagnosis(List<LiveEvent> liveEvents, List<Rule> rules);
    }
}
