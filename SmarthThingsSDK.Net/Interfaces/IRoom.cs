using SmarthThingsSDK.Net.Models;
using System.Threading.Tasks;
using static SmarthThingsSDK.Net.Interfaces.Room;
using static SmarthThingsSDK.Net.Interfaces.Device;

namespace SmarthThingsSDK.Net.Interfaces
{
    public interface IRoom
    {
        Task<SmartThingsResponse<PaginatedResponse<RoomModel>>> List(string locationId);
        Task<SmartThingsResponse<RoomModel>> Get(string id, string? locationId);
        Task<SmartThingsResponse<RoomModel>> Create(string? locationId, RoomRequest room);
        Task<SmartThingsResponse<RoomModel>> Update(string id, string? locationId, RoomRequest room);
        Task<SmartThingsResponse<EmptyResponse>> Delete(string id, string? locationId);

        //TODO - //ListDevices in a room...
        Task<SmartThingsResponse<PaginatedResponse<DeviceModel>>> ListDevices(string id, string locationId);
    }
}

