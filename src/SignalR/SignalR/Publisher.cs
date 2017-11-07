using Common.Models.Device;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using System.Collections.Generic;

namespace SignalR
{
    public class Publisher
    {
        private readonly IConnectionManager _connectionManager;

        public Publisher(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public void PublishDevicesAndStatuses(IEnumerable<StatusDto> statuses, int sentObjects, int totalObjects)
        {
            var session = new Session(sentObjects, totalObjects);
            _connectionManager.GetHubContext<DevicesHub>()
                .Clients
                .All
                .statusesReceived(statuses, session);
        }
    }
}