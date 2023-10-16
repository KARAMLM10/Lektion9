
using IotShared.Models;
using Microsoft.Azure.Devices.Shared;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System;
using IotShared.Services;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using ServiceApplikationnew.MVVM.Models;
using System.Timers;
using Microsoft.Azure.Devices;

namespace ServiceApplikationnew.Services;
public class DevicesListService
{
    private readonly IOTHubManager _iotHub;
    public event Action? DeviceListUpdated;
    private readonly Timer _timer;
    public ObservableCollection<DeviceItem> DeviceItemList { get; private set; }

    public DevicesListService(IOTHubManager iotHub)
    {
        _iotHub = iotHub;
        DeviceItemList = new ObservableCollection<DeviceItem>();
        Task.Run(InitializeAsync);
        _timer = new Timer(3000);
        _timer.Elapsed += async (s, e) => await InitializeAsync();
        _timer.Start();

    }

    public async Task InitializeAsync()
    {
        try
        {
            while (true)
            {
                var devices = new List<Twin>();
                var twins = await _iotHub.GetDevicesAsTwinsAsync();
                if (twins != null!)
                {
                    foreach (var twin in twins)
                    {
                        devices.Add(twin);
                    }
                    DeviceItemList.Clear();
                    foreach (var device in devices)
                    {
                        var isActiveItem = device.Properties.Desired.Contains("isActive") ? device.Properties.Desired["isActive"].ToString() : "false";
                        bool.TryParse(isActiveItem, out bool isActive);
                        var deviceType = device.Properties.Desired.Contains("deviceType") ? device.Properties.Desired["deviceType"] : "unknown";
                        var placement = device.Properties.Desired.Contains("placement") ? device.Properties.Desired["placement"] : "unknown";
                        DeviceItemList.Add(
                            new DeviceItem
                            {
                                DeviceId = device.DeviceId,
                                IsActive = isActive,
                                Devicetype = deviceType,
                                Placement  = placement
                            });
                    }

                    DeviceListUpdated?.Invoke();
                }

                // Update the device twin list
                //UpdateDeviceTwinList(twins);

                await Task.Delay(10000); // Adjust the delay as needed
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions as needed
            Debug.WriteLine(ex.Message);
        }
    }

    //private void UpdateDeviceTwinList(IEnumerable<Twin> twins)
    //{
    //    DeviceItemList.Clear();

    //    foreach (var twin in twins)
    //    {
    //        DeviceItemList.Add(twin);
    //    }
    //}

}


