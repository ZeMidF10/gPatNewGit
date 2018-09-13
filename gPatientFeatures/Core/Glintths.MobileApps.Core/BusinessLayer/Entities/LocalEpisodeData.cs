using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    public class LocalEpisodeData
    {
        public string EpisDescr { get; set; }
        public DateTime? EpisEndDate { get; set; }
        public string EpisodeId { get; set; }
        public string EpisodeType { get; set; }
        public DateTime? EpisStartDate { get; set; }
        public string LocalPatientId { get; set; }
        public string LocalPatientType { get; set; }
        public string ParentEpisodeId { get; set; }
        public string ParentEpisodeType { get; set; }
        public string UniquePatientId { get; set; }
    }
}
