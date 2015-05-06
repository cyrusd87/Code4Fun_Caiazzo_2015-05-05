using System.ComponentModel;
using System.Windows.Input;
using Code4Fun.App.Annotations;
using Code4Fun.App.Commands;
using Code4Fun.App.Presenters;
using Code4Fun.Core.Repository;
using Code4Fun.Core.Services;

namespace Code4Fun.App
{
    public class MainViewModel : INotifyPropertyChanged, ICalculatorResultPresenter
    {
        private string _averageLatencyText;
        private string _totalBandWidthText;

        public MainViewModel()
        {
            ConvertBinaryToTsvCommand = new ConvertBinaryToTsvCommand(new FileRepository(new BinaryToTsvFileAdapter()),new ChooserFileName(), new MessagePresenter());
            ConvertBinariesToTsvCommand = new ConvertBinariesToTsvCommand(new FileRepository(new BinaryToTsvFileAdapter()), new ChooserDirectoryName(), new MessagePresenter());
            CalculateLatencyAverageFromBinariesCommand = new CalculateLatencyAverageFromBinariesCommand(new FileRepository(new BinaryToTsvFileAdapter()), new ChooserDirectoryName(), new AverageLatencyCalculatorService(),this,new MessagePresenter());
            CalculateTotalBandwidthFromBinariesCommand = new CalculateTotalBandwidthFromBinariesCommand(new FileRepository(new BinaryToTsvFileAdapter()), new ChooserDirectoryName(), new TotalBandWidthCalculatorService(), this, new MessagePresenter());
        }

        public ICommand ConvertBinaryToTsvCommand { get; set; }
        public ICommand ConvertBinariesToTsvCommand { get; set; }
        public ICommand CalculateLatencyAverageFromBinariesCommand { get; set; }
        public ICommand CalculateTotalBandwidthFromBinariesCommand { get; set; }

        public string AverageLatencyText
        {
            get { return _averageLatencyText; }
            set
            {
                if (value == _averageLatencyText) return;
                _averageLatencyText = value;
                OnPropertyChanged("AverageLatencyText");
            }
        }

        public string TotalBandWidthText
        {
            get { return _totalBandWidthText; }
            set
            {
                if (value == _totalBandWidthText) return;
                _totalBandWidthText = value;
                OnPropertyChanged("TotalBandWidthText");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}