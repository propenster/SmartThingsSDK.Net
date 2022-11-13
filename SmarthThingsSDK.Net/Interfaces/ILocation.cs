using System;
using System.Threading.Tasks;
using SmarthThingsSDK.Net.Models;
using static SmarthThingsSDK.Net.Interfaces.Location;

namespace SmarthThingsSDK.Net.Interfaces
{
    public interface ILocation
    {
        Task<SmartThingsResponse<PaginatedResponse<LocationItem>>> List();
        Task<SmartThingsResponse<LocationModel>> Get(string? id, LocationGetOptions? options);
        Task<SmartThingsResponse<LocationModel>> Create(LocationCreate location);
        Task<SmartThingsResponse<LocationModel>> Update(string id, LocationUpdate location);
        Task<SmartThingsResponse<EmptyResponse>> Delete(string id);
    }
}

