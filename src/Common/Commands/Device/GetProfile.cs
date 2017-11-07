using Common.Models.Device;
using MediatR;
using System;

namespace Common.Commands.Device
{
    public class GetProfile : IRequest<Profile>
    {
        public GetProfile(Guid deviceId)
        {
            DeviceId = new DeviceId(deviceId);
        }

        public DeviceId DeviceId { get; private set; }
    }
}