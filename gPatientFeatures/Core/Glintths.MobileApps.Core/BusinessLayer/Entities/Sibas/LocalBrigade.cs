using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class LocalBrigade
    {
        [DataMember]
        public string Address;
        [DataMember]
        public DateTime BrigadeDate;
        [DataMember]
        public string CodBrigade;
        [DataMember]
        public int CompanyId;
        [DataMember]
        public string Description;
        [DataMember]
        public string IntervalHours;
        [DataMember]
        public string Latitude;
        [DataMember]
        public string Locality;
        [DataMember]
        public string Longitude;
        [DataMember]
        public string PostalCode;
    }
}
