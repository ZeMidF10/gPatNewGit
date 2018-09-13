using System;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
	public class EnfGeneralParameter
	{
		public string Code { get; set; }

		public string Description { get; set; }

		public DateTime? EvaluationDate { get; set; }

		public DateTime? ExecutionDate { get; set; }

		public string Frequency { get; set; }

		public decimal Order { get; set; }

		public DateTime? PlacingDate { get; set; }

		public string Schedule { get; set; }

		public string SubType { get; set; }

		public string Type { get; set; }

		public string Warning { get; set; }
	}
}