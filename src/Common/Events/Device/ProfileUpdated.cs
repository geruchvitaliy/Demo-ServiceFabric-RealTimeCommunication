using Common.Models.Device;
using MediatR;

namespace Common.Events.Device
{
    public class ProfileUpdated : INotification
    {
        public ProfileUpdated(DeviceId deviceId, Profile profile)
        {
            DeviceId = deviceId;
            Profile = profile;
        }

        public DeviceId DeviceId { get; private set; }
        public Profile Profile { get; private set; }
    }
}