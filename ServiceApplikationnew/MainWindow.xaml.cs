
using ServiceApplikationnew.MVVM.Core;
using ServiceApplikationnew.Services;
using System.Windows;

namespace ServiceApplikationnew;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(NavigationStore navigationStore)
    {
        InitializeComponent();
       
        DataContext = navigationStore;
    }

}
