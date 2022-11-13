using System;
using SmarthThingsSDK.Net.Interfaces;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using SmarthThingsSDK.Net.Models;
using static SmarthThingsSDK.Net.Interfaces.Device;

namespace SmarthThingsSDK.Net.Interfaces
{
    public class Device
    {





        //const HEADER_OVERRIDES = { Accept: 'application/vnd.smartthings+json;v=20170916' }

        public partial class CapabilityReference
        {
            public string id { get; set; }
            public int? version { get; set; }
            public CapabilityStatus? status { get; set; }
        }

        public partial class DeviceProfileReference
        {
            public string? id { get; set; }
        }

        /**
         * Included for backwards compatibility (renamed to match API docs).
         * For new code, use DeviceProfileReference.
         *
         * @deprecated
         */
        // eslint-disable-next-line @typescript-eslint/no-empty-interface
        public partial class ProfileIdentifier : DeviceProfileReference { }

        //export type CategoryType = 'manufacturer' | 'user'

        public partial class DeviceCategory
        {
            public string? name { get; set; }
            public CategoryType? categoryType { get; set; }
        }
        public enum CategoryType { manufacturer = 0, user = 1 }

        public partial class Restrictions
        {
            /**
             * integer
             */
            public int tier { get; set; }

            /**
             * integer
             */
            public int historyRetentionTTLDays { get; set; }

            /**
             * default: false
             */
            public bool visibleWhenRestricted { get; set; }
        }

        public partial class Component
        {
            public string id { get; set; } // <^[-_!.~'()*0-9a-zA-Z]{1,36}$>
            public CapabilityReference[] capabilities { get; set; }
            public DeviceCategory[] categories { get; set; }
            public string? label { get; set; }
            public Restrictions? restrictions { get; set; }
            public string? icon { get; set; }
        }

        public partial class AppDeviceDetails
        {
            /**
             * The ID of the installed app that integrates this device.
             *
             * <^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$>
             */
            public string? installedAppId { get; set; }
            /**
             * A field to store an ID from a system external to SmartThings.
             *
             * <= 64 characters
             */
            public string? externalId { get; set; }

            public DeviceProfileReference? profile { get; set; }
        }

        // eslint-disable-next-line @typescript-eslint/no-empty-interface
        public partial class BleDeviceDetails
        {
            // The API defines this object without properties.
        }

        public partial class BleD2DDeviceDetails
        {
            public string? encryptionKey { get; set; }
            public string? cipher { get; set; }
            public string? advertisingId { get; set; }
            public string? identifier { get; set; }
            public string? configurationVersion { get; set; }
            public string? configurationUrl { get; set; }
            public object? metadata { get; set; }
        }

        public enum DeviceNetworkSecurityLevel
        {
            UNKNOWN = 0,
            ZWAVE_LEGACY_NON_SECURE = 1,
            ZWAVE_S0_LEGACY = 2,
            ZWAVE_S0_FALLBACK = 3,
            ZWAVE_S2_UNAUTHENTICATED = 4,
            ZWAVE_S2_AUTHENTICATED = 5,
            ZWAVE_S2_ACCESS_CONTROL = 6,
            ZWAVE_S2_FAILED = 7,
            ZWAVE_S0_FAILED = 8,
            ZWAVE_S2_DOWNGRADE = 9,
            ZWAVE_S0_DOWNGRADE = 10
        }

        public partial class DthDeviceDetails
        {
            public string? deviceTypeId { get; set; } // <^(?:([0-9a-fA-F]{32})|([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}))$>
            public string deviceTypeName { get; set; }
            public bool completedSetup { get; set; }
            public string? deviceNetworkType { get; set; }
            public bool executingLocally { get; set; }
            public string? hubId { get; set; }
            public string? installedGroovyAppId { get; set; } // <^(?:([0-9a-fA-F]{32})|([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}))$>
            public DeviceNetworkSecurityLevel? networkSecurityLevel { get; set; }
        }

        //export type ProvisioningState = 'PROVISIONED' | 'TYPED' | 'DRIVER_SWITCH' | 'NONFUNCTIONAL'
        public partial class LanDeviceDetails : DeviceDetails
        {
            //public string? networkId { get; set; }
            public string? driverId { get; set; }
            //public bool? executingLocally { get; set; }
            //public string? hubId { get; set; }
            //public string? provisioningState { get; set; }
        }

