using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class LocalNursingTaskDetail
    {
        // Summary:
        //     M_ADM_QT_ADM
        [DataMember]
        public decimal? AdministeredQtd { get; set; }
        //
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
        public DateTime? DataHora { get; set; }
        //
        // Summary:
        //     DESCRICAO
        [DataMember]
        public string Descricao { get; set; }
        //
        // Summary:
        //     DESCR_PADRAO_CALEND
        [DataMember]
        public string DescrPadraoCalend { get; set; }
        //
        // Summary:
        //     M_ADM_FRACCIONAVEL
        [DataMember]
        public string DivisibleAdm { get; set; }
        //
        // Summary:
        //     DOENTE
        [DataMember]
        public string Doente { get; set; }
        //
        // Summary:
        //     LOTES
        [DataMember]
        public List<DrugBatch> DrugBatchList { get; set; }
        //
        // Summary:
        //     COD_ITEM
        [DataMember]
        public string DrugId { get; set; }
        //
        // Summary:
        //     TRANSFERENCIAS
        [DataMember]
        public List<DrugTransference> DrugTransferences { get; set; }
        //
        // Summary:
        //     EPISODIO
        [DataMember]
        public string Episodio { get; set; }
        //
        // Summary:
        //     ESTADO
        [DataMember]
        public string Estado { get; set; }
        //
        // Summary:
        //     Codigo da justificação
        [DataMember]
        public string ExecCodJustificacao { get; set; }
        //
        // Summary:
        //     Descriçaõ da justificação
        [DataMember]
        public string ExecDescrJustificacao { get; set; }
        //
        // Summary:
        //     ID_EXECUCAO
        [DataMember]
        public decimal? ExecutionId { get; set; }
        //
        // Summary:
        //     M_ADM_FLAG_PRIM_TOMA
        [DataMember]
        public string FirstTake { get; set; }
        //
        // Summary:
        //     FREQUENCIA
        [DataMember]
        public string Frequencia { get; set; }
        //
        // Summary:
        //     Medicaçaõ em atraso
        [DataMember]
        public bool HasPrescriptionDelay { get; set; }
        //
        // Summary:
        //     ID
        [DataMember]
        public decimal Id { get; set; }
        //
        // Summary:
        //     ID_GEN
        [DataMember]
        public decimal? IdGen { get; set; }
        //
        // Summary:
        //     Data de internamento
        [DataMember]
        public DateTime? InternmentDate { get; set; }
        //
        // Summary:
        //     I_IRREGULAR
        [DataMember]
        public string Irregular { get; set; }
        //
        // Summary:
        //     M_PREPARACAO_VALIDADA
        [DataMember]
        public string IsPreparationValidated { get; set; }
        //
        // Summary:
        //     É SOS
        [DataMember]
        public short? IsSOSMedication { get; set; }
        //
        // Summary:
        //     TIPO LINHA
        [DataMember]
        public string LineType { get; set; }
        //
        // Summary:
        //     OBSERVACAO_PLANEAMENTO
        [DataMember]
        public string ObservacaoPlaneamento { get; set; }
        //
        // Summary:
        //     OBSERVACOES
        [DataMember]
        public string Observacoes { get; set; }
        //
        // Summary:
        //     Idade
        [DataMember]
        public string PatientAge { get; set; }
        //
        // Summary:
        //     Data de Nasc
        [DataMember]
        public DateTime? PatientBirthdate { get; set; }
        //
        // Summary:
        //     ID_PLANEAMENTO
        [DataMember]
        public decimal? PlanningId { get; set; }
        //
        // Summary:
        //     D_QT_PREP
        [DataMember]
        public decimal? PrepAmount { get; set; }
        //
        // Summary:
        //     PREPARACAO_ID
        [DataMember]
        public decimal? PreparationId { get; set; }
        //
        // Summary:
        //     D_QT_FORN_PREP
        [DataMember]
        public decimal? PrepFornAmount { get; set; }
        //
        // Summary:
        //     M_PRESC_VIA_ADM
        [DataMember]
        public string PrescribedAdmChannel { get; set; }
        //
        // Summary:
        //     M_PRESQ_QUANTIDADE
        [DataMember]
        public decimal? PrescribedAmount { get; set; }
        //
        // Summary:
        //     M_PRESC_DOSE
        [DataMember]
        public decimal? PrescribedDose { get; set; }
        //
        // Summary:
        //     M_PRESC_UNID_DOSE
        [DataMember]
        public string PrescribedDoseUnity { get; set; }
        //
        // Summary:
        //     M_PRESC_TIPO_MD
        [DataMember]
        public string PrescribedUnity { get; set; }
        //
        // Summary:
        //     TIPO DE PRESCRICAO:
        [DataMember]
        public string PrescriptionType { get; set; }
        //
        // Summary:
        //     M_ADM_QT_FORN
        [DataMember]
        public decimal? ProvidedQtd { get; set; }
        //
        // Summary:
        //     Data de internamento
        [DataMember]
        public string ResponsibleDoctorName { get; set; }
        //
        // Summary:
        //     ENF_RESP
        [DataMember]
        public string ResponsibleNurseUserName { get; set; }
        //
        // Summary:
        //     CAMA
        [DataMember]
        public string Room { get; set; }
        //
        // Summary:
        //     I_QDR_ESPEC
        [DataMember]
        public string SpecificContext { get; set; }
        //
        // Summary:
        //     DT_INICIO
        [DataMember]
        public DateTime? StartDate { get; set; }
        //
        // Summary:
        //     T_DOENTE
        [DataMember]
        public string TDoente { get; set; }
        //
        // Summary:
        //     T_EPISODIO
        [DataMember]
        public string TEpisodio { get; set; }
        //
        // Summary:
        //     VALOR
        [DataMember]
        public string Value { get; set; }
        //
        // Summary:
        //     M_ADM_ARMAZEM
        [DataMember]
        public string WareHouse { get; set; }
        //
        // Summary:
        //     D_ARMAZEM_PREP
        [DataMember]
        public string WareHousePrep { get; set; }
    }
}
