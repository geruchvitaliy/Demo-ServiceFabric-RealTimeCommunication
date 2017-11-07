using Common.Models;
using Common.Models.Device;
using MediatR;
using System.Collections.Generic;

namespace Common.Commands.Device
{
    public class GetDevicesStatuses : IRequest<IEnumerable<StatusDto>>
    {
        public GetDevicesStatuses(int pageNumber, int pageSize)
        {
            Page = new DataPage(pageNumber, pageSize);
        }

        public DataPage Page { get; private set; }
    }
}