        public partial class ZigbeeDeviceDetails : DeviceDetails
        {
            [JsonProperty("eui")]
            public string? Eui { get; set; }
            //public string? networkId { get; set; }
            //public string? driverId { get; set; }
            //public bool? executingLocally { get; set; }
            //public string? hubId { get; set; }
            ////export type ProvisioningState = 'PROVISIONED' | 'TYPED' | 'DRIVER_SWITCH' | 'NONFUNCTIONAL'
            //public string? provisioningState { get; set; }
        }

        public partial class ZwaveDeviceDetails : DeviceDetails
        {
            public DeviceNetworkSecurityLevel? networkSecurityLevel { get; set; }

        }
        public partial class DeviceDetails
        {
            /**
             * matches: string <^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$> (DriverId)
             */
            [JsonProperty("driverId")]
            public string? DriverId { get; set; }

            /**
             * The hub that the device is connected to
             */
            [JsonProperty("hubId")]
            public string? HubId { get; set; }

            /**
             * Provisioning type for a widget device
             * export type ProvisioningState = 'PROVISIONED' | 'TYPED' | 'DRIVER_SWITCH' | 'NONFUNCTIONAL'
             */
            [JsonProperty("provisioningState")]
            public string? ProvisioningState { get; set; }

            /**
             * The network-specific identifier of the device on the network
             */
            [JsonProperty("networkId")]
            public string? NetworkId { get; set; }


            /**
             * True if the device is executing locally on the hub
             */
            [JsonProperty("executingLocally")]
            public bool ExecutingLocally { get; set; }
        }
        public partial class MatterDeviceDetails : DeviceDetails
        {
            /**
             * Optional Vendor-supplied unique identifier.
             */
            [JsonProperty("uniqueId")] public string? UniqueId { get; set; }
        }

        public partial class IrDeviceDetails
        {
            [JsonProperty("parentDeviceId")]
            public string? ParentDeviceId { get; set; } // <^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$>
            [JsonProperty("profileId")]
            public string? ProfileId { get; set; } // <^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$>
            [JsonProperty("ocfDeviceType")]
            public string? OcfDeviceType { get; set; }
            [JsonProperty("irCode")]
            public string? IrCode { get; set; }
            // eslint-disable-next-line @typescript-eslint/no-explicit-any
            [JsonProperty("functionCodes")]
            public Dictionary<string, object>? FunctionCodes { get; set; }
            [JsonProperty("childDevices")]
            public IrDeviceDetails[]? ChildDevices { get; set; }
            [JsonProperty("metadata")] public object? Metadata { get; set; }
        }

        public partial class OcfDeviceDetails
        {
            [JsonProperty("deviceId")]
            public string? DeviceId { get; set; }
            [JsonProperty("ocfDeviceType")]
            public string? OcfDeviceType { get; set; }
            [JsonProperty("name")]
            public string? Name { get; set; }
            [JsonProperty("specVersion")]
            public string? SpecVersion { get; set; }
            [JsonProperty("verticalDomainSpecVersion")]
            public string? VerticalDomainSpecVersion { get; set; }
            [JsonProperty("manufacturerName")]
            public string? ManufacturerName { get; set; }
            [JsonProperty("modelNumber")]
            public string? ModelNumber { get; set; }
            [JsonProperty("platformVersion")] public string? PlatformVersion { get; set; }
            [JsonProperty("platformOS")] public string? PlatformOS { get; set; }
            [JsonProperty("hwVersion")] public string? HwVersion { get; set; }
            [JsonProperty("firmwareVersion")] public string? FirmwareVersion { get; set; }
            [JsonProperty("vendorId")] public string? VendorId { get; set; }
            [JsonProperty("vendorResourceClientServerVersion")] public string? VendorResourceClientServerVersion { get; set; }
            [JsonProperty("locale")] public string? Locale { get; set; }
            [JsonProperty("lastSignupTime")] public string? LastSignupTime { get; set; }
        }

        public partial class ViperDeviceDetails
        {
            [JsonProperty("uniqueIdentifier")] public string? UniqueIdentifier { get; set; }
            [JsonProperty("manufacturerName")] public string? ManufacturerName { get; set; }
            [JsonProperty("modelName")] public string? ModelName { get; set; }
            [JsonProperty("swVersion")] public string? SwVersion { get; set; }
            [JsonProperty("hwVersion")] public string? HwVersion { get; set; }
        }

