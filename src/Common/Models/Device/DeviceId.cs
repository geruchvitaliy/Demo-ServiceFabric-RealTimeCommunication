using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common.Models.Device
{
    [DataContract]
    [Serializable]
    public class DeviceId : ValueObject<DeviceId>
    {
        public static DeviceId New() => new DeviceId(Guid.NewGuid());

        public static readonly DeviceId Empty = new DeviceId(Guid.Empty);

        public DeviceId(Guid id)
        {
            Id = id;
        }

        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public string MacAddress { get; private set; }

        public DeviceId UpdateMacAddress(string macAddress) =>
            new DeviceId(Id) { MacAddress = macAddress };

        public override string ToString() => $"{nameof(Id)}: {Id}; {nameof(MacAddress)}: {MacAddress}";

        public static implicit operator Guid(DeviceId deviceId) => deviceId.Id;
        public static implicit operator string(DeviceId deviceId) => deviceId.ToString();

        protected override IEnumerable<object> EqualityCheckAttributes =>
            new object[] { Id, MacAddress };
    }
}