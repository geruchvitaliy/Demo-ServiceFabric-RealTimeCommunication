using Common.IServices;
using Common.Models.Device;
using Common.ServiceFabric.Actors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.ServiceFabric.Services
{
    public sealed class SignalRService : BaseService, ISignalRService
    {
        private readonly IActorProvider _actorProvider;

        public SignalRService(IActorProvider actorProvider)
        {
            _actorProvider = actorProvider;
        }

        public async Task PublishDevicesAndStatusesAsync(IEnumerable<StatusDto> statuses, int sentObjects, int totalObjects) =>
            await _actorProvider.GetSignalRService().PublishDevicesAndStatusesAsync(statuses, sentObjects, totalObjects);
    }
}