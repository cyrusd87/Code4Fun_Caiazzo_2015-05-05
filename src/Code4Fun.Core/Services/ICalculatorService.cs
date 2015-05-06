using Code4Fun.Core.Model;

namespace Code4Fun.Core.Services
{
    public interface ICalculatorService
    {
        double Calculate(ITsvFile[] tsvFiles);
    }
}
