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

using Laborare.Core.Services;

namespace Akoustis90142UI.Views
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            try
            {
                InitializeComponent();
                MainHandlerService.InitializeApp();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        private void Diagnostic_Btn_Click(object sender, RoutedEventArgs e)
        {
            PasswordView PasswordView = new PasswordView();
            PasswordView.Show();
        }
    }
}
