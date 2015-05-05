using System.Collections.Generic;
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

        public ITsvFile Load(string fileName)
        {
            var stringBuilder = new StringBuilder();
            using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var binaryReader = new BinaryReader(fileStream))
                {
                    while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
                    {
                        stringBuilder.AppendLine(binaryReader.ReadString());
                    }
                }
                
            }
            return _serializator.DeserializeTsv(stringBuilder.ToString());
        }

        public void Save(ITsvFile tsvFile)
        {
            throw new System.NotImplementedException();
        }
    }
}
