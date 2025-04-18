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
        private bool isel;
        private string selObj;
        private Button[,] mapBut;
        public Map Map { get => map; set { map = value; Signal(); } }
        public bool IsEnabled { get => isen; set { isen = value; Signal(); } }
        public bool IsSelectedTab { get => isel; set { isel = value; Signal(); if (isel) RenderMapField(); } }
        public Button[,] MapButtonsVarity { get => mapBut; set { mapBut = value; Signal(); } }

        public string SelectedObject { get => selObj; set { selObj = value; Signal(); } }

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
            this.SelectedObject = "0";
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
            => mv.CurrentPage = new MainPage(mv, mv.LoggedUser);

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckForCorrect())
            {
                if (IsAdd)
                    await api.AddMap(Map);
                else await api.EditMap(Map);
                Cancel_Click(sender, e);
            }
        }

        private void ChangeObject_Click(object sender, RoutedEventArgs e)
        {
            var sd = (RadioButton)sender;

            switch (sd.Content)
            {
                case "floor":
                    SelectedObject = "0";
                    break;
                case "wall":
                    SelectedObject = "1";
                    break;
                case "player":
                    SelectedObject = "2";
                    break;
            }
        }
        private void ButtonAtCanvas_Click(object sender, RoutedEventArgs e)
        {
            var snd = (Button)sender;

            switch (SelectedObject)
            {
                case "0":
                    snd.Background = Brushes.Green;
                    break;
                case "1":
                    snd.Background = Brushes.Black;
                    break;
                case "2":
                    snd.Background = Brushes.Red;
                    break;
                default:
                    MessageBox.Show("Выберите цвет на панели в правой чати окна!", "Ошибка!");
                    break;
            }
        }

        private void RenderMapField()
        {
            if (Map.Height <= 0 || Map.Width <= 0)
                return;

            if (Map.Height > 16)
                map.Height = 16;
            if (Map.Width > 28)
                map.Width = 28;

            MapButtonsVarity = new Button[Map.Width, Map.Height];

            ButtonsField.Children.Clear();

            for (int i = 0; i < Map.Width; i++)
                for (int j = 0; j < Map.Height; j++)
                {
                    MapButtonsVarity[i, j] = new Button() { Height = 20, Width = 20, Background = Brushes.Green };
                    MapButtonsVarity[i, j].Click += new RoutedEventHandler(ButtonAtCanvas_Click);
                    Canvas.SetLeft(MapButtonsVarity[i, j], 1 + (MapButtonsVarity[i, j].Width + 1) * i);
                    Canvas.SetTop(MapButtonsVarity[i, j], 1 + (MapButtonsVarity[i, j].Height + 1) * j);
                    ButtonsField.Children.Add(MapButtonsVarity[i, j]);
                }
        }

        private bool CheckForCorrect()
        {
            var plCount = 0;

            foreach (var p in MapButtonsVarity)
                if (p.Background ==  Brushes.Red)
                    plCount++;

            if (plCount < 3 && plCount > 0)
                return true;
            return false;
        }
    }
}