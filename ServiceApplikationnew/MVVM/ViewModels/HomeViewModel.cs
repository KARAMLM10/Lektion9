
using ServiceApplikationnew.MVVM.Core;
using ServiceApplikationnew.MVVM.Models;
using ServiceApplikationnew.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ServiceApplikationnew.MVVM.ViewModels;

public class HomeViewModel : ObservalbeObject
{
    private readonly NavigationStore _navigationstore;
    private readonly DateTimeService _dateTimeService;

    public HomeViewModel(NavigationStore navigationStore, DateTimeService dateTimeService)
    {
        _navigationstore = navigationStore;
        _dateTimeService = dateTimeService;
        GetDateTimeAsync();
    }

    
    // Navigation 
    public ICommand NavigatToSettingsCommand =>
        new RelayCommand(() => _navigationstore.CurrentViewModel = new SettingsViewModel(_navigationstore, _dateTimeService ));


    private string? _currentTime;
    public string? CurrentTime { get => _currentTime; set => SetValue(ref _currentTime, value); }

    private string? _currentDate;

    public string? CurrentDate { get => _currentDate; set => SetValue(ref _currentDate, value); }


    private void GetDateTimeAsync()
    {
        _dateTimeService.DateTimeUpdated += () =>
        {
            CurrentTime = _dateTimeService.CurrentTime;
            CurrentDate = _dateTimeService.CurrentDate;
        };
    }
}
