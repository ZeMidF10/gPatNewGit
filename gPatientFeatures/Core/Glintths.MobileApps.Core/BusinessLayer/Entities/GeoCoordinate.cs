
using System;
using System.Runtime.Serialization;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
	public class GeoCoordinate
	{
		public const int EquatorRadius = 6371;
		public const double d2r = (Math.PI / 180.0);

		[DataMember]
		public double lat { get; set; }

		[DataMember]
		public double lon { get; set; }

		// ForeignKey
		[DataMember]
		public string FacilityId { get; set; }

		public string toString()
		{
			return lat + ", " + lon;
		}

		/// <summary>
		//    /// Calculates distance between two locations.
		//    /// </summary>
		//    /// <returns>The <see cref="System.Double"/>The distance in meters</returns>
		//    /// <param name="a">Location a</param>
		//    /// <param name="b">Location b</param>
		public static double DistanceBetween(GeoCoordinate from, GeoCoordinate to)
		{
			double e = (3.1415926538 * from.lat / 180);
			double f = (3.1415926538 * from.lon / 180);
			double g = (3.1415926538 * to.lat / 180);
			double h = (3.1415926538 * to.lon / 180);
			double i = (Math.Cos(e) * Math.Cos(g) * Math.Cos(f) * Math.Cos(h) + Math.Cos(e) * Math.Sin(f) * Math.Cos(g) * Math.Sin(h) + Math.Sin(e) * Math.Sin(g));
			double j = (Math.Acos(i));
			double k = (6371 * j);

			return k;
		}

		private static double ToRad(double degrees)
		{
			return degrees * Math.PI / 180;
		}
	}
}