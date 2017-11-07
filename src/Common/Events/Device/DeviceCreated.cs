using Common.Models.Device;
using MediatR;

namespace Common.Events.Device
{
    public class DeviceCreated : INotification
    {
        public DeviceCreated(DeviceId deviceId)
        {
            DeviceId = deviceId;
        }

        public DeviceId DeviceId { get; private set; }
    }
}