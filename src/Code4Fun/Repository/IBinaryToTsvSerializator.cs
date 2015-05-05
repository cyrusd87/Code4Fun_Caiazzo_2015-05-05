using Code4Fun.Core.Model;

namespace Code4Fun.Core.Repository
{
    public interface IBinaryToTsvSerializator
    {
        ITsvFile DeserializeTsv(string content);
        string SerializeTsv(ITsvFile tsvFile);
    }
}