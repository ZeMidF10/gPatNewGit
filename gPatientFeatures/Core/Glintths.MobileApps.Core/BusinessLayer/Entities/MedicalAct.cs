using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class MedicalAct
    {
        /// <summary>
        /// Agrupador de Unidades Hospitalares
        /// </summary>
        [DataMember]
        public string Group { get; set; }

        [DataMember]
        public int MedicalActId { get; set; }
        [DataMember]
        public int SpecialtyId { get; set; }
        [DataMember]
        public string MedicalActCode { get; set; }
        [DataMember]
        public MedicalActType ActType { get; set; } //exame ou consulta

        [DataMember]
        public bool Schedulable { get; set; }
        [DataMember]
        public bool Requestable { get; set; }


        [DataMember]
        public List<Rubric> Rubrics { get; set; }

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public COEntityStatus Status { get; set; }
        [DataMember]
        public bool Visible { get; set; }

        [DataMember]
        public DateTime NormalDuration { get; set; }
        [DataMember]
        public DateTime FirstTimeDuration { get; set; }
        [DataMember]
        public int MinimumAge { get; set; }
        [DataMember]
        public int MaximumAge { get; set; }

        [DataMember]
        public bool IsAvailableForScheduling { get; set; }




        //lista de Instituições às quais este Acto está associado
        //[DataMember]
        //List<Facility> Facilities { get; set; }

        [DataMember]
        public List<LocalMedicalAct> LocalMedicalActs { get; set; }



        [DataMember]
        public bool FirstTimeFlag { get; set; }

        public const string DP_LOCALMEDICALACTS = "LOCALMEDICALACTS";
        public const string DP_RUBRICS = "RUBRICS";
        public const string DP_RUBRICS_LOCALMEDICALACTS = "RUBRICS_LOCALMEDICALACTS";


        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast return false.
            MedicalAct other = obj as MedicalAct;
            if ((System.Object)other == null)
            {
                return false;
            }

            string thisId = SpecialtyId + "," + MedicalActId;
            string otherId = other.SpecialtyId + "," + other.MedicalActId;
            return thisId == otherId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    [DataContract]
    public class LocalMedicalAct
    {
        public const string DP_CLINICALSERVICES = "ClinicalService";

        [DataMember]
        public MedicalActType ActType { get; set; }
        [DataMember]
        public ClinicalService ClinicalService { get; set; }
        [DataMember]
        public LocalEntityStatus EntityStatus { get; set; }
        [DataMember]
        public string FacilityId { get; set; }
        //
        // Summary:
        //     Agrupador de Unidades Hospitalares
        [DataMember]
        public string Group { get; set; }
        [DataMember]
        public List<string> ItemCodes { get; set; }
        [DataMember]
        public string MedicalActCode { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public RelationshipEntityStatus RelationshipStatus { get; set; }
        [DataMember]
        public bool Requestable { get; set; }
        [DataMember]
        public bool Schedulable { get; set; }
    }

    [DataContract]
    public enum MedicalActType
    {
        [EnumMember]
        OutPatientConsult = 0,
        [EnumMember]
        Exam = 1,
    }
}
