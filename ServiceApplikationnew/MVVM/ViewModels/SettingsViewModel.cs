
using ServiceApplikationnew.MVVM.Core;
using ServiceApplikationnew.Services;
using System.Windows.Input;

namespace ServiceApplikationnew.MVVM.ViewModels;

public class SettingsViewModel : ObservalbeObject
{
    private readonly NavigationStore _navigationStore;
    private readonly DateTimeService _dateTimeService;

    public SettingsViewModel(NavigationStore navigationStore, DateTimeService dateTimeService)
    {
        _navigationStore = navigationStore;
        _dateTimeService = dateTimeService;
    }

    // Navigation 
    public ICommand NavigatToHomeCommand =>
        new RelayCommand(() => _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore, _dateTimeService));
    public ICommand CloseApplikationCommand =>
        new RelayCommand(() => ApplikationService.CloseApplikation());


    private string? _title = "Settings";
    public string? Title { get => _title; set => SetValue(ref _title, value); }



}
