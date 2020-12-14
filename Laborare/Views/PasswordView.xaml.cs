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
using System.Windows.Shapes;

namespace Laborare.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PasswordView : Window
    {
        public PasswordView()
        {
            InitializeComponent();
        }

        private void Login_btn_Click(object sender, RoutedEventArgs e)
        {
            if (password_box.Password.ToString() == "P2")
            {
                DiagnosticsView DiagnosticsWindow = new DiagnosticsView();
                DiagnosticsWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect Password. Please try again.");
            }
        }
    }
}
