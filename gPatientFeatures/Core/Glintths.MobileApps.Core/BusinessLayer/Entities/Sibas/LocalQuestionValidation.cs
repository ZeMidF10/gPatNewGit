using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public enum TypeMessage
    {
        [EnumMember]
        Ok,
        [EnumMember]
        Warnings,
        [EnumMember]
        Errors,
        [EnumMember]
        WarningAndErrors
    }

    [DataContract]
    public class LocalQuestionValidation
    {
        [DataMember]
        public string CodInscription { get; set; }

        [DataMember]
        public TypeMessage MessageType { get; set; }

        [DataMember]
        public string Message { get; set; }

    }
}
