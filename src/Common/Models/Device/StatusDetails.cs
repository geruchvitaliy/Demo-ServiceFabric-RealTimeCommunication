using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common.Models.Device
{
    [DataContract]
    [Serializable]
    public class StatusDetails : ValueObject<Profile>
    {
        public static StatusDetails New(DeviceId deviceId) =>
            new StatusDetails(deviceId);

        public StatusDetails(DeviceId deviceId)
        {
            DeviceId = deviceId;
            LastCommunicationDate = DateTime.UtcNow;
        }

        [DataMember]
        public DeviceId DeviceId { get; private set; }

        [DataMember]
        public Location LastLocation { get; private set; }

        [DataMember]
        public DateTime LastCommunicationDate { get; private set; }

        public StatusDetails UpdateLastLocation(Location location) =>
            new StatusDetails(DeviceId) { LastLocation = location };

        public StatusDetails UpdateLastCommunicationDate(DateTime date) =>
            new StatusDetails(DeviceId) { LastLocation = LastLocation, LastCommunicationDate = date };

        protected override IEnumerable<object> EqualityCheckAttributes =>
            new object[] { DeviceId, LastLocation };
    }
}