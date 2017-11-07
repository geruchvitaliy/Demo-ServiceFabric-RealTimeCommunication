using System;

namespace Common.Errors
{
    public class DeviceIdNotRegisteredException : InvalidOperationException
    {
        public DeviceIdNotRegisteredException()
            : base(MessagesContainer.DeviceIdIsNotRegistered)
        { }
    }
}