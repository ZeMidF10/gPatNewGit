using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    /// <summary>
    /// Representa um recurso central
    /// DeepProperties suportadas: LocalHumanResources; Specialties
    /// </summary>
    [DataContract]
    public class HumanResource
    {
        public const string DeepPropertyLocalHumanResources = "LocalHumanResources";
        public const string DeepPropertySpecialties = "Specialties";
        public const string DeepPropertiesKeywords = "Keywords";

        /// <summary>
        /// Agrupador de Unidades Hospitalares
        /// </summary>
        [DataMember]
        public string Group { get; set; }

        /*[DataMember]
        public List<string> Facility { get; set; }*/

        //lista de Instituições às quais este Prestador está associado.
        /*[DataMember]
        List<Facility> Facilities { get; set; } */

        ///<Summary>
        /// Lista de médicos locais associados a este médico corporativo
        ///</Summary>
        [DataMember]
        public List<LocalHumanResource> LocalHumanResources { get; set; }

        /// <summary>
        /// Id do recurso
        /// </summary>
        [DataMember]
        public int HumanResourceId { get; set; }

        /// <summary>
        /// Título
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Nome Abreviado
        /// </summary>
        [DataMember]
        public string ShortName { get; set; }

        /// <summary>
        /// Tipo de Recurso
        /// </summary>
        [DataMember]
        public string HumanResourceType { get; set; }

        /// <summary>
        /// Subtipo de Recurso
        /// </summary>
        [DataMember]
        public string HumanResourceSubType { get; set; }

        [DataMember]
        public List<Specialty> Specialties { get; set; }

        /// <summary>
        /// Número de telefone
        /// </summary>
        [DataMember]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public List<string> School { get; set; }

        /// <summary>
        /// Número de cédula profissional
        /// </summary>
        [DataMember]
        public string ProfessionalNumberId { get; set; } //NCedProf

        /// <summary>
        /// Número Mecanográfico central
        /// </summary>
        [DataMember]
        public string PersonnelNumber { get; set; } //NMecan

        /// <summary>
        /// Número de Identificação Fiscal
        /// </summary>
        [DataMember]
        public string TaxIdNumber { get; set; } //NIF

        /// <summary>
        /// Morada
        /// </summary>
        [DataMember]
        public Address Address { get; set; }

        [DataMember]
        public COEntityStatus Status { get; set; }

        /// <summary>
        /// Visivel no portal
        /// </summary>
        [DataMember]
        public bool Visible { get; set; }

        [DataMember]
        public List<SpecialtyMO> SpecialtiesMO { get; set; }

        /// <summary>
        /// Lista de palavras-chave associadas
        /// </summary>
        [DataMember]
        public List<Keyword> Keywords { get; set; }


        [DataMember]
        public string PhotoUri { get; set; }

    }

	[DataContract]
	public class LocalHumanResource
	{
		/// <summary>
		/// Agrupador de Unidades Hospitalares
		/// </summary>
		[DataMember]
		public string Group { get; set; }

		[DataMember]
		public Facility Facility { get; set; }

		/*[DataMember]
		public string HumanResourceId { get; set; }*/

		[DataMember]
		public string Title { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public string ShortName { get; set; }

		[DataMember]
		public string HumanResourceType { get; set; }

		[DataMember]
		public string HumanResourceSubType { get; set; }

		[DataMember]
		public List<Specialty> Specialties { get; set; }

		[DataMember]
		public string PhoneNumber { get; set; }

		[DataMember]
		public string Email { get; set; }

		[DataMember]
		public List<string> School { get; set; }

		[DataMember]
		public string ProfessionalNumberId { get; set; } //NCedProf

		[DataMember]
		public string PersonnelNumber { get; set; } //NMecan

		[DataMember]
		public string TaxIdNumber { get; set; } //NIF

		[DataMember]
		public Address Address { get; set; }

		[DataMember]
		public LocalEntityStatus EntityStatus { get; set; }

		[DataMember]
		public RelationshipEntityStatus RelationshipStatus { get; set; }

		[DataMember]
		public List<SpecialtyMO> SpecialtiesMO { get; set; }
	}
}