        public partial class AttributeValue
        {
            /**
             * The attribute that this command will correspond to
             */
            [JsonProperty("attribute")]
            public string? Attribute { get; set; }

            /**
             * How will the attribute be provided? Choose 'ARGUMENT' to provide it with a command at
             * runtime or 'STATIC' to provide a set value here.
             */
            [JsonProperty("inputType")]
            public string? InputType { get; set; }//'ARGUMENT' | 'STATIC'

            /**
             * The argument to be used automatically for this command mapping. Any simple type is accepted.
             */
            [JsonProperty("staticValue")]
            public object? StaticValue { get; set; }  //string | number | boolean

        }

        public partial class CommandMapping
        {
            [JsonProperty("capabilityId")]
            public string CapabilityId { get; set; }

            /**
             * The capability version number.
             */
            [JsonProperty("version")]
            public string Version { get; set; }

            /**
             * The command name to apply the mapping to on the device
             */
            [JsonProperty("command")]
            public string Command { get; set; }

            /**
             * A collection of attribute values, replicator will use these to create device events in
             * serial for the specified command.
             */
            [JsonProperty("eventValues")]
            public AttributeValue[] EventValues { get; set; }
        }

        public partial class CommandMappings
        {
            [JsonProperty("commands")]
            public CommandMapping[] Commands { get; set; }
        }

        public partial class VirtualDeviceDetails
        {
            [JsonProperty("name")]
            public string? Name { get; set; }
            [JsonProperty("hubId")]
            public string? HubId { get; set; }
            public string? DriverId { get; set; }
            [JsonProperty("commandMappings")]
            public CommandMappings? CommandMappings { get; set; }
        }

        public enum DeviceIntegrationType
        {
            BLE = 0,
            BLE_D2D = 1,
            DTH = 2,
            ENDPOINT_APP = 3,
            GROUP = 4,
            HUB = 5,
            IR = 6,
            IR_OCF = 7,
            LAN = 8,
            MATTER = 9,
            MOBILE = 10,
            MQTT = 11,
            OCF = 12,
            PENGYOU = 13,
            SHP = 14,
            VIDEO = 15,
            VIPER = 16,
            VIRTUAL = 17,
            WATCH = 18,
            ZIGBEE = 19,
            ZWAVE = 20,
        }

        public partial class HealthState
        {
            [JsonProperty("state")]
            public DeviceHealthState State { get; set; }
            [JsonProperty("lastUpdatedDate")]
            public string? LastUpdatedDate { get; set; }
        }

        public partial class ChildDeviceRef
        {
            [JsonProperty("id")]
            public string Id { get; set; }
        }

        //export type DeviceClientAction = 'w:devices' | 'w:devices:locationId' | 'w:devices:roomId' | 'x:devices' | 'd:devices'

        public partial class DeviceModel
        {
            public string deviceId { get; set; }

            /**
             * A non-unique id that is used to help drive UI information.
             */
            public string presentationId { get; set; }

            /**
             * The device manufacturer name.
             */
            public string manufacturerName { get; set; }

            /**
             * The type of device integration (may be null). If the type is LAN, the device implementation
             * is a groovy Device Handler and the details are in the "lan" field. If the type is
             * ENDPOINT_APP, the device implementation is a SmartApp and the details are in the "app"
             * field, etc.
             */
            public DeviceIntegrationType type { get; set; }

            /**
             * Restriction tier of the device, if any.
             *
             * integer value
             */
            public int restrictionTier { get; set; }

            /**
             * The name that the Device integration (Device Handler or SmartApp) defines for the Device.
             */
            public string? name { get; set; }

            /**
             * The name that a user chooses for the Device. This defaults to the same value as name.
             */
            public string? label { get; set; }

            /**
             * The device manufacturer code.
             */
            public string? deviceManufacturerCode { get; set; }

            /**
             * The ID of the Location with which the Device is associated.
             *
             * matches; <^(?:([0-9a-fA-F]{32})|([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}))$>
             */
            public string? locationId { get; set; }

            /**
             *
             */
            public string? eventId { get; set; }

            /**
             * The identifier for the owner of the Device instance.
             */
            public string? ownerId { get; set; }

            /**
             * The ID of the Room with which the Device is associated. If the Device is not associated with
             * any room, this field will be null.
             *
             * matches: <^(?:([0-9a-fA-F]{32})|([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}))$>
             */
            public string? roomId { get; set; }

