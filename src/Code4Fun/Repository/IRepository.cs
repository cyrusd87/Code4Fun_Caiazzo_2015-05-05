using Code4Fun.Core.Model;

namespace Code4Fun.Core.Repository
{
    public interface IRepository
    {
        ITsvFile LoadBinary(string fileName);
        ITsvFile LoadTsvFile(string fileName);
        void Save(ITsvFile tsvFile, string fileName);
    }
}
