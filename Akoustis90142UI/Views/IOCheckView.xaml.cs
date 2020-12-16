﻿
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
