using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Code4Fun.Repository
{
    public class FileBinaryRepository : IRepository
    {
        public string Load(string fileName)
        {
            var stringBuilder = new StringBuilder();
            using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var binaryReader = new BinaryReader(fileStream))
                {
                    while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
                    {
                        stringBuilder.Append(binaryReader.ReadString());
                    }
                }
                
            }
            return stringBuilder.ToString();
        }

        public void Save(Dictionary<string, string> fileName)
        {
            throw new System.NotImplementedException();
        }
    }
}
