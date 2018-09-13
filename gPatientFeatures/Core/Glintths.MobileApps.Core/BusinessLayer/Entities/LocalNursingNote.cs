using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class LocalNursingNote
    {
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string LocalEpisodId { get; set; }
        [DataMember]
        public string LocalEpisodType { get; set; }
        [DataMember]
        public string LocalPatientId { get; set; }
        [DataMember]
        public string LocalPatientType { get; set; }
        [DataMember]
        public DateTime NoteDate { get; set; }
        //
        // Summary:
        //     User que criou a nota
        [DataMember]
        public string User { get; set; }
    }
}
