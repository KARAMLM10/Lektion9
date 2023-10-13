
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceApplikationnew.MVVM.Core;
using ServiceApplikationnew.MVVM.ViewModels;
using ServiceApplikationnew.Services;
using System.Windows;
using System;
using IotShared.Models;
using IotShared.Services;
using ServiceApplikationnew.MVVM.Views;

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
                services.AddSingleton<DevicesListService>();
                services.AddSingleton(new IOTHubManager(new IotHubManagerOptions
                {
                    iothubConnectionString = "HostName=Systemutvecklingkaram.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=b1VBnvT3K4uet/1VkdBsuelGyxh6eodhEAIoTJKGAtA=",
                    eventHubEndpoint = "Endpoint=sb://ihsuprodamres076dednamespace.servicebus.windows.net/;SharedAccessKeyName=iothubowner;SharedAccessKey=b1VBnvT3K4uet/1VkdBsuelGyxh6eodhEAIoTJKGAtA=;EntityPath=iothub-ehub-systemutve-25230371-5c032015c0",
                    eventHubName = "iothub-ehub-systemutve-25230371-5c032015c0",
                    consumerGroup = "ServiceApplikationnew"
                }));


                services.AddSingleton<MainWindow>();

                services.AddSingleton<HomeWindowViewModel>();
                services.AddSingleton<HomeView>();

                services.AddSingleton<SettingsViewModel>();
                services.AddSingleton<SettingsView>();


            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs args)
    {
        var mainWindow = host!.Services.GetRequiredService<MainWindow>();
        var navigationstor = host!.Services.GetRequiredService<NavigationStore>();
        navigationstor.CurrentViewModel = host!.Services.GetRequiredService<HomeWindowViewModel>();


        await host!.StartAsync();
        mainWindow.Show();
        base.OnStartup(args);
    }
}
