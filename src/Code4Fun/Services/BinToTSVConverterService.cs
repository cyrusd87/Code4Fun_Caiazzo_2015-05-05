
using Code4Fun.Core.Repository;

namespace Code4Fun.Core.Services
{
    public class BinToTsvConverterService
    {
        private readonly IRepository _repository;

        public BinToTsvConverterService(IRepository repository)
        {
            _repository = repository;
        }

        public void Convert(string fileName)
        {
            var tsvFile = _repository.LoadBinary(fileName);
            _repository.Save(tsvFile, fileName);

        }
    }
}
