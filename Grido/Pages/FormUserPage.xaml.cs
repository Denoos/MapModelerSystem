using Grido.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для FormUserPage.xaml
    /// </summary>
    public partial class FormUserPage : Page
    {
        private MainWindow mv;
        private User user;
        private bool IsAdd;

        public User User { get => user; set { user = value; Signal(); } }
        public FormUserPage(MainWindow mv)
        {
            BaseStart(mv);
            this.User = new();
            IsAdd = true;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Signal([CallerMemberName] string prop = null)
           => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public FormUserPage(MainWindow mv, User user)
        {
            BaseStart(mv);
            this.User = user;
            IsAdd = false;
        }

        private void BaseStart(MainWindow mv)
        {
            InitializeComponent();
            DataContext = this;
            this.mv = mv;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
            => mv.CurrentPage = new MainPage(mv, mv.LoggedUser);

        private void Save_Click(object sender, RoutedEventArgs e)
        { 
        
        }
    }
}
