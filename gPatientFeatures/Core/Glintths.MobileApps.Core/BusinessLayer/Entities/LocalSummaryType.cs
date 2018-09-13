using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class LocalSummaryType
    {
        /// <summary>
        /// Idendificador do tipo de resumo
        /// </summary>
        [DataMember]
        public string SummaryTypeId { get; set; }

        /// <summary>
        /// Código do tipo de resumo
        /// </summary>
        [DataMember]
        public string SummaryTypeCode { get; set; }

        /// <summary>
        /// Descriçaõ do tipo de resumo
        /// </summary>
        [DataMember]
        public string SummaryTypeDescription { get; set; }

    }
}
