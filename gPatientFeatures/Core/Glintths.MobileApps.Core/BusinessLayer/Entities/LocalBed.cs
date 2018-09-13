using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    public class LocalBed
    {
        public string BedId { get; set; }
        public DateTime? BeginDate { get; set; }
        public string CodServ { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }
        public string Room { get; set; }
        public string User { get; set; }
        public string Ward { get; set; }
    }
}
