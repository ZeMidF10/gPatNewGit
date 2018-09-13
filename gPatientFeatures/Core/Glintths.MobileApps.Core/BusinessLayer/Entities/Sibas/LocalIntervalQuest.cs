using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class LocalIntervalQuest
    {

        [DataMember]
        public string CodInterval { get; set; }
        [DataMember]
        public string DescrInterval { get; set; }
        [DataMember]
        public int Sort { get; set; }
    }
}
