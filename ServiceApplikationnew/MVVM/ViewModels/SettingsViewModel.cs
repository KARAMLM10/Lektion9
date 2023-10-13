
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using ServiceApplikationnew.MVVM.Core;
using ServiceApplikationnew.Services;
using System;
using System.Windows.Input;

namespace ServiceApplikationnew.MVVM.ViewModels;

public partial class SettingsViewModel : ObservableObject
{
    private readonly NavigationStore _navigationStore;
    private readonly DateTimeService _dateTimeService;
    private readonly IServiceProvider _serviceProvider;

    public SettingsViewModel(NavigationStore navigationStore, DateTimeService dateTimeService, IServiceProvider serviceProvider)
    {
        _navigationStore = navigationStore;
        _dateTimeService = dateTimeService;
        _serviceProvider = serviceProvider;
    }


    [ObservableProperty]
    string? title = "Settings";



    // Navigation 
    [RelayCommand]
    public void NavigateToHome()
    {

        _navigationStore.CurrentViewModel = _serviceProvider.GetRequiredService<HomeWindowViewModel>();
    }

    [RelayCommand]
    public void CloseApplikation()
    {
        ApplikationService.CloseApplikation();
    }

}
