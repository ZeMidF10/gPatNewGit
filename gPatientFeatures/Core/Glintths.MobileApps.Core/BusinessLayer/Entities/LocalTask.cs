using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class LocalTask
    {

        [DataMember]
        public DateTime BeginDate { get; set; }
        [DataMember]
        public bool BeginDateHasValue { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime DueDate { get; set; }
        [DataMember]
        public bool DueDateHasValue { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public bool EndDateHasValue { get; set; }
        [DataMember]
        public LocalEpisodeData Episode { get; set; }
        [DataMember]
        public LocalPatientData Patient { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string TaskId { get; set; }
        [DataMember]
        public string TaskTypeCode { get; set; }
    }
}
