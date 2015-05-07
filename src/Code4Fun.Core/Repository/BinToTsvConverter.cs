using System.IO;
using System.Text;
using Code4Fun.Core.Model;

namespace Code4Fun.Core.Repository
{
    public class BinToTsvConverter 
    {
        private readonly BinToTsvFileAdapter _serializator;

        public BinToTsvConverter(BinToTsvFileAdapter serializator)
        {
            _serializator = serializator;
        }

        public TsvFile Convert(string fileName)
        {
            var stringBuilder = new StringBuilder();
            using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var binaryReader = new BinaryReader(fileStream))
                {
                    while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                    {
                        var stringRead = binaryReader.ReadString();

                        if (!string.IsNullOrWhiteSpace(stringRead))
                        {
                            stringBuilder.AppendLine(stringRead);
                        }
                    }
                }
            }

            return _serializator.DeserializeTsv(stringBuilder.ToString());
        }
    }
}
