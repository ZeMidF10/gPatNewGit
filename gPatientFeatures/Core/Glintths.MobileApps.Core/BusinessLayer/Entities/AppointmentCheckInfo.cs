using System;
using System.Runtime.Serialization;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
	[DataContract]
	public class AppointmentCheckInfo
	{
		/// <summary>
		/// Agrupador de Unidades Hospitalares
		/// </summary>
		[DataMember]
		public string Group { get; set; }

		/// <summary>
		/// Id da marcação
		/// </summary>
		[DataMember]
		public int AppointmentId { get; set; }

		/// <summary>
		/// Id da instituição
		/// </summary>
		[DataMember]
		public int FacilityId { get; set; }

		#region check-in

		/// <summary>
		/// Check-In Eligivel
		/// </summary>
		[DataMember]
		public bool CheckInAvailable { get; set; }

		/// <summary>
		/// formato do código de Check-In
		/// </summary>
		[DataMember]
		public CheckInCodeFormatEnum CheckInCodeFormat { get; set; }

		/// <summary>
		/// código de Check-In
		/// </summary>
		[DataMember]
		public byte[] CheckInCode { get; set; }

		/// <summary>
		/// Número de pessoas à frente
		/// </summary>
		[DataMember]
		public decimal NumberOfPatientsQueuingBefore { get; set; }

		/// <summary>
		/// Tempo de espera estimado até ser atendido
		/// </summary>
		[DataMember]
		public DateTime EstimatedDateTime { get; set; }

		/// <summary>
		/// Tempo de espera estimado até ser atendido
		/// </summary>
		[DataMember]
		public string Ticket { get; set; }

        /// <summary>
        /// Estado computado
        /// </summary>
        [DataMember]
        public string ComputedStatus { get; set; }

        /// <summary>
        /// Flag que indica se já foi realizado o checkout
        /// </summary>
        [DataMember]
        public bool IsCheckedOut { get; set; }

		#endregion check-in
	}

	[DataContract]
	public enum CheckInCodeFormatEnum
	{
		[EnumMember]
		String,

		[EnumMember]
		QRCode,

		[EnumMember]
		BarCode
	}
}