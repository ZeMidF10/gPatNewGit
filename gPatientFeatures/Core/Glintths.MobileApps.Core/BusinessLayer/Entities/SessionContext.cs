using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class SessionContext
    {

        [DataMember]
        public string CompanyId { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string Culture { get; set; }
        [DataMember]
        public string Group { get; set; }
        [DataMember]
        public string MachineName { get; set; }
        [DataMember]
        public TimeSpan? OperationTimeout { get; set; }
        [DataMember]
        public string SessionId { get; set; }
        [DataMember]
        public string UserName { get; set; }
    }
}
