

namespace Laborare.Views.Akoustis_901_42
{
    using Laborare.ViewModels.Akoustis_901_42;

    using System.Windows.Controls;
    /// <summary>
    /// Interaction logic for IOCheckView.xaml
    /// </summary>
    public partial class IOCheckView : UserControl
    {
        public IOCheckView()
        {
            InitializeComponent();
            this.DataContext = new IOCheckViewModel();
        }

        private void io_boards_list_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
        }
    }
}
