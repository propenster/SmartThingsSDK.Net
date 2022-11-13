using System;
using System.Threading.Tasks;
using SmarthThingsSDK.Net.Interfaces;
using SmarthThingsSDK.Net.Models;
using static SmarthThingsSDK.Net.Interfaces.Device;
using static SmarthThingsSDK.Net.Interfaces.Location;

namespace SmarthThingsSDK.Net.Endpoints
{
    public class LocationEndpoint : ILocation
    {
        private readonly SmartThingsClient _smartThingsClient;
        private static string _locationBaseUrl = "locations";

        public LocationEndpoint(SmartThingsClient smartThingsClient)
        {
            _smartThingsClient = smartThingsClient;
        }

        public async Task<SmartThingsResponse<LocationModel>> Create(LocationCreate location)
        {
            return await _smartThingsClient.PostAsync<LocationModel>(_locationBaseUrl, location);
        }

        public async Task<SmartThingsResponse<EmptyResponse>> Delete(string id)
        {
            return await _smartThingsClient.DeleteAsync<EmptyResponse>($"{_locationBaseUrl}/{id}");
        }

        public async Task<SmartThingsResponse<LocationModel>> Get(string id, LocationGetOptions options)
        {
            return await _smartThingsClient.GetAsync<LocationModel>($"{_locationBaseUrl}/{id}");
        }

        public async Task<SmartThingsResponse<PaginatedResponse<LocationItem>>> List()
        {
            return await _smartThingsClient.GetAsync<PaginatedResponse<LocationItem>>(_locationBaseUrl);
        }

        public async Task<SmartThingsResponse<LocationModel>> Update(string id, LocationUpdate location)
        {
            return await _smartThingsClient.PutAsync<LocationModel>($"{_locationBaseUrl}/{id}", location);
        }
        
    }
}

