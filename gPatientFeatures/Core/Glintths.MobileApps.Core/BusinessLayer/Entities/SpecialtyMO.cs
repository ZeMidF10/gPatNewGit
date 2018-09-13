using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class SpecialtyMO
    {
        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}
