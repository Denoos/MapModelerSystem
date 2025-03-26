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
        private bool IsAdd;
        private ApiController api = ApiController.Inst;
        private Map map;
        private bool isen;
        public bool IsEnabled { get => isen; set { isen = value; Signal(); } }
        private Map Map { get => map; set { map = value; Signal(); } }

        public FormMapPage(MainWindow mv, bool isen)
        {
            BaseStart(mv, isen);
            IsAdd = true;
            this.Map = new();
        }

        public FormMapPage(MainWindow mv, Map map, bool isen)
        {
            BaseStart(mv, isen);
            IsAdd = false;
            this.Map = map;
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
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
            => mv.CurrentPage = new MainPage(mv, mv.LoggedUser);

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            await api.AddUser();
            Cancel_Click(sender, e);
        }
    }
}
