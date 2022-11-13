using System;
using SmarthThingsSDK.Net.Interfaces;

namespace SmarthThingsSDK.Net
{
    public interface ISmartThingsClient
    {
        IApp Apps { get; }
        ICapability Capabilities { get; }
        IChannel Channels { get; }
        //IEndpoint Endpoints { get; }
        IDevice Devices { get; }
        IDevicePreference DevicePreferences { get; }
        IDeviceProfile DeviceProfiles { get; }
        IDriver Drivers { get; }
        IHistory History { get; }
        IHubDevice HubDevices { get; }
        IInstalledApp InstalledApps { get; }
        ILocation Locations { get; }
        IMode Modes { get; }
        INotification Notifications { get; }
        IOrganization Organizations { get; }
        IPresentation Presentations { get; }
        IRoom Rooms { get; }
        IRule Rules { get; }
        IScene Scenes { get; }
        ISchedule Schedules { get; }
        //ISchema Schemas { get;  }
        ISubscription Subscriptions { get; }
        IVirtualDevice VirtualDevices { get; }

    }
}

