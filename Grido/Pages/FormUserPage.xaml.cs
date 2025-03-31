using Grido.Models;
using Grido.OtherLogic;
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
    /// 
    public partial class FormUserPage : Page
    {
        private MainWindow mv;
        private User user;
        private bool IsAdd;
        private List<Role> roles;
        private Role selectedRole;
                        
        private List<Role> Roles { get => roles; set { roles = value; Signal(); } }
        private Role SelectedRole { get => selectedRole; set { selectedRole = value; Signal(); } }

        private ApiController api = ApiController.Inst;
        private bool isen;
        public bool IsEnabled { get => isen; set { isen = value; Signal(); } }
        public User User { get => user; set { user = value; Signal(); } }
        public FormUserPage(MainWindow mv, bool isen)
        {
            BaseStart(mv, isen);
            this.User = new();
            IsAdd = true;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Signal([CallerMemberName] string prop = null)
           => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public FormUserPage(MainWindow mv, User user, bool isen)
        {
            BaseStart(mv, isen);
            this.User = user;
            IsAdd = false;
        }

        private async void BaseStart(MainWindow mv, bool isen)
        {
            InitializeComponent();
            DataContext = this;
            this.mv = mv;
            Roles = await api.GetAllRoles();
            this.IsEnabled = isen;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
            => mv.CurrentPage = new MainPage(mv, mv.LoggedUser);

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            await api.AddUser();
            Cancel_Click(sender, e);
        }
        //                      _____
        //                     |  |  |
        //                     |__|__|
        //                     |     |
        //                     |     |
        //                     |     |
        //                     |     | вот так правилно еблан
        //                _____|     |_____
        //               |                 |
        //               |                 |
        //               |_________________|
    }
}
