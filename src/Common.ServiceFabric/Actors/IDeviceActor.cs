using Common.Models.Device;
using Microsoft.ServiceFabric.Actors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.ServiceFabric.Actors
{
    public interface IDeviceActor : IActor
    {
        Task<IEnumerable<Location>> GetLocationsAsync();
        Task<Profile> GetProfileAsync();
        Task AddLocationAsync(Location location);
        Task UpdateProfileAsync(Profile profile);
    }
}