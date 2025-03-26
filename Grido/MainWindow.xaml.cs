using Grido.Models;
using Grido.Pages;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Grido;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, INotifyPropertyChanged
{
    private User loggedUser;
    public User LoggedUser { get => loggedUser; set { loggedUser = value; Signal(); } }
    private Page currentPage;
    public event PropertyChangedEventHandler? PropertyChanged;

    public Page CurrentPage
    {
        get => currentPage;
        set
        {
            currentPage = value;
            Signal();
        }
    }

    public MainWindow()
    {
        InitializeComponent();
        CurrentPage = new WelcomePage(this);
        DataContext = this;
    }
    private void Signal([CallerMemberName] string prop = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}



//https://www.youtube.com/watch?v=1NgKeajCd_Y&ab_channel=%D0%9A%D0%BB%D1%83%D0%B1%D0%92%D0%B8%D0%BD%D0%BA%D1%81%D0%A0%D1%83%D1%81%D1%81%D0%BA%D0%B8%D0%B9
//https://www.youtube.com/watch?v=1NgKeajCd_Y&ab_channel=%D0%9A%D0%BB%D1%83%D0%B1%D0%92%D0%B8%D0%BD%D0%BA%D1%81%D0%A0%D1%83%D1%81%D1%81%D0%BA%D0%B8%D0%B9
//https://www.youtube.com/watch?v=1NgKeajCd_Y&ab_channel=%D0%9A%D0%BB%D1%83%D0%B1%D0%92%D0%B8%D0%BD%D0%BA%D1%81%D0%A0%D1%83%D1%81%D1%81%D0%BA%D0%B8%D0%B9
//https://www.youtube.com/watch?v=1NgKeajCd_Y&ab_channel=%D0%9A%D0%BB%D1%83%D0%B1%D0%92%D0%B8%D0%BD%D0%BA%D1%81%D0%A0%D1%83%D1%81%D1%81%D0%BA%D0%B8%D0%B9
//https://www.youtube.com/watch?v=1NgKeajCd_Y&ab_channel=%D0%9A%D0%BB%D1%83%D0%B1%D0%92%D0%B8%D0%BD%D0%BA%D1%81%D0%A0%D1%83%D1%81%D1%81%D0%BA%D0%B8%D0%B9
//https://www.youtube.com/watch?v=1NgKeajCd_Y&ab_channel=%D0%9A%D0%BB%D1%83%D0%B1%D0%92%D0%B8%D0%BD%D0%BA%D1%81%D0%A0%D1%83%D1%81%D1%81%D0%BA%D0%B8%D0%B9
//https://www.youtube.com/watch?v=1NgKeajCd_Y&ab_channel=%D0%9A%D0%BB%D1%83%D0%B1%D0%92%D0%B8%D0%BD%D0%BA%D1%81%D0%A0%D1%83%D1%81%D1%81%D0%BA%D0%B8%D0%B9
//https://www.youtube.com/watch?v=1NgKeajCd_Y&ab_channel=%D0%9A%D0%BB%D1%83%D0%B1%D0%92%D0%B8%D0%BD%D0%BA%D1%81%D0%A0%D1%83%D1%81%D1%81%D0%BA%D0%B8%D0%B9
//https://www.youtube.com/watch?v=1NgKeajCd_Y&ab_channel=%D0%9A%D0%BB%D1%83%D0%B1%D0%92%D0%B8%D0%BD%D0%BA%D1%81%D0%A0%D1%83%D1%81%D1%81%D0%BA%D0%B8%D0%B9
//https://www.youtube.com/watch?v=1NgKeajCd_Y&ab_channel=%D0%9A%D0%BB%D1%83%D0%B1%D0%92%D0%B8%D0%BD%D0%BA%D1%81%D0%A0%D1%83%D1%81%D1%81%D0%BA%D0%B8%D0%B9


