
namespace Akoustis90142UI.Views
{
    using Laborare.Core.Services;

    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();
            USBIOBoardService.Start();
            MainHandlerService.InitializeIoDeviceLocations();
            MainHandlerService.InitializeRs232Devices();
            MainHandlerService.InitializeTcpDevices();
        }

        private void Diagnostic_Btn_Click(object sender, RoutedEventArgs e)
        {
            PasswordView PasswordView = new PasswordView();
            PasswordView.Show();
        }
    }
}
