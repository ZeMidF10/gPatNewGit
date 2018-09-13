using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class LocalQuestion
    {
        [DataMember]
        public string CodQuestion { get; set; }

        [DataMember]
        public string DescrQuestion { get; set; }

        [DataMember]
        public int Sort { get; set; }

        [DataMember]
        public string Answer { get; set; }

        [DataMember]
        public LocalQuestionType QuestionType { get; set; }

        [DataMember]
        public string DefaultValue { get; set; }

    }
}
