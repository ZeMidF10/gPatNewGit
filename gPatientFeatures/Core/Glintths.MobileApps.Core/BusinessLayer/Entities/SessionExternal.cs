using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class SessionExternal
    {
        [DataMember]
        public bool IsAuthenticated { get; set; }
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public UserType UserType { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string EncryptedAccessTokenSecret { get; set; }
        [DataMember]
        public DateTime ExpiringDate { get; set; }
        [DataMember]
        public string SecurityId { get; set; }
    }

    [DataContract]
    public class LoginFromDeviceResult
    {
        [DataMember]
        public SessionExternal Session { get; set; }
    }
}
