using Common.IRepositories;
using Common.Models.Device;
using Common.ServiceFabric.Actors;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ServiceFabric.Repositories
{
    public sealed class DeviceRepository : BaseRepository, IDeviceRepository
    {
        public DeviceRepository(IActorProvider actorProvider)
            : base(actorProvider)
        { }

        private IDeviceActor For(DeviceId identity) =>
            _actorProvider.GetDeviceActor(identity);

        public async Task<IEnumerable<Location>> GetLocationsAsync(DeviceId id) =>
            await For(id).GetLocationsAsync();

        public async Task<Profile> GetProfileAsync(DeviceId id) =>
            await For(id).GetProfileAsync();

        public async Task<Location> GetLastLocationAsync(DeviceId id) =>
            (await For(id).GetLocationsAsync()).OrderByDescending(x => x.Date).FirstOrDefault();

        public async Task AddLocationAsync(DeviceId id, Location location) =>
            await For(id).AddLocationAsync(location);

        public async Task UpdateProfileAsync(DeviceId id, Profile profile) =>
            await For(id).UpdateProfileAsync(profile);
    }
}