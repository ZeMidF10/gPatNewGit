using System;
using System.Runtime.Serialization;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
	[DataContract]
	public class AppointmentKey
	{
		/// <summary>
		/// FacilityId
		/// </summary>
		[DataMember]
		public int FacilityId { get; set; } //FacilityId

		/// <summary>
		/// Id
		/// </summary>
		[DataMember]
		public int Id { get; set; } //Id
	}

	/// <summary>
	/// Marcação
	/// </summary>
	[DataContract]
	public class Appointment
	{
		public const string IdAppointment = "IDAPPOINTMENT";
		public const string IdFacility = "IDFACILITY";
		public const string IdSpeciality = "IDSPECIALITY";
		public const string IdHumanRec = "IDHUMANREC";
		public const string IdMedicalAct = "IDMEDICALACT";
		public const string IdRubric = "IDRUBRIC";
		public const string IdPatient = "IDPATIENT";
		public const string AppointmentDate = "DATE";

		/// <summary>
		/// Id da especialidade médica
		/// </summary>
		[DataMember]
		public int SpecialityId { get; set; }

		/// <summary>
		/// Id do recurso (médico)
		/// </summary>
		[DataMember]
		public int HumanResourceId { get; set; } //medico

		/// <summary>
		/// Id do acto médico
		/// </summary>
		[DataMember]
		public int MedicalActId { get; set; }

		/// <summary>
		/// Id da rubrica
		/// </summary>
		[DataMember]
		public string RubricId { get; set; }

		/// <summary>
		/// Descrição da especialidade médica
		/// </summary>
		[DataMember]
		public string SpecialityDescription { get; set; }

		[DataMember]
		public string HumanResourceTitle { get; set; }

		/// <summary>
		/// Descrição do recurso (médico)
		/// </summary>
		[DataMember]
		public string HumanResourceDescription { get; set; } //nome do médico

		/// <summary>
		/// Descrição do acto médico
		/// </summary>
		[DataMember]
		public string MedicalActDescription { get; set; }

		/// <summary>
		/// Descrição da rubrica
		/// </summary>
		[DataMember]
		public string RubricDescription { get; set; }

		/*[DataMember]
		public string FinancialEntityId { get; set; }*/

		/// <summary>
		/// Data da marcação
		/// </summary>
		[DataMember]
		public DateTime Date { get; set; }

		/// <summary>
		/// TDoente
		/// </summary>
		[DataMember]
		public string LocalPatientType { get; set; } //t_doente

		/// <summary>
		/// Doente
		/// </summary>
		[DataMember]
		public string LocalPatientId { get; set; } //doente

		/// <summary>
		/// FacilityId
		/// </summary>
		[DataMember]
		public int FacilityId { get; set; } //FacilityId

		/// <summary>
		/// Group
		/// </summary>
		[DataMember]
		public string Group { get; set; } //Group

		/// <summary>
		/// Id
		/// </summary>
		[DataMember]
		public int Id { get; set; } //Id

		/// <summary>
		/// Nome do Doente
		/// </summary>
		[DataMember]
		public string PatientName { get; set; }

		/// <summary>
		/// Entidade Financeira Responsável
		/// </summary>
		[DataMember]
		public FinancialEntity FinaltialEntity { get; set; }

		/// <summary>
		/// Fim da Consulta
		/// </summary>
		[DataMember]
		public DateTime EndDate { get; set; }

		/// <summary>
		/// Estado da marcação
		/// </summary>
		[DataMember]
		public AppointmentStatus Status { get; set; }

		/// <summary>
		/// Flag que indica se é extra
		/// </summary>
		[DataMember]
		public bool? IsExtra { get; set; }

		/// <summary>
		/// Flag que indica se é primeira consulta ou subsequente
		/// </summary>
		[DataMember]
		public bool FirstTimeFlag { get; set; }

		/// <summary>
		/// Tipo de acto médico - Consulta ou Exame.
		/// </summary>
		[DataMember]
		public MedicalActType ActMedType { get; set; }

		/// <summary>
		/// Código do Gabinete
		/// </summary>
		[DataMember]
		public string OfficeCode { get; set; }

		/// <summary>
		/// Descrição do Gabinete
		/// </summary>
		[DataMember]
		public string OfficeDescription { get; set; }

		public static AppointmentStatus ConvertLocalAppointmentStatus(string status)
		{
			//if (string.IsNullOrEmpty(status))
			//	throw new InvalidOperationException("ConvertLocalAppointmentStatus: estado inválido - não pode ser null");

			switch (status)
			{
				case "MC":
					return AppointmentStatus.Scheduled;

				case "P":
					return AppointmentStatus.PatientPresent;

				case "E":
					return AppointmentStatus.Ongoing;

				case "EF":
					return AppointmentStatus.Performed;

				case "OK":
					return AppointmentStatus.Done;

				case "FM":
					return AppointmentStatus.DoctorAbsent;

				case "F":
					return AppointmentStatus.PatientAbsent;

				case "R":
					return AppointmentStatus.Rescheduled;

				case "C":
					return AppointmentStatus.Canceled;

				case "NR":
					return AppointmentStatus.NotPerformed;

				case "A":
					return AppointmentStatus.Nullified;

				default:
                    return AppointmentStatus.Nullified;
                    //throw new InvalidOperationException("ConvertLocalAppointmentStatus: estado inválido - " + status);
			}

			throw new InvalidOperationException("ConvertLocalAppointmentStatus: estado inválido - " + status);
		}
	}

	[DataContract]
	public enum AppointmentStatus
	{
		[EnumMember]
		Scheduled, //MC - Marcada

		[EnumMember]
		PatientPresent,  //P - Presente

		[EnumMember]
		Ongoing,  //E - Em Curso

		[EnumMember]
		Performed,  //EF - Efectuada

		[EnumMember]
		Done,  //ou Paied //OK - Realizada

		[EnumMember]
		DoctorAbsent, //FM - Falta Médico

		[EnumMember]
		PatientAbsent, //F - Falta Doente

		[EnumMember]
		Rescheduled, //R- Remarcada

		[EnumMember]
		Canceled, //C - Cancelada

		[EnumMember]
		NotPerformed, //NR - Não Realizada

		[EnumMember]
		Nullified //A - Anulada
	}
}