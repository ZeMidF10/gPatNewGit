using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class Sort
    {
        [DataMember]
        public SortOrder Order { get; set; }
        [DataMember]
        public string Property { get; set; }
    }

    [DataContract]
    public enum SortOrder
    {
        [EnumMember]
        Default = 0,
        [EnumMember]
        Asc = 1,
        [EnumMember]
        Desc = 2,
    }


}
