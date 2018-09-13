using System.Runtime.Serialization;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
	[DataContract]
	public class DeviceInfo
	{
		[DataMember]
		public string DeviceId { get; set; }

		[DataMember]
		public string UserId { get; set; }

		[DataMember]
		public string DeviceOS { get; set; }

		[DataMember]
		public string DeviceModel { get; set; }

		[DataMember]
		public string DeviceVersion { get; set; }

		[DataMember]
		public string AppName { get; set; }

		[DataMember]
		public string AppVersion { get; set; }

        [DataMember]
        public string Language { get; set; }
	}
}