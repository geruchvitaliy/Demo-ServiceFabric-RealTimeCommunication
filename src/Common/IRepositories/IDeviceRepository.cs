using Common.Models.Device;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.IRepositories
{
    public interface IDeviceRepository : IBaseRepository
    {
        Task<Profile> GetProfileAsync(DeviceId id);
        Task<IEnumerable<Location>> GetLocationsAsync(DeviceId id);
        Task<Location> GetLastLocationAsync(DeviceId id);
        Task AddLocationAsync(DeviceId id, Location location);
        Task UpdateProfileAsync(DeviceId id, Profile profile);
    }
}