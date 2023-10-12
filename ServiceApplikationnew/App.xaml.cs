
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceApplikationnew.MVVM.Core;
using ServiceApplikationnew.MVVM.ViewModels;
using ServiceApplikationnew.Services;
using System.Windows;
using System;

namespace ServiceApplikationnew;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private static IHost? host { get; set; }

    public App()
    {
        host = Host.CreateDefaultBuilder()
            .ConfigureServices((config, services )=>
            {
                services.AddSingleton<NavigationStore>();
                services.AddSingleton<DateTimeService>();
                services.AddSingleton<MainWindow>();
                services.AddSingleton<HomeViewModel>();
                services.AddSingleton<SettingsViewModel>(); 
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs args)
    {
        var mainWindow = host!.Services.GetRequiredService<MainWindow>();
        var navigationstor = host!.Services.GetRequiredService<NavigationStore>();
        var datetimeservice = host!.Services.GetRequiredService<DateTimeService>();
        navigationstor.CurrentViewModel = new HomeViewModel(navigationstor, datetimeservice!);

        await host!.StartAsync();
        mainWindow.Show();
        base.OnStartup(args);
    }
}
