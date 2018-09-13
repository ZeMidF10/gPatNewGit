using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class LocalDonorData
    {
        [DataMember]
        public string CodDador { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public DateTime BornDt { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public string DocIdNumber { get; set; }

        [DataMember]
        public string BlodeType { get; set; }

        [DataMember]
        public string Fenotype { get; set; }

        [DataMember]
        public DateTime NextGift { get; set; }

        [DataMember]
        public string FreeCharge { get; set; }

        [DataMember]
        public DateTime LastUserLogin { get; set; }

        [DataMember]
        public string CND { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string FenotypeDesc { get; set; }
    }
}

