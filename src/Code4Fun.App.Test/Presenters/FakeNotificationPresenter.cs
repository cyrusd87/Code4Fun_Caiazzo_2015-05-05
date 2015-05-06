using System;
using Code4Fun.App.Presenters;

namespace Code4Fun.App.Test.Commands
{
    public class FakeNotificationPresenter : IPresenter
    {
        public void Notify(string message)
        {
        }

        public void NotifyError(Exception exception)
        {
        }
    }
}