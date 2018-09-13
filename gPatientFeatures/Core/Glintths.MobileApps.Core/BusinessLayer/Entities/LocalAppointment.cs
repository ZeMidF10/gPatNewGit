using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    public class LocalAppointment
    {
        // Summary:
        //     Tipo de acto médico - Consulta ou Exame.  Pode estar a NULL, pois as agendas
        //     normalmente não especificam o acto médico por slot, mas sim como restrições
        //     gerais para um período abrangendo vários slots.
        [DataMember]
        public MedicalActType ActMedType { get; set; }
        //
        // Summary:
        //     Hora da Consulta
        [DataMember]
        public DateTime? AppointmentHour { get; set; }
        //
        // Summary:
        //     Id da marcação
        [DataMember]
        public string AppointmentId { get; set; }
        [DataMember]
        public string AppointmentObservation { get; set; }
        //
        // Summary:
        //     Id do serviço
        [DataMember]
        public string ClinicalServiceId { get; set; }
        //
        // Summary:
        //     Nome do serviço
        [DataMember]
        public string ClinicalServiceName { get; set; }
        //
        // Summary:
        //     Agrupador de Unidades Hospitalares
        [DataMember]
        public DateTime? Date { get; set; }
        [DataMember]
        public DateTime? DtCri { get; set; }
        //
        // Summary:
        //     Duracao da Consulta
        [DataMember]
        public DateTime? DurationDate { get; set; }
        //
        // Summary:
        //     Fim da Consulta
        [DataMember]
        public DateTime EndDate { get; set; }
        //
        // Summary:
        //     Id da instituição
        [DataMember]
        public string FacilityId { get; set; }
        //
        // Summary:
        //     Flag que indica se é primeira consulta ou subsequente
        [DataMember]
        public bool FirstTimeFlag { get; set; }
        //
        // Summary:
        //     Agrupador de Unidades Hospitalares
        [DataMember]
        public string Group { get; set; }
        //
        // Summary:
        //     Flag que indica se é extra
        [DataMember]
        public bool? IsExtra { get; set; }
        //
        // Summary:
        //     Id da Efr local
        [DataMember]
        public int? LocalEfrId { get; set; }
        //
        // Summary:
        //     Doente
        [DataMember]
        public string LocalPatientId { get; set; }
        //
        // Summary:
        //     Nome do Doente
        [DataMember]
        public string LocalPatientName { get; set; }
        //
        // Summary:
        //     Nome abrevidao do Doente
        [DataMember]
        public string LocalPatientShortName { get; set; }

        /// <summary>
        /// Data de nascimento do doente
        /// </summary>
        [DataMember]
        public DateTime LocalPatientBirthDate { get; set; }

        //
        // Summary:
        //     TDoente
        [DataMember]
        public string LocalPatientType { get; set; }
        //
        // Summary:
        //     Código do acto médico
        [DataMember]
        public string MedicalActCode { get; set; }
        //
        // Summary:
        //     Descrição do acto médico
        [DataMember]
        public string MedicalActDescr { get; set; }
        //
        // Summary:
        //     Código do Gabinete
        [DataMember]
        public string OfficeCode { get; set; }
        //
        // Summary:
        //     Descrição do Gabinete
        [DataMember]
        public string OfficeDescription { get; set; }
        //
        // Summary:
        //     Nome do médico
        [DataMember]
        public string PersonnelName { get; set; }
        //
        // Summary:
        //     Nº mecanográfico (médico)
        [DataMember]
        public string PersonnelNumber { get; set; }
        //
        // Summary:
        //     Hora de Presença
        [DataMember]
        public DateTime? PresenceHour { get; set; }
        //
        // Summary:
        //     Código da rubrica
        [DataMember]
        public string RubricCode { get; set; }
        //
        // Summary:
        //     Id da agenda
        [DataMember]
        public string ScheduleId { get; set; }
        //
        // Summary:
        //     Estado da marcação
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string UserCri { get; set; }
    }
}
