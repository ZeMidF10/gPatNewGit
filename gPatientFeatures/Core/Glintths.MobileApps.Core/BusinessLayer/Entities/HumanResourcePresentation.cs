using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    /// <summary>
    /// Apresentação do Recurso Humano
    /// </summary>
    [DataContract]
    public class HumanResourcePresentation
    {
        [DataMember]
        public string HumanResourceId { get; set; }

        [DataMember]
        public string HumanResourceCVHtml { get; set; }

        [DataMember]
        public List<Facility> WorkingPlaces { get; set; }

        [DataMember]
        public List<FinancialEntity> Efrs { get; set; }

    }
}
