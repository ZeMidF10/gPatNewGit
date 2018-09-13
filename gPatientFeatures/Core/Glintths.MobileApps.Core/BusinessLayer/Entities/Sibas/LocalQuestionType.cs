using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class LocalQuestionType
    {
        [DataMember]
        public string CodType { get; set; }

        [DataMember]
        public bool ValidateAnswer { get; set; }

        [DataMember]
        public bool ResctritedAnswer { get; set; }

    }
}
