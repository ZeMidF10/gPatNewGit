using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class LocalFaqs
    {
        [DataMember]
        public string Answer;
        [DataMember]
        public string CodFaq;
        [DataMember]
        public int Order;
        [DataMember]
        public string Question;

    }
}
