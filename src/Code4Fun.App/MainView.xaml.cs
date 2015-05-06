using System.Windows;

namespace Code4Fun.App
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            DataContext = new MainViewModel();
            InitializeComponent();
        }
    }
}
