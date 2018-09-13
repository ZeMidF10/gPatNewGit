using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    public class FacilityParams
    {
        public const string IsCCVisible = "VISIVEL_CC";
        public const string Order = "ORDEM";

        // Summary:
        //     Identificador da Facility
        [DataMember]
        public string FacilityId { get; set; }
        //
        // Summary:
        //     Identificador Extreno da Facility
        [DataMember]
        public string FacilityIdExt { get; set; }
        //
        // Summary:
        //     Chave do parametro
        [DataMember]
        public string Key { get; set; }
        //
        // Summary:
        //     Valor do parametro
        [DataMember]
        public string Value { get; set; }
    }
}
