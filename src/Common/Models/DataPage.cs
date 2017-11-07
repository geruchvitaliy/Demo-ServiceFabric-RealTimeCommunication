using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common.Models
{
    [DataContract]
    [Serializable]
    public class DataPage : ValueObject<DataPage>
    {
        public static DataPage Default() => new DataPage(0);

        public static readonly DataPage Empty = new DataPage(0, 0);

        [DataMember]
        public int PageNumber { get; private set; }

        [DataMember]
        public int PageSize { get; private set; }

        [DataMember]
        public string OrderBy { get; private set; }

        public DataPage(int pageNumber, int pageSize = 10000, string orderBy = null)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            OrderBy = orderBy;
        }

        public DataPage First() =>
            new DataPage(0, PageSize, OrderBy);

        public DataPage Next() =>
            new DataPage(PageNumber + 1, PageSize, OrderBy);

        public override string ToString() => $"{nameof(PageNumber)}: {PageNumber}; {nameof(PageSize)}: {PageSize}; {nameof(OrderBy)}: {OrderBy}";

        protected override IEnumerable<object> EqualityCheckAttributes =>
            new object[] { PageNumber, PageSize, OrderBy };
    }
}