            /**
             * @deprecated please use dth.deviceTypeId instead
             *
             * matches: <^(?:([0-9a-fA-F]{32})|([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}))$>
             */
            public string? deviceTypeId { get; set; }

            /**
             * The IDs of all components on the device.
             */
            public Component[]? components { get; set; }

            /**
             * The time when the device was created.
             */
            public string? createTime { get; set; }

            /**
             * The id of the parent device.
             */
            public string? parentDeviceId { get; set; }

            /**
             * References containing device ids of all child devices of the device.
             */
            public ChildDeviceRef[]? childDevices { get; set; }

            public DeviceProfileReference? profile { get; set; }

            public AppDeviceDetails? app { get; set; }
            public BleDeviceDetails? ble { get; set; }
            public BleD2DDeviceDetails? bleD2D { get; set; }
            public DthDeviceDetails? dth { get; set; }
            public LanDeviceDetails? lan { get; set; }
            public ZigbeeDeviceDetails? zigbee { get; set; }
            public ZwaveDeviceDetails? zwave { get; set; }
            public MatterDeviceDetails? matter { get; set; }
            public IrDeviceDetails? ir { get; set; }
            public IrDeviceDetails? irOcf { get; set; }
            public OcfDeviceDetails? ocf { get; set; }
            public ViperDeviceDetails? viper { get; set; }
            public VirtualDeviceDetails? virtuall { get; set; }

            /**
             * List of client-facing action identifiers that are currently permitted for the user.
             * If the value of this property is not null, then any action not included in the list value of
             * the property is currently prohibited for the user.
             *
             * * w:devices - the user can change device details
             * * w:devices:locationId - the user can move the device from a location
             * * w:devices:roomId - the user can move or remove the device from a room
             * * x:devices - the user can execute commands on the device
             * * d:devices - the user can uninstall the device
             */
            public string[]? allowed { get; set; }  //?: DeviceClientAction[]
        }

        public partial class UpdateDeviceComponent
        {
            public string id { get; set; }
            public string[] categories { get; set; }
            public string? icon { get; set; }
        }

        public partial class DeviceUpdate
        {
            public string? label { get; set; }
            public string? locationId { get; set; }
            public string? roomId { get; set; }
            public UpdateDeviceComponent[]? components { get; set; }
        }

        public partial class DeviceProfileUpdate
        {
            public string? profileId { get; set; }
        }

        public partial class CreateAppDeviceDetails
        {
            public string? profileId { get; set; }
            /**
             * installedAppId is required but the user can set a default when instantiating
             * SmartThingsClient so we don't required it here.
             *
             * <^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$>
             */
            public string? installedAppId { get; set; }

            /**
             * A field to store an ID from a system external to SmartThings.
             *
             * <= 64 characters
             */
            public string? externalId { get; set; }
        }

        public partial class DeviceCreateBase
        {
            public CreateAppDeviceDetails? app { get; set; }
            /**
             * locationId is required but the user can set a default when instantiating
             * SmartThingsClient so we don't required it here.
             */
            public string? locationId { get; set; } // <^(?:([0-9a-fA-F]{32})|([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}))$>
            public string? label { get; set; }
            public string? roomId { get; set; }
        }
        public partial class DeviceCreate : DeviceCreateBase
        {
            public CreateAppDeviceDetails? app { get; set; }
        }

        public partial class AlternateDeviceCreate : DeviceCreateBase
        {
            public string? installedAppId { get; set; } // <^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$>

            /**
             * A field to store an ID from a system external to SmartThings.
             *
             * <= 64 characters
             */
            public string? externalId { get; set; }
            public string? profileId { get; set; }
            public object? app { get; set; }
        }

        public partial class DeviceList
        {
            [JsonProperty("items")]
            public Device[]? Items { get; set; }
            [JsonProperty("_links")]
            public Links? Links { get; set; }
        }

        public partial class AttributeState
        {
            public object? value { get; set; }
            public string? unit { get; set; }
            public Dictionary<string, object>? data { get; set; }

            public string? timestamp { get; set; } // date-time ("Will always be 0 time-zone offset" whatever that means)
        }

        //verify this TODO
        public partial class CapabilityStatus
        {
            public Dictionary<string, AttributeState> attributeName { get; set; }
        }

        public partial class ComponentStatus
        {
            public Dictionary<string, CapabilityStatus> attributeName { get; set; }
            //[attributeName: string]: CapabilityStatus
        }

