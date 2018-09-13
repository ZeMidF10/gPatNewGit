using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    // Summary:
    //     PH_ARMAZENS?? Para já só para ficar a classe dos lotes com a referência correcta
    [DataContract]
    public class Warehouse
    {
        // Summary:
        //     Desccrição do armazem
        [DataMember]
        public string WarehouseDescription { get; set; }
        //
        // Summary:
        //     Id do armazem
        [DataMember]
        public string WarehouseId { get; set; }
    }
}
