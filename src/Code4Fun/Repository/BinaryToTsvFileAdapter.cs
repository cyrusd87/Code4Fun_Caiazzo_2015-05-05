using System.Linq;
using System.Text;
using Code4Fun.Model;

namespace Code4Fun.Repository
{
    public class BinaryToTsvFileAdapter : IBinaryToTsvSerializator
    {
        public ITsvFile DeserializeTsv(string content)
        {
            var tsvFile = new TsvFile();
            foreach (var line in content.Split('\n').Where(x => !string.IsNullOrEmpty(x)))
            {
                tsvFile.AddLine(DeserializeTsvLine(line.Trim()));
            }
            return tsvFile;
        }

        public string SerializeTsv(ITsvFile tsvFile)
        {
            var serialized = new StringBuilder();
            foreach (var tsvLine in tsvFile.TsvLines)
            {
                serialized.AppendLine(string.Format("{0}\t{1}",tsvLine.Key,tsvLine.Value));
            }
            return serialized.ToString();
        }

        private ITsvLine DeserializeTsvLine(string content)
        {
            var tsvLineString = content.Split('\t');
            return new TsvLine(tsvLineString[0], tsvLineString[1]);
        }
    }
}