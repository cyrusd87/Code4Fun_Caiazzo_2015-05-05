using Code4Fun.Model;

namespace Code4Fun.Repository
{
    public interface IBinaryToTsvSerializator
    {
        ITsvFile DeserializeTsv(string content);
        string SerializeTsv(ITsvFile tsvFile);
    }
}