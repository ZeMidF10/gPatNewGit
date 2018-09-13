using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class LocalContactValueKey
    {
        [DataMember]
        public string Key;
        [DataMember]
        public string Value;

    }
}
