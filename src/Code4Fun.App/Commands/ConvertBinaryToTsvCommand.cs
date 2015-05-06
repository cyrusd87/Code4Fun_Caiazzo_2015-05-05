using System;
using System.Windows.Input;
using Code4Fun.App.Presenters;
using Code4Fun.Core.Repository;
using Microsoft.Win32;

namespace Code4Fun.App.Commands
{
    public class ConvertBinaryToTsvCommand : ICommand
    {
        private readonly IRepository _repository;
        private readonly IChooserFileName _chooserFileName;
        private readonly IPresenter _presenter;

        public ConvertBinaryToTsvCommand(IRepository repository, IChooserFileName chooserFileName, IPresenter presenter)
        {
            _repository = repository;
            _chooserFileName = chooserFileName;
            _presenter = presenter;
        }

        public void Execute(object parameter)
        {
            try
            {
                var fileName = _chooserFileName.Choose();
              
                var loaded = _repository.LoadBinary(fileName);
                _repository.Save(loaded,fileName);

                _presenter.Notify("Convertion completed with success");
            }
            catch (Exception e)
            {
                _presenter.NotifyError(e);
            }
            
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }

    public class ChooserFileName : IChooserFileName
    {
        public string Choose()
        {
            FileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            return dialog.FileName;
        }
    }
}
