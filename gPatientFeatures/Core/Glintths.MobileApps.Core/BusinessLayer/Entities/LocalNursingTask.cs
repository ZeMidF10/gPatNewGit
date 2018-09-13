using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class LocalNursingTask
    {
        // Summary:
        //     CAMA
        [DataMember]
        public string Bed { get; set; }
        //
        // Summary:
        //     COD_SERV
        [DataMember]
        public string CodServ { get; set; }
        //
        // Summary:
        //     DATA_HORA
        [DataMember]
        public DateTime? DateHour { get; set; }
        //
        // Summary:
        //     ID
        [DataMember]
        public decimal Id { get; set; }
        //
        // Summary:
        //     ID_EPISODIO
        [DataMember]
        public string LocalEpisodeId { get; set; }
        //
        // Summary:
        //     TIPO_EPISODIO
        [DataMember]
        public string LocalEpisodeType { get; set; }
        //
        // Summary:
        //     ID_DOENTE
        [DataMember]
        public string LocalPatientId { get; set; }
        //
        // Summary:
        //     Nome do doente
        [DataMember]
        public string LocalPatientName { get; set; }
        //
        // Summary:
        //     TIPO_DOENTE
        [DataMember]
        public string LocalPatientType { get; set; }
        //
        // Summary:
        //     NUMERO_TASKS
        [DataMember]
        public decimal? NTasks { get; set; }
        //
        // Summary:
        //     TIPO_PRESCRICAO
        [DataMember]
        public string PrescriptionType { get; set; }
        //
        // Summary:
        //     LISTA_DETALHES
        [DataMember]
        public string ResponsibleNurseUserSys { get; set; }
        //
        // Summary:
        //     SALA
        [DataMember]
        public string Room { get; set; }
        //
        // Summary:
        //     LISTA_DETALHES
        [DataMember]
        public List<LocalNursingTaskDetail> TaskDetails { get; set; }
        //
        // Summary:
        //     ENFERMARIA
        [DataMember]
        public string Ward { get; set; }
    }
}
