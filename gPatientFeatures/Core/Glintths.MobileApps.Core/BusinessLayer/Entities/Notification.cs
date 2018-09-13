using Glintths.MobileApps.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class Notification
    {
        /// <summary>
        /// Id da Notificação
        /// </summary>
        [DataMember]
        public string IdNotification { get; set; }

        /// <summary>
        /// Id da instituição
        /// </summary>
        [DataMember]
        public string FacilityId { get; set; }

        [DataMember]
        public string PatientUniqueId { get; set; }

        [DataMember]
        public string Context { get; set; } //BILLING, AGENDA, MARKETING, RESULTS

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string TextContent { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        public string DateUp { get { return (Validators.ToTitleCase(Date.ToString("d MMM yyyy"))); } }

        public string DateString { get; set; }

        public string TimeString { get; set; }

        [DataMember]
        public DateTime ExpiringDate { get; set; }

        [DataMember]
        public string Status { get; set; } //C - CANCELED, V - VALID

        [DataMember]
        public bool MarkedAsRead { get; set; }

        [DataMember]
        public string SCN { get; set; }
    }
}
