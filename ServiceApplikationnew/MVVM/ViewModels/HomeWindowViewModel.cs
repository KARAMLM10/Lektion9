using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IotShared.Services;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Shared;
using Microsoft.Extensions.DependencyInjection;
using ServiceApplikationnew.MVVM.Core;
using ServiceApplikationnew.MVVM.Models;
using ServiceApplikationnew.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ServiceApplikationnew.MVVM.ViewModels
{
    public partial class HomeWindowViewModel : ObservableObject
    {
        private readonly NavigationStore _navigationstore;
        private readonly DateTimeService _dateTimeService;
        private readonly IOTHubManager _iotHub;
        private readonly DevicesListService _devicesListService;
        private readonly IServiceProvider _serviceProvider;

        public HomeWindowViewModel(NavigationStore navigationStore, DateTimeService dateTimeService, IOTHubManager iotHub, DevicesListService devicesListService, IServiceProvider serviceProvider)
        {
            _navigationstore = navigationStore;
            _dateTimeService = dateTimeService;
            _iotHub = iotHub;
            _devicesListService = devicesListService;
            _serviceProvider = serviceProvider;

            // Anslut HomeView till enhetslistan i DevicesListService
            //DeviceTwinList = _devicesListService.DeviceItemList;
            GetDateTime();
            UpdateDeviceList();
            _devicesListService.DeviceListUpdated += UpdateDeviceList;
            //Task.WhenAll(_devicesListService.InitializeAsync());

        }

        [ObservableProperty]
        ObservableCollection<DeviceItem> deviceItemList = new();

        [ObservableProperty]
        string? currentDate;

        [ObservableProperty]
        string? currentTime;


        [RelayCommand]
        public void NavigateToSettings()
        {
            _navigationstore.CurrentViewModel = _serviceProvider.GetRequiredService<SettingsViewModel>();
        }



        private void GetDateTime()
        {
            _dateTimeService.DateTimeUpdated += () =>
            {
                CurrentTime = _dateTimeService.CurrentTime;
                CurrentDate = _dateTimeService.CurrentDate;
            };
        }
        public void UpdateDeviceList()
        {
            Application.Current.Dispatcher.BeginInvoke(() =>
            {
                DeviceItemList = new ObservableCollection<DeviceItem>(_devicesListService.DeviceItemList.Select(device => device).ToList());
            });
        }
        //private async Task GetDevicesTwinAsync()
        //{
        //    try
        //    {
        //        while (true)
        //        {
        //            var twins = await _iotHub.GetDevicesAsTwinsAsync();
        //            DeviceTwinList.Clear();

        //            foreach (var twin in twins)
        //                DeviceTwinList.Add(twin);

        //            await Task.Delay(1000);
        //        }
        //    }
        //    catch (Exception ex) { Debug.WriteLine(ex.Message); }


        //}
    }
}
