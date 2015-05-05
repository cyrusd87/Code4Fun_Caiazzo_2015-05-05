using System.Linq;
using Code4Fun.Model;

namespace Code4Fun.Services
{
    public class AverageLatencyCalculatorService : ICalculatorService
    {
        private readonly ITsvFile[] _tsvFiles;

        public AverageLatencyCalculatorService(ITsvFile[] tsvFiles)
        {
            _tsvFiles = tsvFiles;
        }

        public double Calculate()
        {
            var latencyLines = _tsvFiles.SelectMany(x => x.TsvLines).Where(x => x.Key.Equals("latency_ms")).ToArray();
            if (latencyLines.Any())
            {

                return latencyLines.Average(x => double.Parse(x.Value));
            }
            return 0.0;
        }
    }
}
