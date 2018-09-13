using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    
    public class Invoice
    {
        [DataMember]
        public string OperationResult { get; set; }

        [DataMember]
        public string URL { get; set; }

    }

    public class PaymentHistory
    {
        [DataMember]
        public string OperationId { get; set; }


        /// <summary>
        /// Historico do pagamento
        /// </summary>
        [DataMember]
        public FinancialOperation[] history { get; set; }
    }

    public class FinancialOperation
    {
        public enum OpStatus
        {
            SUCCESS,
            FAIL,
            PENDING,
            REJECTED,
        }

        public enum IntentType
        {
            PAYMENT,
            AUTHORIZATION,
            REFUND,
        }

        [DataMember]
        public DateTime OpDate { get; set; }

        /// <summary>
        /// Estado atual da operação
        /// </summary>
        [DataMember]
        public OpStatus Status { get; set; }

        /// <summary>
        /// Tipo de operação
        /// </summary>
        [DataMember]
        public IntentType Intent { get; set; }

        /// <summary>
        /// Valor da operação
        /// </summary>
        [DataMember]
        public decimal Value { get; set; }
    }
}
