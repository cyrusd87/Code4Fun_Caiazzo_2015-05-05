using Code4Fun.Model;

namespace Code4Fun.Repository
{
    public class BinaryToTsvFileAdapter : IBinaryToTsvSerializator
    {
        public ITsvFile DeserializeTsv(string content)
        {
            var tsvFile = new TsvFile();
            foreach (var line in content.Split('\n'))
            {
                tsvFile.AddLine(DeserializeTsvLine(line));
            }
            return tsvFile;
        }

        private ITsvLine DeserializeTsvLine(string content)
        {
            var tsvLineString = content.Split('\t');
            return new TsvLine(tsvLineString[0], tsvLineString[1]);
        }
    }
}