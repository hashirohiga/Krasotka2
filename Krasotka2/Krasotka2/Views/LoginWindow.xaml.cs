using Krasotka2.ViewModels;
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

namespace Krasotka2.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private LoginViewModel _viewModel;

        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        public LoginWindow(Window window)
        {
            InitializeComponent();
            window.Close();
            DataContext = new LoginViewModel();
            
        }



        private void SignIn(object sender, RoutedEventArgs e)
        {
            _viewModel = (LoginViewModel)DataContext;
            if (_viewModel.Sign() != null)
                new UserWindow(_viewModel.Sign(),this).ShowDialog();
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
                _viewModel.Login = string.Empty;
                _viewModel.Password = string.Empty;
            }
        }

        private void btnCustomer(object sender, RoutedEventArgs e)
        {
            new CustomerWindow(this).ShowDialog();
            
        }
    }
}
