using MediatR;

namespace Common.Commands.Device
{
    public class GetDevicesCount : IRequest<int>
    { }
}