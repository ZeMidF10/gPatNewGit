using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class AppRequested
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string AppointmentId { get; set; }

        [DataMember]
        public string PatientId { get; set; }

        [DataMember]
        public string SpecialityId { get; set; }

        [DataMember]
        public string SpecialityDescription { get; set; }

        [DataMember]
        public string HumanResourceId { get; set; } 

        [DataMember]
        public string HumanResourceTitle { get; set; }

        [DataMember]
        public string HumanResourceDescription { get; set; }

        [DataMember]
        public string MedicalActId { get; set; }

        [DataMember]
        public string MedicalActDescription { get; set; }

        [DataMember]
        public string RubricId { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public DateTime DatePrefered { get; set; }

        [DataMember]
        public int FacilityId { get; set; } 

        [DataMember]
        public string FinaltialEntityId { get; set; }

        [DataMember]
        public string FinaltialEntityDescr { get; set; }

        /// <summary>
        /// Tipo de acto médico - Consulta ou Exame.
        /// </summary>
        [DataMember]
        public MedicalActType ActMedType { get; set; }

        [DataMember]
        public string OfficeCode { get; set; }

        [DataMember]
        public string OfficeDescription { get; set; }

        [DataMember]
        public string Observations { get; set; }

        [DataMember]
        public AppRequestedStatus Status { get; set; }
        public string Status_Code { get; set; }
        public string StatusCTH_Code { get; set; }

        public static AppRequestedStatus ConvertAppRequestedStatus(string statusCode)
        {

            switch (statusCode)
            {
                case "E":
                    return AppRequestedStatus.Refused;

                case "M":
                    return AppRequestedStatus.Scheduled;

                case "P":
                    return AppRequestedStatus.Pendent;

                default:
                    return AppRequestedStatus.Pendent;
            }
        }
    }

    [DataContract]
    public enum AppRequestedStatus
    {
        [EnumMember]
        Scheduled,

        [EnumMember]
        Refused,

        [EnumMember]
        Pendent,
    }

}
