
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
	public class Facility
	{
		public const string DeepPropertyLocation = "Location";

		[DataMember]
		public int FacilityId { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public string Phone { get; set; }

		[DataMember]
		public string Address { get; set; }

        [DataMember]
        public string Ordem { get; set; }

		[DataMember]
		public string Photo { get; set; }

		[DataMember]
		public GeoCoordinate GeoCoordinates { get; set; }

        [DataMember]
        public string Type { get; set; }

		/// <summary>
		/// Agrupador de Unidades Hospitalares
		/// </summary>
		//[DataMember, OneToOne]
		//public FacilityLocation Location { get; set; }

		[DataMember]
		public bool Visible { get; set; }

		/*[DataMember]
        public long SCN { get; set; }*/

		public override bool Equals(object obj)
		{
			// If parameter is null return false.
			if (obj == null)
			{
				return false;
			}

			// If parameter cannot be cast return false.
			Facility other = obj as Facility;
			if ((System.Object)other == null)
			{
				return false;
			}

			int thisFacility = FacilityId;
			int otherFacility = other.FacilityId;
			return thisFacility == otherFacility;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public List<FacilityInfo> FacilityInfos { get; set; }

        public List<FacilityParams> FacilityParams { get; set; }
	}
}