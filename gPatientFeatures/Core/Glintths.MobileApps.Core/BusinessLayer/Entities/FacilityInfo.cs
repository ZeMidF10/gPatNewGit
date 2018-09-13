
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
	[DataContract]
	public class FacilityInfo
	{
		[DataMember]
		public string FacilityInfoId { get; set; }

		[DataMember]
		public string FacilityId { get; set; }

		[DataMember]
		public List<FacilityInfoContext> FacilityInfoContexts { get; set; }
	}

	[DataContract]
	public class FacilityInfoContext
	{
		[DataMember]
		public int FacilityInfoContextId { get; set; }

		[DataMember]
		public int FacilityId { get; set; }

		[DataMember]
		public string Context { get; set; }

		[DataMember]
		public string Title { get; set; }

		[DataMember]
		public string URLLogoSmall { get; set; }

		[DataMember]
		public string URLLogoBig { get; set; }

        

        [DataMember]
		public List<FacilityContextDetail> FacilityInfoContextDetail { get; set; }
	}

	[DataContract]
	public class FacilityContextDetail
	{
		[DataMember]
		public int FacilityInfoContextDetailId { get; set; }

		[DataMember]
		public int FacilityInfoContextId { get; set; }

		[DataMember]
		public string Context { get; set; }

        [DataMember]
        public string SubContext { get; set; }

        [DataMember]
		public string Title { get; set; }

		[DataMember]
		public string Text { get; set; }

		[DataMember]
		public string URLLogoSmall { get; set; }

		[DataMember]
		public string URLLogoBig { get; set; }

        [DataMember]
        public string InfoURLLogoSmall { get; set; }

        [DataMember]
        public string InfoURLLogoBig { get; set; }

        [DataMember]
        public int FacilityInfoContextFacilityId { get; set; }
    }
}