using Common.Models.Device;

namespace Common.ServiceFabric.Actors
{
    public interface IActorProvider
    {
        IDeviceActor GetDeviceActor(DeviceId deviceId);
        IDeviceTypeActor GetDeviceTypeActor();

        ISignalRStatelessService GetSignalRService();
        IDeviceTypeStatefulService GetDeviceTypeService();
    }
}