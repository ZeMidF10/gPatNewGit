using System;
using System.Runtime.Serialization;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
	[DataContract]
	public class FreeTimeSlot
	{
		/// <summary>
		/// Id da vaga
		/// </summary>
		[DataMember]
		public string Id { get; set; }

		/// <summary>
		/// Início da vaga
		/// </summary>
		[DataMember]
		public DateTime Begin { get; set; }

		/// <summary>
		/// Fim da vaga
		/// </summary>
		[DataMember]
		public DateTime End { get; set; }

        public DateTime Duration { get; set; }

        /// <summary>
        /// Id médico central
        /// </summary>
        [DataMember]
		public int HumanResourceId { get; set; } //medico

        /// <summary>
        /// Id do serviço
        /// </summary>
        [DataMember]
        public string ClinicalServiceId { get; set; }

        /// <summary>
        /// Código do acto médico
        /// </summary>
        [DataMember]
        public string MedicalActCode { get; set; }

        /// <summary>
        /// Agrupador de Unidades Hospitalares
        /// </summary>
        [DataMember]
        public string Group { get; set; }

        /// <summary>
        /// Id da instituição
        /// </summary>
        [DataMember]
        public int FacilityId { get; set; }

        /// <summary>
        /// Nº mecanográfico (médico)
        /// </summary>
        [DataMember]
        public string PersonnelNumber { get; set; } //medico

        /// <summary>
        /// Código da EFR
        /// </summary>
        [DataMember]
        public int FinancialEntityCode { get; set; }

        /// <summary>
        /// Id da agenda
        /// </summary>
        [DataMember]
        public string ScheduleId { get; set; }

        /// <summary>
        /// Id do gabinete
        /// </summary>
        [DataMember]
        public string CabinetId { get; set; }

        /// <summary>
        /// Flag que indica se é primeira consulta ou subsequente
        /// </summary>
        [DataMember]
        public bool FirstTimeFlag { get; set; }

        [DataMember]
        public string Observations { get; set; }

    }

}