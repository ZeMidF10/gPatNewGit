using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    public class LocalMealCategory
    {
        public string Description { get; set; }
        public List<LocalFeed> Feeds { get; set; }
        public string Observation { get; set; }
    }
}
