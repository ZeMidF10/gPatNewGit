using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class ScheduledAppointment
    {
        /// <summary>
        /// Id da instituição
        /// </summary>
        [DataMember]
        public string Id { get; set; }
        /// <summary>
        /// Id da marcação
        /// </summary>
        [DataMember]
        public string FacilityId { get; set; }
        /// <summary>
        /// Lista de preparações
        /// </summary>
        [DataMember]
        public List<string> PreparationDocuments { get; set; }


    }
}
