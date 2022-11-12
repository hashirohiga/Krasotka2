using Krasotka2.Entities;
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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    
    public partial class UserWindow : Window
    {
        
        public UserWindow(User user,Window window)
        {
            InitializeComponent();
            window.Close();
            DataContext = new UserViewModel(user);
        }

        private void btnExit(object sender, RoutedEventArgs e)
        {
            new LoginWindow(this).ShowDialog();
            
        }
    }
}
