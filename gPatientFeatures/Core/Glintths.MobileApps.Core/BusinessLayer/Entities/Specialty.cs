using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class Specialty
    {

        [DataMember]
        public string Group { get; set; }
        [DataMember]
        public int SpecialtyId { get; set; }
        [DataMember]
        public string SpecialtyCode { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public List<ClinicalService> ClinicalServices { get; set; }


        [DataMember]
        public bool Visible { get; set; }
        [DataMember]
        public COEntityStatus Status { get; set; }

        public const string DeepPropertyLocalSpecialties = "LocalSpecialties";


        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast return false.
            Specialty other = obj as Specialty;
            if ((System.Object)other == null)
            {
                return false;
            }

            string thisId = SpecialtyId.ToString();
            string otherId = other.SpecialtyId.ToString();
            return thisId == otherId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
