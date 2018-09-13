using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
	[DataContract]
	public class FinancialEntity
	{
		[DataMember]
		public int FinancialEntityId { get; set; }

		[DataMember]
		public string FinancialEntityCode { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public COEntityStatus Status { get; set; }

        [DataMember]
        public string Format1 { get; set; }

        [DataMember]
        public string Format2 { get; set; }

        [DataMember]
        public bool CardMandatoryFlag { get; set; }
    
        [DataMember]
        public bool ExpDateMandatoryFlag { get; set; }

        //[DataMember]
        //public bool Visible { get; set; }
        /*[DataMember]
		public long SCN { get; set; }*/

        [DataMember]
		public List<LocalFinancialEntity> LocalFinancialEntities { get; set; }

		public const string DeepPropertyLocalFinancialEntities = "LocalFinancialEntities";
	}


	[DataContract]
	public class LocalFinancialEntity
	{
		/// <summary>
		/// Agrupador de Unidades Hospitalares
		/// </summary>
		[DataMember]
		public string Group { get; set; }

		[DataMember]
		public int FacilityId { get; set; }

		[DataMember]
		public string FinancialEntityCode { get; set; } //CodEFR, primary key da entidade

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public LocalEntityStatus EntityStatus { get; set; }

		[DataMember]
		public RelationshipEntityStatus RelationshipStatus { get; set; }
	}
}