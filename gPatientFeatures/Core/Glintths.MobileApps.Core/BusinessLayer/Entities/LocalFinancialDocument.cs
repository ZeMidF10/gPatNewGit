using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class LocalFinancialDocument
    {
        [DataMember]
        public decimal AmountPendingPayment { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string DocNumber { get; set; }
        [DataMember]
        public string DocumentStatus { get; set; }
        //
        // Summary:
        //     Id da instituição
        [DataMember]
        public int FacilityId { get; set; }
        //
        // Summary:
        //     Id da Documento
        [DataMember]
        public string IdDocument { get; set; }
        [DataMember]
        public string IdPatient { get; set; }
        [DataMember]
        public DateTime LastUpdateDate { get; set; }
        
        [DataMember]
        public PaymentReference PaymentData { get; set; }
        
        [DataMember]
        public string SCN { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public decimal Value { get; set; }
    }

    [DataContract]
    public class PaymentReference
    {

        // Summary:
        //     Montante do pagamento por multibanco
        [DataMember]
        public decimal Amount { get; set; }
        //
        // Summary:
        //     Entidade do pagamento por multibanco
        [DataMember]
        public string EntityCode { get; set; }
        //
        // Summary:
        //     Referência do pagamento por multibanco
        [DataMember]
        public string Reference { get; set; }
    }
}
