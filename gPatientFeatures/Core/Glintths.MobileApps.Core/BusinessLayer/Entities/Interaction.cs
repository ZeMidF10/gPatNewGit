using System;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
	public class Interaction
	{
		public DateTime? Date { get; set; }

		public LocalHumanResource HumanResource { get; set; }

		public string Observation { get; set; }
	}
}