        public partial class DeviceStatus
        {
            public Dictionary<string, ComponentStatus>? components { get; set; }
            //components?: { [componentId: string]: ComponentStatus
            public HealthState? healthState { get; set; }
        }

        public partial class DeviceEvent
        {
            public object? value { get; set; }
            public string component { get; set; }
            public string capability { get; set; }
            public string attribute { get; set; }
            public string? unit { get; set; }
            public Dictionary<string, object> data { get; set; }
            //value: unknown
            //component: string
            //capability: string
            //attribute: string
            //unit?: string
            //data?: { [name: string]: object
        }
    }

    public partial class DeviceEventList
    {
        public DeviceEvent[] deviceEvents { get; set; }
    }

    public enum DeviceHealthState
    {
        ONLINE = 0,
        OFFLINE = 1,
        UNKNOWN = 2,
    }

    public partial class DeviceHealth
    {
        public string deviceId { get; set; }
        public DeviceHealthState state { get; set; } 
        public string? lastUpdatedDate { get; set; }
    }

    public partial class Command : CommandRequest
    {
        //public string capability { get; set; }
        //public string command { get; set; }
        public string? component { get; set; }
        //public object[] arguments { get; set; }
    }

    public partial class CommandRequest
    {
        public string capability { get; set; }
        public string command { get; set; }
        public object[] arguments { get; set; }
    }

    public partial class CommandList
    {
        public Command[] commands { get; set; }
    }

    //export type CommandStatus = 'ACCEPTED' | 'COMPLETED' | 'FAILED'
    public enum CommandStatus
    {
        ACCEPTED = 0,
        COMPLETED = 1,
        FAILED = 2
    }

public partial class CommandResult
    {
        public string id { get; set; }
        public CommandStatus status { get; set; } //string
    }

    public partial class CommandResponse
    {
        public CommandResult[] results { get; set; }
    }

    //export type PreferenceType = 'integer' | 'number' | 'boolean' | 'string' | 'enumeration'


public partial class DevicePreferenceEntry
    {
        public string preferenceType { get; set; }
        public object value { get; set; }
    }

    public partial class DevicePreferenceResponse
    {
        /**
         * Map of preference name to its stored value
         */
        public Dictionary<string, DevicePreferenceEntry> values { get; set; }
    }

    public partial class DeviceListOptions
    {
        /**
         * Capability ID (for example, 'switchLevel') or array of capability IDs
         */
        public string[]? capability { get; set; } //string or string[]

        /**
         * Location UUID or array of location UUIDs
         */
        public string[]? locationId { get; set; }//?: string | string[]

        /**
         * Device UUID or array of device UUIDs
         */
        public string[]? deviceId { get; set; } //    string | string[]

        /**
         * Whether to AND or OR the capability IDs when more than one is specified
         */
        public string? capabilitiesMode { get; set; }  //'and' | 'or'

    /**
	 * Restricted Devices are hidden by default. This option will reveal them. Device status will
	 * not be provided if the token does not have sufficient access level to view the device status
	 * even if includeStatus parameter is set to true.
	 */
    public bool includeRestricted { get; set; }

    /**
	 * Only list Devices accessible by the given integer accessLevel.
	 */
    public int? accessLevel { get; set; }

    /**
	 * UUID of an installed app instance
	 */
    public string? installedAppId { get; set; }

    /**
	 * Include the device health, i.e. online/offline status in the response
	 */
    public bool includeHealth { get; set; }

    /**
	 * Include the device status data, i.e. the values of all attributes, in the response
	 */
    public bool includeStatus { get; set; }

    /**
	 * Limit the number of results to this value. By default all devices are returned
	 */
    public int? max { get; set; }

    /**
	 * Page number for when a max number of results has been specified, starting with 1
	 */
    public int? page { get; set; }

    /**
	 * Device Type
	 */
    public DeviceIntegrationType[]? type { get; set; } //DeviceIntegrationType | DeviceIntegrationType[]
    }

    public partial class DeviceGetOptions
    {
        /**
         * Include the device health, i.e. online/offline status in the response
         */
        public bool includeHealth { get; set; }

        /**
         * Include the device status data, i.e. the values of all attributes, in the response
         */
        public bool includeStatus { get; set; }
    }

    public partial class HueSaturation
    {
        public int hue { get; set; }
        public int saturation { get; set; }
    }














}
}

