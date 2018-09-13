using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class LocalQuest
    {
        [DataMember]
        public string CodInscription { get; set; }

        [DataMember]
        public string CompanyId { get; set; }

        [DataMember]
        public DateTime RequestDate { get; set; }

        [DataMember]
        public string CodInterval { get; set; }

        [DataMember]
        public bool CanAnswerQuest { get; set; }

        [DataMember]
        public List<LocalQuestion> Questions { get; set; }

    }
}
