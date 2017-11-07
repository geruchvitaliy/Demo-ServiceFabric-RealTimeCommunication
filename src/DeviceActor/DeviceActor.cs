using Common.Models.Device;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceActor
{
    [StatePersistence(StatePersistence.Persisted)]
    [ActorService(Name = Common.ServiceFabric.Configuration.DeviceActorServiceName)]
    public class DeviceActor : Actor, Common.ServiceFabric.Actors.IDeviceActor
    {
        private const string UniqueProfileKey = "(profile)";
        private const string UniqueLocationKey = "(locations)";

        public DeviceActor(ActorService actorService, ActorId actorId)
            : base(actorService, actorId)
        { }

        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            var state = await StateManager.TryGetStateAsync<IEnumerable<Location>>(UniqueLocationKey);
            return state.HasValue ? state.Value : new List<Location>();
        }

        public async Task<Profile> GetProfileAsync() =>
            await StateManager.GetStateAsync<Profile>(UniqueProfileKey);

        public async Task AddLocationAsync(Location location)
        {
            var locations = await GetLocationsAsync();
            var newLocations = locations.Union(new[] { location }).ToList();

            await StateManager.SetStateAsync(UniqueLocationKey, newLocations);
        }

        public async Task UpdateProfileAsync(Profile profile) =>
            await StateManager.SetStateAsync(UniqueProfileKey, profile);
    }
}