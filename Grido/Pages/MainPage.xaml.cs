﻿using Grido.Models;
using Grido.OtherLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
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
using static System.Net.WebRequestMethods;

namespace Grido.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page, INotifyPropertyChanged
    {
        private Visibility forAdminsVis;
        private Visibility forUsersVis;
        private MainWindow mv;
        private Map map;
        private User selectedUser;
        private List<Map> maps;
        private List<User> users;
        public List<Map> Maps { get => maps; set { maps = value; Signal(); } }
        public List<User> Users { get => users; set { users = value; Signal(); } }
        public Map SelectedMap { get => map; set { map = value; Signal(); } }
        public User SelectedUser { get => selectedUser; set { selectedUser = value; Signal(); } }
        public Visibility ForUsersVis { get => forUsersVis; set { forUsersVis = value; Signal(); } }
        public Visibility ForAdminsVis { get => forAdminsVis; set { forAdminsVis = value; Signal(); } }
        ApiController api = ApiController.Inst;

        public MainPage(MainWindow mv, User user)
        {
            mv.LoggedUser = user;
            RenderKabinet();
            BaseStart(mv);
        }

        public MainPage(MainWindow mv)
        {
            BaseStart(mv);
        }

        private async void BaseStart(MainWindow mv)
        {
            this.mv = mv;
            InitializeComponent();
            DataContext = this;
            Maps = await api.GetAllMaps();
            Users = await api.GetAllUsers();
            SelectedMap = new();
            mv.LoggedUser = new();
            ForAdminsVis = await api.GetVisibility(mv.LoggedUser, "admin");
            ForUsersVis = await api.GetVisibility(mv.LoggedUser, "signed");
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Signal([CallerMemberName]string prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        private void RenderKabinet()
        {
           // throw new NotImplementedException();
        }

        private void Sure_Click(object sender, RoutedEventArgs e)
            => mv.CurrentPage = new WelcomePage(mv);

        private void NotSure_Click(object sender, RoutedEventArgs e)
            => tabber.SelectedItem = mainTab;

        private void LikeRazrab_Click(object sender, RoutedEventArgs e)
            => MessageBox.Show("Вы поддержали разработчика!", "Спасибо!");
        
        private void Help_Click(object sender, RoutedEventArgs e)
            => MainTextblock.Text = "Помощь в пользовании приложения:\nСлева расположены вкладки, чем больше у вас прав, тем больше доступно возможностей.\nДля повышения доступа - авторизуйтесь. Для более подробной информации рекомендуется прочитать документацию на GitHub. \n \n Почта для makin_cat@gmail.com";

        private void GitHub_Click(object sender, RoutedEventArgs e)
            => MainTextblock.Text = "https://github.com/Denoos/MapModelerSystem";

        private void InfoRazrab_Click(object sender, RoutedEventArgs e)
            => MainTextblock.Text = "Разработчик проекта: Denoos";

        private async void Connect_Click(object sender, RoutedEventArgs e)
            => await api.ConnectToGame(SelectedMap, mv.LoggedUser);

        private void Add_Map_Click(object sender, RoutedEventArgs e)
            => mv.CurrentPage = new FormMapPage(mv, true);

        private void Edit_Map_Click(object sender, RoutedEventArgs e)
            => mv.CurrentPage = new FormMapPage(mv, SelectedMap, true);

        private async void Del_Map_Click(object sender, RoutedEventArgs e)
            => await api.DeleteMap(SelectedMap);

        private void See_Map_Click(object sender, RoutedEventArgs e)
            => mv.CurrentPage = new FormMapPage(mv, SelectedMap, false);

        private void Add_User_Click(object sender, RoutedEventArgs e)
            => mv.CurrentPage = new FormUserPage(mv, false);

        private void Edit_User_Click(object sender, RoutedEventArgs e)
            => mv.CurrentPage = new FormUserPage(mv, SelectedUser, true);

        private async void Del_User_Click(object sender, RoutedEventArgs e)
            => await api.DeleteUser(SelectedUser);

        private void See_User_Click(object sender, RoutedEventArgs e)
            => mv.CurrentPage = new FormUserPage(mv, SelectedUser, false);
    }
}
