using System.Linq;
using Code4Fun.Core.Model;

namespace Code4Fun.Core.Services
{
    public class TotalBandWidthCalculatorService : ICalculatorService
    {
        private readonly ITsvFile[] _tsvFiles;

        public TotalBandWidthCalculatorService(ITsvFile[] tsvFiles)
        {
            _tsvFiles = tsvFiles;
        }

        public double Calculate()
        {
            var bandWidthLines = _tsvFiles.SelectMany(x => x.TsvLines).Where(x => x.Key.Equals("bandwidth")).ToArray();

            if (bandWidthLines.Any())
            {
                return bandWidthLines.Sum(x => double.Parse(x.Value));
            }
            return 0.0;
        }
    }
}
