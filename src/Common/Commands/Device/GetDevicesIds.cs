using Common.Models;
using Common.Models.Device;
using MediatR;
using System.Collections.Generic;

namespace Common.Commands.Device
{
    public class GetDevicesIds : IRequest<IEnumerable<DeviceId>>
    {
        public GetDevicesIds(int pageNumber, int pageSize)
        {
            Page = new DataPage(pageNumber, pageSize);
        }

        public DataPage Page { get; private set; }
    }
}