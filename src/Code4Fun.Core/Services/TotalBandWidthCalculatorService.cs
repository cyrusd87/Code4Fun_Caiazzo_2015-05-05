using System.Linq;
using Code4Fun.Core.Model;

namespace Code4Fun.Core.Services
{
    public class TotalBandWidthCalculatorService 
    {
        public double Calculate(TsvFile[] tsvFiles)
        {
            var bandWidthLines = tsvFiles.SelectMany(x => x.TsvLines).Where(x => x.Key.Equals("bandwidth")).ToArray();

            if (bandWidthLines.Any())
            {
                return bandWidthLines.Sum(x => double.Parse(x.Value));
            }
            return 0.0;
        }
    }
}
