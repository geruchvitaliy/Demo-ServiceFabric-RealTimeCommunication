using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common.Models.Device
{
    [DataContract]
    [Serializable]
    public class Profile : ValueObject<Profile>
    {
        public static readonly Profile Empty =
            new Profile(null);

        public static Profile New(string name = null) =>
            new Profile(name) { CreatedOn = DateTime.UtcNow };

        public Profile(string name)
        {
            Name = name;
        }

        [DataMember]
        public DateTime CreatedOn { get; private set; }

        [DataMember]
        public DateTime? UpdatedOn { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        public Profile UpdateUpdatedOn(DateTime updatedOn) =>
            new Profile(Name) { CreatedOn = CreatedOn, UpdatedOn = updatedOn };

        protected override IEnumerable<object> EqualityCheckAttributes =>
            new object[] { Name, CreatedOn, UpdatedOn };
    }
}