using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class Descendant
    {
        [DataMember]
        public string DescendantUniqueId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public DateTime BirthDate { get; set; }
        [DataMember]
        public string Sex { get; set; }
        [DataMember]
        public string IdNumber { get; set; } //BI
        [DataMember]
        public string TaxIdNumber { get; set; } //NIF
    }
}
