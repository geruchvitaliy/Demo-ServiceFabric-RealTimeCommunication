using Common.IRepositories;
using Common.Models;
using Common.Models.Device;
using Common.ServiceFabric.Actors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.ServiceFabric.Repositories
{
    public sealed class DeviceTypeRepository : BaseRepository, IDeviceTypeRepository
    {
        public DeviceTypeRepository(IActorProvider actorProvider)
            : base(actorProvider)
        { }

        //When I used StatefulService instead of using an Actor,
        //I noticed that performance is much better.
        //I think it's because Actor works in single thread.
        //private IDeviceTypeActor For() =>
        //    _actorProvider.GetDeviceTypeActor();

        private IDeviceTypeStatefulService For() =>
            _actorProvider.GetDeviceTypeService();

        public async Task<int> GetDevicesCountAsync() =>
            await For().GetDevicesCountAsync();

        public async Task<IEnumerable<StatusDetails>> GetDevicesStatusesAsync(DataPage page) =>
            await For().GetDevicesStatusesAsync(page);

        public async Task<IEnumerable<DeviceId>> GetDevicesIdsAsync(DataPage page) =>
            await For().GetDevicesIdsAsync(page);

        public async Task<bool> IsDeviceRegisteredAsync(DeviceId deviceId) =>
            await For().ContainsDeviceAsync(deviceId);

        public async Task RegisterDeviceAsync(DeviceId deviceId) =>
            await For().AddDeviceAsync(deviceId);

        public async Task UpdateLocationAsync(DeviceId deviceId, Location location) =>
            await For().UpdateLocationAsync(deviceId, location);

        public async Task UpdateCommunicationDateAsync(DeviceId deviceId, DateTime date) =>
            await For().UpdateCommunicationDateAsync(deviceId, date);
    }
}