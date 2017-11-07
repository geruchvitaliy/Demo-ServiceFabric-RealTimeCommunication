using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;

namespace SignalR
{
    [HubName(nameof(DevicesHub))]
    public class DevicesHub : Hub
    { }
}