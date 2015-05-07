using System.Collections.Generic;
using System.Linq;
using Code4Fun.Core.Model;

namespace Code4Fun.Core.Services
{
    public class AverageLatencyCalculatorService
    {
        public double Calculate(IEnumerable<TsvFile> tsvFiles)
        {
            var latencyLines = tsvFiles.SelectMany(x => x.TsvLines).Where(x => x.Key.Equals("latency_ms")).ToArray();
            
            if (latencyLines.Any())
            {
                return latencyLines.Average(x => double.Parse(x.Value));
            }
            return 0.0;
        }
    }
}
