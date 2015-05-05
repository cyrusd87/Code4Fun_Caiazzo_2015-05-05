using System.Collections.Generic;

namespace Code4Fun.Repository
{
    public interface IRepository
    {
        string Load(string fileName);
        void Save(Dictionary<string, string> fileName);
    }
}
