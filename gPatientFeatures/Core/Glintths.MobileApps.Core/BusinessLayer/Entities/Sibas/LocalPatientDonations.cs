using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class LocalPatientDonations
    {
        [DataMember]
        public string CodDonation { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime DateDonation { get; set; }

        [DataMember]
        public string Height { get; set; }

        [DataMember]
        public string Weight { get; set; }

        [DataMember]
        public string BloodPressure { get; set; }

        [DataMember]
        public string Hemoglobin { get; set; }

        [DataMember]
        public List<DonationResult> DonationResults { get; set; }

        [DataMember]
        public int Volume_ML { get; set; }
    }

    [DataContract]
    public class DonationResult
    {
        [DataMember]
        public string ResultTitle { get; set; }

        [DataMember]
        public string Result { get; set; }
    }
}