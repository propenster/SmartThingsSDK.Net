using System;
using System.Threading.Tasks;
using SmarthThingsSDK.Net.Interfaces;
using SmarthThingsSDK.Net.Models;
using static SmarthThingsSDK.Net.Interfaces.Device;
using static SmarthThingsSDK.Net.Interfaces.Room;

namespace SmarthThingsSDK.Net.Endpoints
{
    public class RoomEndpoint : IRoom
    {
        private readonly SmartThingsClient _smartThingsClient;
        private static string _locationBaseUrl = "locations";

        public RoomEndpoint(SmartThingsClient smartThingsClient)
        {
            _smartThingsClient = smartThingsClient;
        }

        public async Task<SmartThingsResponse<PaginatedResponse<RoomModel>>> List(string locationId)
        {
            return await _smartThingsClient.GetAsync<PaginatedResponse<RoomModel>>($"{_locationBaseUrl}/{locationId}/rooms");
        }

        public async Task<SmartThingsResponse<Room.RoomModel>> Get(string id, string locationId)
        {
            return await _smartThingsClient.GetAsync<RoomModel>($"{_locationBaseUrl}/{locationId}/rooms/{id}");
        }

        public async Task<SmartThingsResponse<RoomModel>> Create(string locationId, RoomRequest room)
        {
            return await _smartThingsClient.PostAsync<RoomModel>($"{_locationBaseUrl}/{locationId}/rooms", room);
        }

        public async Task<SmartThingsResponse<RoomModel>> Update(string id, string locationId, RoomRequest room)
        {
            return await _smartThingsClient.PutAsync<RoomModel>($"{_locationBaseUrl}/{locationId}/rooms/{id}", room);
        }

        public async Task<SmartThingsResponse<EmptyResponse>> Delete(string id, string locationId)
        {
            return await _smartThingsClient.DeleteAsync<EmptyResponse>($"{_locationBaseUrl}/{locationId}/rooms/{id}");

        }
        public async Task<SmartThingsResponse<PaginatedResponse<DeviceModel>>> ListDevices(string id, string locationId)
        {
            return await _smartThingsClient.GetAsync<PaginatedResponse<DeviceModel>>($"{_locationBaseUrl}/{locationId}/rooms/{id}/devices");
        }
    }
}

