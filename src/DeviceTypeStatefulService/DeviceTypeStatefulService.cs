using Common.Models;
using Common.Models.Device;
using Microsoft.ServiceFabric.Data.Collections;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;

namespace DeviceTypeStatefulService
{
    internal sealed class DeviceTypeStatefulService : StatefulService, Common.ServiceFabric.Actors.IDeviceTypeStatefulService
    {
        private const string UniqueDevicesKey = "(devices)";
        private const int SyncReminderDuration = 300;
        private bool _syncStarted;
        private Task<IReliableDictionary<Guid, StatusDetails>> DevicesStateTask =>
            StateManager.GetOrAddAsync<IReliableDictionary<Guid, StatusDetails>>(UniqueDevicesKey);
        private Timer _syncReminder;

        public DeviceTypeStatefulService(StatefulServiceContext context)
            : base(context)
        { }

        public async Task<int> GetDevicesCountAsync()
        {
            var state = await DevicesStateTask;
            using (var tx = StateManager.CreateTransaction())
                return (int)await state.GetCountAsync(tx);
        }

        public async Task<IEnumerable<DeviceId>> GetDevicesIdsAsync(DataPage page)
        {
            long i = -1;
            long startSelect = page.PageNumber * page.PageSize;
            long endSelect = startSelect + page.PageSize;
            var result = new List<DeviceId>();

            var state = await DevicesStateTask;
            using (var tx = StateManager.CreateTransaction())
            {

                var enumerableAsync = await state.CreateEnumerableAsync(tx, key => { i++; return i >= startSelect && i <= endSelect; }, EnumerationMode.Unordered);
                using (var asyncEnumerator = enumerableAsync.GetAsyncEnumerator())
                {
                    while (await asyncEnumerator.MoveNextAsync(CancellationToken.None).ConfigureAwait(false))
                        result.Add(asyncEnumerator.Current.Value.DeviceId);
                }
            }
            return result;
        }

        public async Task<IEnumerable<StatusDetails>> GetDevicesStatusesAsync(DataPage page)
        {
            long i = -1;
            long startSelect = page.PageNumber * page.PageSize;
            long endSelect = startSelect + page.PageSize;
            var result = new List<StatusDetails>();

            var state = await DevicesStateTask;
            using (var tx = StateManager.CreateTransaction())
            {
                var enumerableAsync = await state.CreateEnumerableAsync(tx, key => { i++; return i >= startSelect && i <= endSelect; }, EnumerationMode.Unordered);
                using (var asyncEnumerator = enumerableAsync.GetAsyncEnumerator())
                {
                    while (await asyncEnumerator.MoveNextAsync(CancellationToken.None).ConfigureAwait(false))
                        result.Add(asyncEnumerator.Current.Value);
                }
            }
            return result;
        }

        public async Task<bool> ContainsDeviceAsync(DeviceId deviceId)
        {
            var state = await DevicesStateTask;
            using (var tx = StateManager.CreateTransaction())
                return await state.ContainsKeyAsync(tx, deviceId);
        }

        public async Task AddDeviceAsync(DeviceId deviceId)
        {
            var state = await DevicesStateTask;
            using (var tx = StateManager.CreateTransaction())
            {
                await state.AddAsync(tx, deviceId, StatusDetails.New(deviceId));

                await tx.CommitAsync();
            }
        }

        public async Task UpdateLocationAsync(DeviceId deviceId, Location location)
        {
            var state = await DevicesStateTask;
            using (var tx = StateManager.CreateTransaction())
            {
                var device = await state.TryGetValueAsync(tx, deviceId);
                if (!device.HasValue)
                    throw new InvalidOperationException();

                var newDevice = device.Value.UpdateLastLocation(location);
                var result = await state.TryUpdateAsync(tx, deviceId, newDevice, device.Value);
                if (!result)
                    throw new InvalidOperationException();

                await tx.CommitAsync();
            }
        }

        public async Task UpdateCommunicationDateAsync(DeviceId deviceId, DateTime date)
        {
            var state = await DevicesStateTask;
            using (var tx = StateManager.CreateTransaction())
            {
                var device = await state.TryGetValueAsync(tx, deviceId);
                if (!device.HasValue)
                    throw new InvalidOperationException();

                var newDevice = device.Value.UpdateLastCommunicationDate(date);
                var result = await state.TryUpdateAsync(tx, deviceId, newDevice, device.Value);
                if (!result)
                    throw new InvalidOperationException();

                await tx.CommitAsync();
            }
        }

        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners() =>
            new[] { new ServiceReplicaListener(context => this.CreateServiceRemotingListener(context)) };

        protected override Task RunAsync(CancellationToken cancellationToken)
        {
            _syncReminder = new Timer(CheckStatuses, null, TimeSpan.FromSeconds(SyncReminderDuration), TimeSpan.FromSeconds(SyncReminderDuration));

            return base.RunAsync(cancellationToken);
        }

        private async void CheckStatuses(object state)
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