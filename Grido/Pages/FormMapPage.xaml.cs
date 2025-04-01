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
    /// Логика взаимодействия для FormMapPage.xaml
    /// </summary>
    public partial class FormMapPage : Page
    {
        private MainWindow mv;
        private Map map;
        private List<string> roles;
        private bool IsAdd;
        private bool isen;

        public Map Map { get => map; set { map = value; Signal(); } }
        public bool IsEnabled { get => isen; set { isen = value; Signal(); } }

        private ApiController api = ApiController.Inst;

        public FormMapPage(MainWindow mv, bool isen)
        {
            BaseStart(mv, isen);
            this.Map = new();
            IsAdd = true;
        }
        public FormMapPage(MainWindow mv, Map map, bool isen)
        {
            BaseStart(mv, isen);
            this.Map = map;
            IsAdd = false;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void Signal([CallerMemberName] string prop = null)
           => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        private async void BaseStart(MainWindow mv, bool isen)
        {
            InitializeComponent();
            DataContext = this;
            this.mv = mv;
            this.IsEnabled = isen;
            if (await api.GetVisibility(mv.LoggedUser, "admin") == Visibility.Visible)
                ForAdminsVis = Visibility.Collapsed;
            else ForAdminsVis = Visibility.Visible;
            ComboVis = await api.GetVisibility(mv.LoggedUser, "admin");
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
            => mv.CurrentPage = new MainPage(mv, mv.LoggedUser);

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckForValidPsswords())
            {
                User.Password = NewPassword;
                User.IdRoleNavigation = await api.GetRoleOne(SelectedRole);
                User.IdRole = User.IdRoleNavigation.Id;
                if (IsAdd)
                    await api.AddUser(User);
                else await api.EditUser(User);
            }
            Cancel_Click(sender, e);
        }

        private bool CheckForValidPsswords()
        {
            if (ForAdminsVis is Visibility.Collapsed ||
                    (
                    User.Password == mv.LoggedUser.Password &&
                    !string.IsNullOrEmpty(NewPassword) &&
                    !string.IsNullOrEmpty(ConfirmPassword) &&
                    NewPassword == ConfirmPassword
                    ))
                return true;
            MessageBox.Show("Один из паролей не совпадает!", "Уведомление!");
            return false;
        }
    }
}
