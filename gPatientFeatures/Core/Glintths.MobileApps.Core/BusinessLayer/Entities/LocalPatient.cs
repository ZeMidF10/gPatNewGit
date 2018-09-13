using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class LocalPatient
    {
        /*
        public const string DeepPropertyInteractions = "ENFPANEL_INTERACAO";
        public const string DeepPropertyNursingDadosAdicDet = "ENFPANEL_DADOS_ADIC_DET";
        public const string DeepPropertyNursingMCDT = "ENFPANEL_MCDT";
        public const string DeepPropertyNursingMCDTGrupos = "ENFPANEL_MCDT.ENFPANEL_MCDT_GRUPOS";
        public const string DeepPropertyNursingPlanoOper = "ENFPANEL_PLANOOPER";
        public const string DeepPropertyNursingRegOper = "ENFPANEL_REGOPER";
        public const string DeepPropertyNursingService = "SERVICE";
        public const string InternmentBed = "INTERNMENT_BED";
        public const string InternmentDate = "INTERNMENT_DATE";
        public const string InternmentPatientPreferredName = "INTERNMENT_PATIENT_PREFERRED_NAME";
        public const string InternmentResponsableNurse = "INTERNMENT_RESPONSABLE_NURSE";
        public const string InternmentRoom = "INTERNMENT_ROOM";
        public const string InternmentService = "INTERNMENT_SERVICE";
        */

        [DataMember]
        public List<EnfGeneralParameter> Alerts { get; set; }
        [DataMember]
        public List<EnfGeneralParameter> Allergies { get; set; }
        [DataMember]
        public List<EnfGeneralParameter> Background { get; set; }
        [DataMember]
        public LocalBed Bed { get; set; }
        [DataMember]
        public DateTime? Birthdate { get; set; }
        [DataMember]
        public string DiagnosticReason { get; set; }
        [DataMember]
        public LocalDiet Diet { get; set; }
        [DataMember]
        public DateTime? DtIntern { get; set; }
        [DataMember]
        public string EpisodeId { get; set; }
        [DataMember]
        public string EpisodeType { get; set; }

        [DataMember]
        public string EpisodeTime { get; set; }

        [DataMember]
        public DateTime? ExpectedDischargeDate { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public List<Interaction> Interactions { get; set; }
        [DataMember]
        public string InternReason { get; set; }
        [DataMember]
        public Kit Kit { get; set; }
        [DataMember]
        public List<RequestItem> Mcdts { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Nursery { get; set; }
        [DataMember]
        public string Observations { get; set; }
        [DataMember]
        public string Origin { get; set; }
        [DataMember]
        public List<LocalSurgery> PlanOpers { get; set; }
        [DataMember]
        public string PreferredName { get; set; }
        [DataMember]
        public List<LocalSurgery> RegOpers { get; set; }
        [DataMember]
        public string ResponsibleDoctor { get; set; }
        [DataMember]
        public string ResponsibleDoctorName { get; set; }
        [DataMember]
        public string ResponsibleNurse { get; set; }
        [DataMember]
        public string ResponsibleNurseName { get; set; }
        [DataMember]
        public List<EnfGeneralParameter> Risks { get; set; }
        [DataMember]
        public string Room { get; set; }
        [DataMember]
        public LocalClinicalService Service { get; set; }
        [DataMember]
        public List<EnfGeneralParameter> SpecialTreatments { get; set; }
        [DataMember]
        public string Transfer { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string UniqueId { get; set; }

        [DataMember]
        public string Photo { get; set; }
    }
}
