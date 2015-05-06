using System.Windows.Forms;

namespace Code4Fun.App.Commands
{
    public class ChooserDirectoryName : IChooserDirectoryName
    {
        public string Choose()
        {
            var folderBrowseDialog = new FolderBrowserDialog();
            folderBrowseDialog.ShowDialog();
            return folderBrowseDialog.SelectedPath;
        }
    }
}