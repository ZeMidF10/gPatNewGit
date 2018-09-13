using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    /// <summary>
    /// Representa uma palavra-chave
    /// </summary>
    [DataContract]
    public class Keyword
    {
        /// <summary>
        /// Id da palavra-chave
        /// </summary>
        [DataMember]
        public string KeywordId { get; set; }

        /// <summary>
        /// Descrição
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Flag que indica se está ativa
        /// </summary>
        [DataMember]
        public bool ActiveFlag { get; set; }
    }
}
