using Grido.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
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

namespace Grido.Pages
{
    /// <summary>
    /// Логика взаимодействия для WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        private User User;

        public WelcomePage(MainWindow mv)
        {
            InitializeComponent();
            DataContext = this;
        }

        public void GetUserInfo()
            => User = new() { Login = loginTextBox.Text, Nickname = nicknameTextBox.Text, Password = passwordTextBox.Text };

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetUserInfo();

            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }

        private void Auth_Click(object sender, RoutedEventArgs e)
        {
            GetUserInfo();
        }

        private void NoAuth_Click(object sender, RoutedEventArgs e)
        {
            GetUserInfo();
        }
    }
}
