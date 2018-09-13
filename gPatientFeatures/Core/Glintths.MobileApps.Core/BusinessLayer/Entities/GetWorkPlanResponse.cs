using System.Collections.Generic;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
	public class GetWorkPlanResponse
	{
		public string IdGen { get; set; }

		public List<LocalTask> TaskList { get; set; }
	}
}