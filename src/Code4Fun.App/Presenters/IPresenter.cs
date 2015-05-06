using System;

namespace Code4Fun.App.Presenters
{
    public interface IPresenter
    {
        void Notify(string message);
        void NotifyError(Exception exception);
    }
}