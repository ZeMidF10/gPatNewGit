using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class LocalClinicalService
    {
        [DataMember]
        public string Abbreviation { get; set; }
        [DataMember]
        public bool IsDefaultServ { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ServiceId { get; set; }
        [DataMember]
        public string ServiceType { get; set; }
    }
}
