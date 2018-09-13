using System.Runtime.Serialization;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
	public class FacilityLocation
	{
		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public string Id { get; set; }
	}
}