using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
	[DataContract]
	public class ResultDocument
	{
		[DataMember]
		public string IdDocument { get; set; }

		[DataMember]
		public string FacilityId { get; set; }
        [DataMember]
        public string PatientId { get; set; }

        [DataMember]
		public List<EpisodeData> Episodes { get; set; }
		[DataMember]
		public string OriginId { get; set; }
		[DataMember]
		public string OriginDescription { get; set; }
		[DataMember]
		public string TypeId { get; set; }
		[DataMember]
		public string TypeDescription { get; set; }
		[DataMember]
		public string MimeType { get; set; }
		[DataMember]
		public string FileName { get; set; }
		[DataMember]
		public string SCN { get; set; }
		[DataMember]
		public string IdPatient { get; set; }
		[DataMember]
		public bool Restrict { get; set; }
        [DataMember]
        public bool HasImage { get; set; }
        [DataMember]
		public string UrlFile { get; set; }
        [DataMember]
        public DateTime DocumentDate { get; set; }

        [DataMember]
        public DateTime DocumentDateUTC { get { return DocumentDate.ToUniversalTime(); } }

        [DataMember]
        public string CentralType { get; set; }


	}

	[DataContract]
	public class ResultDocumentFile
	{
		[DataMember]
        public string IdDocument { get; set; }
		[DataMember]
		public byte[] File { get; set; }
        [DataMember]
        public string MimeType { get; set; }
	}

}

