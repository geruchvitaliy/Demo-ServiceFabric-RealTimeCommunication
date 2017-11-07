using Common.Models.Device;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ServiceFabric.Services.Communication.AspNetCore;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.FabricTransport.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using System.Collections.Generic;
using System.Fabric;
using System.IO;
using System.Threading.Tasks;

namespace SignalR
{
    internal sealed class SignalR : StatelessService, Common.ServiceFabric.Actors.ISignalRStatelessService
    {
        public SignalR(StatelessServiceContext context)
            : base(context)
        { }

        public async Task PublishDevicesAndStatusesAsync(IEnumerable<StatusDto> statuses, int sentObjects, int totalObjects) =>
            await Task.Run(() => Startup.Publisher.PublishDevicesAndStatuses(statuses, sentObjects, totalObjects));

        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new ServiceInstanceListener[]
            {
                new ServiceInstanceListener(serviceContext => new FabricTransportServiceRemotingListener(serviceContext, this, new FabricTransportRemotingListenerSettings(){
                     EndpointResourceName = "SFServiceEndpoint",
                }), "SFServiceEndpoint"),

                new ServiceInstanceListener(serviceContext =>
                    new WebListenerCommunicationListener(serviceContext, "ServiceEndpoint", (url, listener) =>
                    {
                        ServiceEventSource.Current.ServiceMessage(serviceContext, $"Starting WebListener on {url}");

                        return new WebHostBuilder().UseWebListener()
                                    .ConfigureServices(
                                        services => services
                                            .AddSingleton<StatelessServiceContext>(serviceContext))
                                    .UseContentRoot(Directory.GetCurrentDirectory())
                                    .UseStartup<Startup>()
                                    .UseServiceFabricIntegration(listener, ServiceFabricIntegrationOptions.None)
                                    .UseUrls(url)
                                    .Build();
                    }))
            };
        }
    }
}