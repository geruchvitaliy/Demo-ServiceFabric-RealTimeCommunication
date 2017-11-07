using Common.Models.Device;
using MediatR;

namespace Common.Events.Device
{
    public class LocationUpdated : INotification
    {
        public LocationUpdated(DeviceId deviceId, Location location)
        {
            DeviceId = deviceId;
            Location = location;
        }

        public DeviceId DeviceId { get; private set; }
        public Location Location { get; private set; }
    }
}