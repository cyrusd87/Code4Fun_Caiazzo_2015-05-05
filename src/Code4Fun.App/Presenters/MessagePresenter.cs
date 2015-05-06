using System;

namespace Code4Fun.App.Presenters
{
    public class MessagePresenter : IPresenter
    {
        public void Notify(string message)
        {
            System.Windows.Forms.MessageBox.Show(message);
        }

        public void NotifyError(Exception exception)
        {
            System.Windows.Forms.MessageBox.Show(exception.ToString());
        }
    }
}
