using System.Linq;
using System.Text;
using Code4Fun.Core.Model;

namespace Code4Fun.Core.Repository
{
    public class BinToTsvFileAdapter 
    {
        public TsvFile DeserializeTsv(string content)
        {
            var tsvFile = new TsvFile();
            foreach (var line in content.Split('\n').Where(x => !string.IsNullOrEmpty(x)))
            {
                tsvFile.AddLine(DeserializeTsvLine(line.Trim()));
            }
            return tsvFile;
        }

        private TsvLine DeserializeTsvLine(string content)
        {
            var tsvLineString = content.Split('\t');
            return new TsvLine(tsvLineString[0], tsvLineString[1]);
        }
    }
}