using Common.Models.Device;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.IServices
{
    public interface ISignalRService : IBaseService
    {
        Task PublishDevicesAndStatusesAsync(IEnumerable<StatusDto> statuses, int sentObjects, int totalObjects);
    }
}