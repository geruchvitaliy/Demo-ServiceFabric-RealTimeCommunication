using Common.Models;
using Common.Models.Device;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.IRepositories
{
    public interface IDeviceTypeRepository : IBaseRepository
    {
        Task<int> GetDevicesCountAsync();
        Task<IEnumerable<DeviceId>> GetDevicesIdsAsync(DataPage page);
        Task<IEnumerable<StatusDetails>> GetDevicesStatusesAsync(DataPage page);
        Task<bool> IsDeviceRegisteredAsync(DeviceId deviceId);
        Task RegisterDeviceAsync(DeviceId deviceId);
        Task UpdateLocationAsync(DeviceId deviceId, Location location);
        Task UpdateCommunicationDateAsync(DeviceId deviceId, DateTime date);
    }
}