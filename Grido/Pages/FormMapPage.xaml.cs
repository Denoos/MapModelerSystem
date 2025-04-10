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
        private int[,] mapInt;
        private Button[,] mapBut;
        public Map Map { get => map; set { map = value; Signal(); } }
        public bool IsEnabled { get => isen; set { isen = value; Signal(); } }
        public bool IsSelectedTab { get => isel; set { isel = value; Signal(); if (isel) RenderMapField(); } }
        public int[,] MapIntVarity { get => mapInt; set { mapInt = value; Signal(); } }
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
            if (IsAdd)
                await api.AddMap(Map);
            else await api.EditMap(Map);
            Cancel_Click(sender, e);
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
        private void RenderMapField()
        {
            MapIntVarity = new int[Map.Width, Map.Height];
            MapButtonsVarity = new Button[Map.Width, Map.Height];

            ButtonsField.Children.Clear();

            for (int i = 0; i < Map.Width; i++)
                for (int j = 0; j < Map.Height; j++)
                {
                    MapIntVarity[i, j] = 0;
                    MapButtonsVarity[i, j] = new Button() { Height = 20, Width = 20 };
                    Canvas.SetLeft(MapButtonsVarity[i, j], 1 + (MapButtonsVarity[i, j].Width + 1) * i);
                    Canvas.SetTop(MapButtonsVarity[i, j], 1 + (MapButtonsVarity[i, j].Height + 1) * j);
                    ButtonsField.Children.Add(MapButtonsVarity[i, j]);
                }
        }
    }
}
//ButtonsField - Canvas