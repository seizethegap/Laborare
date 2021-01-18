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
<<<<<<< HEAD
                MainHandlerService.InitializeApp();
=======
                USBIOBoardService.Start();
                MainHandlerService.InitializeIoDeviceLocations();
                MainHandlerService.InitializeRs232Devices();
                MainHandlerService.InitializeTcpDevices();
                MainHandlerService.InitializeTrays();
                MainHandlerService.InitializePrecisors();
                MainHandlerService.InitializeTestSockets();
>>>>>>> 20346694a5809b33e26dfeb5b6e758453bb83487
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
