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
        private User user;
        private User User { get => user; set { user = value; Signal(); } }
        public Visibility ForUsersVis { get => forUsersVis; set { forUsersVis = value; Signal(); } }
        public Visibility ForAdminsVis { get => forAdminsVis; set { forAdminsVis = value; Signal(); } }
        ApiController api = ApiController.Inst;

        public MainPage(MainWindow mv, User user)
        {
            this.mv = mv;
            this.User = user;
            RenderKabinet();
            InitializeComponent();
            DataContext = this;
        }

        public MainPage(MainWindow mv)
        {
            this.mv = mv;
            InitializeComponent();
            DataContext = this;
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
        {
            tabber.SelectedItem = mainTab;
        }

        private void LikeRazrab_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GitHub_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InfoRazrab_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
