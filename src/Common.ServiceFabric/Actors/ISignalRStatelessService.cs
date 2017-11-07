using Common.Models.Device;
using Microsoft.ServiceFabric.Services.Remoting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.ServiceFabric.Actors
{
    public interface ISignalRStatelessService : IService
    {
        Task PublishDevicesAndStatusesAsync(IEnumerable<StatusDto> statuses, int sentObjects, int totalObjects);
    }
}