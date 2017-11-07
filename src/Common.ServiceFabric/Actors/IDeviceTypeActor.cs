using Common.Models;
using Common.Models.Device;
using Microsoft.ServiceFabric.Actors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.ServiceFabric.Actors
{
    public interface IDeviceTypeActor : IActor
    {
        Task<int> GetDevicesCountAsync();
        Task<IEnumerable<DeviceId>> GetDevicesIdsAsync(DataPage page);
        Task<IEnumerable<StatusDetails>> GetDevicesStatusesAsync(DataPage page);
        Task<bool> ContainsDeviceAsync(DeviceId deviceId);
        Task AddDeviceAsync(DeviceId deviceId);
        Task UpdateLocationAsync(DeviceId deviceId, Location location);
        Task UpdateCommunicationDateAsync(DeviceId deviceId, DateTime date);
    }
}