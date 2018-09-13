using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class LocalPatientData
    {
        public const string DP_FINANCIALENTITYID = "FINANCIALENTITYID";

        [DataMember]
        public DateTime? BirthDate { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string FinancialEntityId { get; set; }
        [DataMember]
        public string IdNumber { get; set; }
        public DateTime LastRegisterDate { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string NSns { get; set; }
        [DataMember]
        public string NumProcess { get; set; }
        [DataMember]
        public string PatId { get; set; }
        [DataMember]
        public string PatType { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string PhoneNumber2 { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string Sex { get; set; }
        [DataMember]
        public string ShortName { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string TaxIdNumber { get; set; }
    }
}
