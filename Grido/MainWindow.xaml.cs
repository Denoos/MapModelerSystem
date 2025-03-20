using Grido.Pages;
using System.ComponentModel;
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
    private void Signal(string prop = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}