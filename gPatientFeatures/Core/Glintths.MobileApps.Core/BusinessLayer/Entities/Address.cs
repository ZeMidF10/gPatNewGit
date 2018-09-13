using System.Runtime.Serialization;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
	[DataContract]
	public class Address
	{
		[DataMember]
		public string StreetName { get; set; } //ex. rua xpto

		[DataMember]
		public string Number { get; set; }

		[DataMember]
		public string Local { get; set; }

		[DataMember]
		public string City { get; set; }

		[DataMember]
		public string PostalCode { get; set; }

		[DataMember]
		public string Country { get; set; }

		[DataMember]
		public string AddressType { get; set; } //tipo de logradouro
	}
}