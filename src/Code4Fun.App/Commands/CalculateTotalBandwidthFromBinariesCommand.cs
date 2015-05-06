using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Input;
using Code4Fun.App.Presenters;
using Code4Fun.Core.Model;
using Code4Fun.Core.Repository;
using Code4Fun.Core.Services;

namespace Code4Fun.App.Commands
{
    public class CalculateTotalBandwidthFromBinariesCommand : ICommand
    {
        private readonly FileRepository _fileRepository;
        private readonly IChooserDirectoryName _chooserDirectoryName;
        private readonly ICalculatorService _calculatorService;
        private readonly ICalculatorResultPresenter _calculatorResultPresenter;
        private readonly IPresenter _messagePresenter;

        public CalculateTotalBandwidthFromBinariesCommand(FileRepository fileRepository, IChooserDirectoryName chooserDirectoryName,ICalculatorService calculatorService ,ICalculatorResultPresenter calculatorResultPresenter, IPresenter messagePresenter)
        {
            _fileRepository = fileRepository;
            _chooserDirectoryName = chooserDirectoryName;
            _calculatorService = calculatorService;
            _calculatorResultPresenter = calculatorResultPresenter;
            _messagePresenter = messagePresenter;
        }

        public void Execute(object parameter)
        {
            try
            {
                _calculatorResultPresenter.AverageLatencyText = "0";
                _calculatorResultPresenter.TotalBandWidthText = "0";

                var tsvFiles = new List<ITsvFile>();

                foreach (var file in Directory.GetFiles(_chooserDirectoryName.Choose()))
                {
                    tsvFiles.Add(_fileRepository.LoadBinary(file));
                }

                _calculatorResultPresenter.TotalBandWidthText = _calculatorService.Calculate(tsvFiles.ToArray()).ToString(CultureInfo.InvariantCulture);

                _messagePresenter.Notify("Total bandwidth has been calculated");
            }
            catch (Exception ex)
            {
                _messagePresenter.NotifyError(ex);
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}