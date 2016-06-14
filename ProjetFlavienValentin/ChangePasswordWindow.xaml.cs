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
    /// Logique d'interaction pour ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        private ChangePasswordWindowViewModel _viewModel;
        public ChangePasswordWindow()
        {
            InitializeComponent();

            _viewModel = new ChangePasswordWindowViewModel();
            DataContext = _viewModel;
        }
    }
}
