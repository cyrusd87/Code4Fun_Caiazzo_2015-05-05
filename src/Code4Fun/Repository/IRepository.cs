using Code4Fun.Model;

namespace Code4Fun.Repository
{
    public interface IRepository
    {
        ITsvFile LoadBinary(string fileName);
        ITsvFile LoadTsvFile(string fileName);
        void Save(ITsvFile tsvFile, string fileName);
    }
}
