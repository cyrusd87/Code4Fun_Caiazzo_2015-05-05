using System.IO;
using System.Text;
using Code4Fun.Model;

namespace Code4Fun.Repository
{
    public class FileRepository : IRepository
    {
        private readonly IBinaryToTsvSerializator _serializator;

        public FileRepository(IBinaryToTsvSerializator serializator)
        {
            _serializator = serializator;
        }

        public ITsvFile LoadBinary(string fileName)
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

        public ITsvFile LoadTsvFile(string fileName)
        {
            var content = File.ReadAllLines(fileName);
            return _serializator.DeserializeTsv(string.Join("\n",content));
        }

        public void Save(ITsvFile tsvFile, string fileName)
        {
            var serialized = _serializator.SerializeTsv(tsvFile);
            File.WriteAllText(fileName,serialized);
        }
    }
}
