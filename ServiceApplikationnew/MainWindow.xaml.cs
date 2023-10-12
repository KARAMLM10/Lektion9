
using ServiceApplikationnew.MVVM.Core;
using ServiceApplikationnew.MVVM.Models;
using ServiceApplikationnew.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

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
