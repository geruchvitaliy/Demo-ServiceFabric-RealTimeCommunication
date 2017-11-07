using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common.Models.Device
{
    [DataContract]
    [Serializable]
    public class Location : ValueObject<Location>
    {
        public static readonly Location Empty = new Location(0, 0, new DateTime());

        public Location(decimal latitude, decimal longitude, DateTime date)
        {
            Latitude = latitude;
            Longitude = longitude;
            Date = date;
        }

        [DataMember]
        public decimal Latitude { get; private set; }

        [DataMember]
        public decimal Longitude { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        protected override IEnumerable<object> EqualityCheckAttributes =>
            new object[] { Latitude, Longitude, Date };
    }
}