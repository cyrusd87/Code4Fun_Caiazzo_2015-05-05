using Code4Fun.App.Presenters;

namespace Code4Fun.App.Test.Commands
{
    public class FakeResultPresenter : ICalculatorResultPresenter
    {
        public string AverageLatencyText { get; set; }
        public string TotalBandWidthText { get; set; }
    }
}