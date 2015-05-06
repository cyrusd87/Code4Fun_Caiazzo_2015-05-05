using System;
using System.IO;
using System.Windows.Input;
using Code4Fun.App.Presenters;
using Code4Fun.Core.Repository;

namespace Code4Fun.App.Commands
{
    public class ConvertBinariesToTsvCommand : ICommand
    {
        private readonly FileRepository _fileRepository;
        private readonly IChooserDirectoryName _chooserDirectoryName;
        private readonly IPresenter _messagePresenter;

        public ConvertBinariesToTsvCommand(FileRepository fileRepository, IChooserDirectoryName chooserDirectoryName, IPresenter messagePresenter)
        {
            _fileRepository = fileRepository;
            _chooserDirectoryName = chooserDirectoryName;
            _messagePresenter = messagePresenter;
        }

        public void Execute(object parameter)
        {
            try
            {
                foreach (var file in Directory.GetFiles(_chooserDirectoryName.Choose()))
                {
                    var loaded = _fileRepository.LoadBinary(file);
                    _fileRepository.Save(loaded,file);
                }
                _messagePresenter.Notify("All files in directory are converted");
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