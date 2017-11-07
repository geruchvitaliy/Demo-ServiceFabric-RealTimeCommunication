namespace Common.ServiceFabric
{
    public static class Configuration
    {
        public const string ApiServiceAddress = "http://localhost:8105/";
        public const string SignalRServiceAddress = "http://localhost:8104/";
        public const string WebSiteAddress = "http://localhost:8100/";

        public const string DeviceActorServiceName = "DeviceActorService";
        public const string DeviceTypeActorServiceName = "DeviceTypeActorService";

        public const string SignalRServiceName = "SignalR";
        public const string DeviceTypeServiceName = "DeviceTypeStatefulService";
    }
}