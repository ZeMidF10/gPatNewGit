using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    public class RequestItem
    {
        public string ExamCode { get; set; }
        public string ExamDescription { get; set; }
        public string ExamStatus { get; set; }
        public DateTime? RequestDate { get; set; }
        public string RequestId { get; set; }
        public decimal RequestItemId { get; set; }
        public string RubricCode { get; set; }
        public string TrackingGroupCode { get; set; }
        public string TrackingGroupDescription { get; set; }
        public decimal TrackingGroupId { get; set; }
        public string TrackingIcon { get; set; }
        public decimal? TrackingPriority { get; set; }
    }
}
