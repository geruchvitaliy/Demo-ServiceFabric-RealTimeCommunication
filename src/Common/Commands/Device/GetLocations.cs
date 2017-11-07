using Common.Models.Device;
using MediatR;
using System;
using System.Collections.Generic;

namespace Common.Commands.Device
{
    public class GetLocations : IRequest<IEnumerable<Location>>
    {
        public GetLocations(Guid deviceId)
        {
            DeviceId = new DeviceId(deviceId);
        }

        public DeviceId DeviceId { get; private set; }
    }
}