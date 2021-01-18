using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Akoustis90142UI.ViewModels;

namespace Akoustis90142UI.Views
{
    /// <summary>
    /// Interaction logic for TrayConfigurationView.xaml
    /// </summary>
    public partial class TrayConfigurationView : UserControl
    {
        public TrayConfigurationView()
        {
            InitializeComponent();
            this.DataContext = new TrayConfigurationViewModel();
        }
<<<<<<< HEAD

        private void AdvancedFineTune_btn_Click(object sender, RoutedEventArgs e)
        {
            TrayFineTuneConfigurationView FineTuneWindow = new TrayFineTuneConfigurationView();
            FineTuneWindow.Show();
        }
=======
>>>>>>> 20346694a5809b33e26dfeb5b6e758453bb83487
    }
}
