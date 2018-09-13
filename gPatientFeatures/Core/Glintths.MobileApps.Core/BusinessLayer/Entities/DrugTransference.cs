using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    // Summary:
    //     t_epre_servico_transferencia quantidade disponivel de medicamento por armazem
    //     e respectivo serviço associado
    [DataContract]
    public class DrugTransference
    {
        // Summary:
        //     QTD_PENDENTE
        [DataMember]
        public decimal AmountPending { get; set; }
        //
        // Summary:
        //     QTD_PEDIDA
        [DataMember]
        public decimal AmountRequested { get; set; }
        //
        // Summary:
        //     QTD_SATISFEITA
        [DataMember]
        public decimal AmountSatisfied { get; set; }
        //
        // Summary:
        //     DATA_ENTREGA
        [DataMember]
        public DateTime? DeliveryDate { get; set; }
        //
        // Summary:
        //     NUM_DOC
        [DataMember]
        public string DocNumber { get; set; }
        //
        // Summary:
        //     DATA_PEDIDO
        [DataMember]
        public DateTime? RequestDate { get; set; }
        //
        // Summary:
        //     NUM_PEDIDO
        [DataMember]
        public decimal? RequestNumber { get; set; }
        //
        // Summary:
        //     DATE
        [DataMember]
        public DateTime? TranferDate { get; set; }
        //
        // Summary:
        //     ESTADO_TRANSFERENCIA_DESCR
        [DataMember]
        public string TranferDescription { get; set; }
        //
        // Summary:
        //     ESTADO_TRANSFERENCIA
        [DataMember]
        public string TranferStatus { get; set; }
        //
        // Summary:
        //     UNID_MEDIDA
        [DataMember]
        public string Unity { get; set; }
        //
        // Summary:
        //     ARMAZEM
        [DataMember]
        public string Warehouse { get; set; }
        //
        // Summary:
        //     ARMAZEM_DESCR
        [DataMember]
        public string WarehouseDescription { get; set; }
        //
        // Summary:
        //     ARMAZEM_REQUISITANTE
        [DataMember]
        public string WarehouseRequester { get; set; }
        //
        // Summary:
        //     ARMAZEM_REQUISITANTE_DESCR
        [DataMember]
        public string WarehouseRequesterDescription { get; set; }
    }
}
