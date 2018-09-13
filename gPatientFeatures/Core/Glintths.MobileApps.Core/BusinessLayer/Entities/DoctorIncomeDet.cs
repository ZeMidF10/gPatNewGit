using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class DoctorIncomeDet
    {
        [DataMember]
        public int IdDoctorIncomeDet { get; set; }

        [DataMember]
        public string DescrOrigin { get; set; }

        [DataMember]
        public string Company { get; set; }

        [DataMember]
        public BillingCompany BillingCompany { get; set; }

        [DataMember]
        public decimal Value { get; set; }

        [DataMember]
        public int IdOrigin { get; set; }


    }
    [DataContract]
    public class BillingCompany
    {
        [DataMember]
        public int FacilityId { get; set; }

        [DataMember]
        public string CompanyId { get; set; }

        [DataMember]
        public string Acronym { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string PostalCode { get; set; }

    }

}
