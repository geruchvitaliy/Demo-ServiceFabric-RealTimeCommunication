using Common.Models;
using Common.Models.Device;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceTypeActor
{
    [StatePersistence(StatePersistence.Persisted)]
    [ActorService(Name = Common.ServiceFabric.Configuration.DeviceTypeActorServiceName)]
    public class DeviceTypeActor : Actor, IRemindable, Common.ServiceFabric.Actors.IDeviceTypeActor
    {
        private const string UniqueDevicesKey = "(devices)";
        private const string SyncReminderName = "SyncStatusReminder";
        private const int SyncReminderDuration = 300;
        private bool _syncStarted;

        public DeviceTypeActor(ActorService actorService, ActorId actorId)
            : base(actorService, actorId)
        { }

        public async Task<int> GetDevicesCountAsync()
        {
            var devices = await GetDevicesAsync();
            return devices.Count();
        }

        public async Task<IEnumerable<DeviceId>> GetDevicesIdsAsync(DataPage page)
        {
            var devices = await GetDevicesAsync();
            return devices.Keys.Skip(page.PageNumber * page.PageSize).Take(page.PageSize);
        }

        public async Task<IEnumerable<StatusDetails>> GetDevicesStatusesAsync(DataPage page)
        {
            var devices = await GetDevicesAsync();
            return devices.Values.Skip(page.PageNumber * page.PageSize).Take(page.PageSize);
        }

        public async Task<bool> ContainsDeviceAsync(DeviceId deviceId)
        {
            var devices = await GetDevicesAsync();
            return devices.ContainsKey(deviceId);
        }

        public async Task AddDeviceAsync(DeviceId deviceId)
        {
            var devices = await GetDevicesAsync();
            devices.Add(deviceId, StatusDetails.New(deviceId));

            await StateManager.SetStateAsync(UniqueDevicesKey, devices);
        }

        public async Task UpdateLocationAsync(DeviceId deviceId, Location location)
        {
            var devices = await GetDevicesAsync();
            devices[deviceId] = devices[deviceId].UpdateLastLocation(location);

            await StateManager.SetStateAsync(UniqueDevicesKey, devices);
        }

        public async Task UpdateCommunicationDateAsync(DeviceId deviceId, DateTime date)
        {
            var devices = await GetDevicesAsync();
            devices[deviceId] = devices[deviceId].UpdateLastCommunicationDate(date);

            await StateManager.SetStateAsync(UniqueDevicesKey, devices);
        }

        private async Task<IDictionary<DeviceId, StatusDetails>> GetDevicesAsync()
        {
            var state = await StateManager.TryGetStateAsync<IDictionary<DeviceId, StatusDetails>>(UniqueDevicesKey);
            return state.HasValue ? state.Value : new Dictionary<DeviceId, StatusDetails>();
        }

        protected override async Task OnActivateAsync()
        {
            await base.OnActivateAsync();

            try
            {
                GetReminder(SyncReminderName);
            }
            catch (ReminderNotFoundException)
            {
                await RegisterReminderAsync(
                    SyncReminderName,
                    new byte[0],
                    TimeSpan.FromSeconds(SyncReminderDuration),
                    TimeSpan.FromSeconds(SyncReminderDuration));
            }
        }

        public Task ReceiveReminderAsync(string reminderName, byte[] state, TimeSpan dueTime, TimeSpan period)
        {
            if (reminderName == SyncReminderName)
                CheckStatuses();
            else
                throw new NotImplementedException();

            return Task.FromResult(0);
        }

        private async void CheckStatuses()
        {
            if (_syncStarted)
                return;

            _syncStarted = true;

            try
            {
                var service = new Common.ServiceFabric.Services.ApiService();
                await service.SyncDevicesStatusesAsync();
            }
            catch (Exception ex)
            {
                //TODO: Log error
                System.Diagnostics.Debug.WriteLine(ex, "Error");
            }
            finally
            {
                _syncStarted = false;
            }
        }
    }
}