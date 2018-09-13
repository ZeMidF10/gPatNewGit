using System.Runtime.Serialization;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
	[DataContract]
	public class ClinicalService
	{
		/// <summary>
		/// Agrupador de Unidades Hospitalares
		/// </summary>
		[DataMember]
		public string Group { get; set; }

		[DataMember]
		public string FacilityId { get; set; }

		[DataMember]
		public string ServiceId { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public string ServiceType { get; set; }

		[DataMember]
		public LocalEntityStatus EntityStatus { get; set; }

		[DataMember]
		public RelationshipEntityStatus RelationshipStatus { get; set; }
	}
}