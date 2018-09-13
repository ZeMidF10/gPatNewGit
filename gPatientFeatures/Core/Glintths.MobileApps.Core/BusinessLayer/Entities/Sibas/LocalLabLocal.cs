using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities.Sibas
{
    [DataContract]
    public class LocalLabLocal
    {
        [DataMember]
        public string CodLocal { get; set; }

        [DataMember]
        public string DescLocal { get; set; }

        [DataMember]
        public string EmpresaId { get; set; }

        [DataMember]
        public bool FlagDadiva { get; set; }

        [DataMember]
        public List<LocalContactValueKey> KeysList;
    }
}
