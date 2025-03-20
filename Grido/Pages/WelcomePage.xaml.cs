using Grido.Models;
using Grido.OtherLogic;
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
        readonly ApiController api = ApiController.Inst;
        MainWindow mv;

        public WelcomePage(MainWindow mv)
        {
            this.mv = mv;
            InitializeComponent();
            DataContext = this;
        }

        public void GetUserInfo()
            => User = new() { Login = loginTextBox.Text, Nickname = nicknameTextBox.Text, Password = passwordTextBox.Text };

        private async void Reg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetUserInfo();
                if (string.IsNullOrEmpty(User.Login) || string.IsNullOrEmpty(User.Password))
                    MessageBox.Show("Вы заполнили не все обязательные поля! (логин и пароль являются обязательными)");
                else
                {
                    if (string.IsNullOrEmpty(User.Nickname))
                        MessageBox.Show("Позднее вы сможете заполнить ник в личном кабинете!");
                    if (await api.Registration(User))
                    {
                        var responce = await api.Authorisation(User);
                        if (responce.Login == User.Login &&
                            responce.Password == User.Password)
                        {
                            User = responce;
                            mv.CurrentPage = new MainPage(mv, User);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void Auth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetUserInfo();
                if (string.IsNullOrEmpty(User.Login) || string.IsNullOrEmpty(User.Password))
                {
                    MessageBox.Show("Вы заполнили не все обязательные поля! (логин и пароль являются обязательными)");
                    return;
                }
                var responce = await api.Authorisation(User);
                if (responce.Login == User.Login &&
                    responce.Password == User.Password)
                {
                    User = responce;
                    mv.CurrentPage = new MainPage(mv, User);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void NoAuth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetUserInfo();
                if (!string.IsNullOrEmpty(User.Login) || !string.IsNullOrEmpty(User.Password))
                {
                    var mb = MessageBox.Show("Вы уверены, что хотите войти без регистрации?", "Уведомление", MessageBoxButton.YesNo);
                    if (mb == MessageBoxResult.No)
                        return;
                }
                MessageBox.Show("Вы пытаетесь войти без регистрации, в таком случае функционал очень сильно ограничен! Позже вы можте войти в личном кабинете, чтобы увеличить доступ к функционалу!", "Уведомление");
                User = await api.Authorisation(User);
                mv.CurrentPage = new MainPage(mv, User);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
