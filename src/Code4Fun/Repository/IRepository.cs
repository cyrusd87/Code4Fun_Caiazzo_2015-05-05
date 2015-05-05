using Code4Fun.Model;

namespace Code4Fun.Repository
{
    public interface IRepository
    {
        ITsvFile Load(string fileName);
        void Save(ITsvFile tsvFile, string fileName);
    }
}
