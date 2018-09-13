using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    public class LocalEpisode : LocalEpisodeData
    {
        public string Description { get; set; }
        public DateTime? DtAct { get; set; }
        public DateTime? DtCri { get; set; }
        public string FlagStatus { get; set; }
        public string Key { get; set; }
        public string NOrder { get; set; }
        public string ParentKey { get; set; }
        public string UserAct { get; set; }
        public string UserCri { get; set; }
    }
}
