using Grido.Models;
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
using static System.Net.Mime.MediaTypeNames;
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
        private Visibility enterVis;
        private MainWindow mv;
        private Map map;
        private User selectedUser;
        private List<Map> maps;
        private List<User> users;
        private User personalInfo;
        private string photoPath;
        public List<Map> Maps { get => maps; set { maps = value; Signal(); } }
        public List<User> Users { get => users; set { users = value; Signal(); } }
        public Map SelectedMap { get => map; set { map = value; Signal(); } }
        public User SelectedUser { get => selectedUser; set { selectedUser = value; Signal(); } }
        public User PersonalInfo { get => personalInfo; set { personalInfo = value; Signal(); } }
        public string PhotoPath { get => photoPath; set { photoPath = value; Signal(); } }
        public Visibility ForUsersVis { get => forUsersVis; set { forUsersVis = value; Signal(); } }
        public Visibility EnterVis { get => enterVis; set { enterVis = value; Signal(); } }
        public Visibility ForAdminsVis { get => forAdminsVis; set { forAdminsVis = value; Signal(); } }

        private readonly ApiController api = ApiController.Inst;
        private readonly PhotoController _photo = new();

        public MainPage(MainWindow mv, User user)
        {
            mv.LoggedUser = user;
            BaseStart(mv);
            RenderKabinet();
        }

        public MainPage(MainWindow mv)
        {
            mv.LoggedUser = new();
            BaseStart(mv);
        }

        private async void BaseStart(MainWindow mv)
        {
            this.mv = mv;
            InitializeComponent();
            DataContext = this;
            Maps = await api.GetAllMaps();
            Users = await api.GetAllUsers();
            PersonalInfo = mv.LoggedUser;
            SelectedMap = new();
            ForAdminsVis = await api.GetVisibility(mv.LoggedUser, "admin");
            ForUsersVis = await api.GetVisibility(mv.LoggedUser, "signed");
            if (ForUsersVis == Visibility.Collapsed)
                EnterVis = Visibility.Visible;
            else EnterVis = Visibility.Collapsed;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Signal([CallerMemberName]string prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        private async void RenderKabinet()
        {
            PhotoPath = _photo.GetCurrentPath();
        }

        private void Sure_Click(object sender, RoutedEventArgs e)
            => mv.CurrentPage = new WelcomePage(mv);

        private void NotSure_Click(object sender, RoutedEventArgs e)
            => tabber.SelectedItem = mainTab;

        private void LikeRazrab_Click(object sender, RoutedEventArgs e)
            => MessageBox.Show("Вы поддержали разработчика!", "Спасибо!");
        
        private void Help_Click(object sender, RoutedEventArgs e)
            => MainTextblock.Text = "Помощь в пользовании приложения:\nСлева расположены вкладки, чем больше у вас прав, тем больше доступно возможностей.\nДля повышения доступа - авторизуйтесь. Для более подробной информации рекомендуется прочитать документацию на GitHub. \n \n Почта для вопросов по проекту: maken_cat@gmail.com";

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
        
        private void Enter_Click(object sender, RoutedEventArgs e)
            => Sure_Click(sender, e);

        private void Exit_Click(object sender, RoutedEventArgs e)
            => Sure_Click(sender, e);

        private void SelectPhoto_Click(object sender, RoutedEventArgs e)
            => _photo.SelectPhoto();

        private void ChangePhotoPath_Click(object sender, RoutedEventArgs e)
            => _photo.ChangePhotoPath();

        private void ChangeUserInfo_Click(object sender, RoutedEventArgs e)
            => mv.CurrentPage = new FormUserPage(mv, mv.LoggedUser, true);
    }
}
