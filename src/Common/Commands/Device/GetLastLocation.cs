using Common.Models.Device;
using MediatR;
using System;

namespace Common.Commands.Device
{
    public class GetLastLocation : IRequest<Location>
    {
        public GetLastLocation(Guid deviceId)
        {
            DeviceId = new DeviceId(deviceId);
        }

        public DeviceId DeviceId { get; private set; }
    }
}