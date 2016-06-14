using ProjetFlavienValentin.ViewModel;
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

namespace ProjetFlavienValentin
{
    /// <summary>
    /// Logique d'interaction pour ConnectUserWindow.xaml
    /// </summary>
    public partial class ConnectUserWindow : Window
    {
        private ConnectUserWindowViewModel _viewModel;
        public ConnectUserWindow()
        {
            InitializeComponent();

            _viewModel = new ConnectUserWindowViewModel();
            DataContext = _viewModel;
        }
    }
}
