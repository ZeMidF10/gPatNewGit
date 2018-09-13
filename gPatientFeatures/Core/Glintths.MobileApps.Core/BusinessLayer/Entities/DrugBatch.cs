using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    // Summary:
    //     PH_MED_LOTE
    [DataContract]
    public class DrugBatch
    {
        // Summary:
        //     QT_DISPONIVEL
        [DataMember]
        public decimal? AvailableAmount { get; set; }
        //
        // Summary:
        //     LOTE_MED
        [DataMember]
        public string BatchDescr { get; set; }
        //
        // Summary:
        //     ID_LOTE
        [DataMember]
        public decimal BatchId { get; set; }
        //
        // Summary:
        //     QT_DISPONIVEL / FACTOR_CONV
        [DataMember]
        public decimal? ConvAvailableAmount { get; set; }
        //
        // Summary:
        //     MEDICAMENTO - Drug.Id
        [DataMember]
        public Drug Drug { get; set; }
        //
        // Summary:
        //     PRAZO_VAL se ExpirationDateHasValue for null
        [DataMember]
        public DateTime ExpirationDate { get; set; }
        //
        // Summary:
        //     PRAZO_VAL != null
        [DataMember]
        public bool ExpirationDateHasValue { get; set; }
        //
        // Summary:
        //     ARMAZEM - Warehouse.WarehouseId
        [DataMember]
        public Warehouse Warehouse { get; set; }
    }
}
