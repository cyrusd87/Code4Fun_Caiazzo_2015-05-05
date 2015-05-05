
using Code4Fun.Repository;

namespace Code4Fun.Services
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
