using Common.Models.Device;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using System;

namespace Common.ServiceFabric.Actors
{
    public sealed class ActorProvider : IActorProvider
    {
        private static readonly Uri _baseUrl = new Uri("fabric:/ServiceFabric/");
        private static readonly Uri _deviceActorUrl = new Uri(_baseUrl, Configuration.DeviceActorServiceName);
        private static readonly Uri _deviceTypeActorUrl = new Uri(_baseUrl, Configuration.DeviceTypeActorServiceName);

        private static readonly Uri _signalRServiceUrl = new Uri(_baseUrl, Configuration.SignalRServiceName);
        private static readonly Uri _deviceTypeServiceUrl = new Uri(_baseUrl, Configuration.DeviceTypeServiceName);

        public IDeviceActor GetDeviceActor(DeviceId deviceId) =>
            ActorProxy.Create<IDeviceActor>(new ActorId((Guid)deviceId), _deviceActorUrl);

        public IDeviceTypeActor GetDeviceTypeActor() =>
            ActorProxy.Create<IDeviceTypeActor>(new ActorId(0), _deviceTypeActorUrl);

        public ISignalRStatelessService GetSignalRService() =>
            ServiceProxy.Create<ISignalRStatelessService>(_signalRServiceUrl, listenerName: "SFServiceEndpoint");

        public IDeviceTypeStatefulService GetDeviceTypeService() =>
            ServiceProxy.Create<IDeviceTypeStatefulService>(_deviceTypeServiceUrl, new ServicePartitionKey(1));
    }
}