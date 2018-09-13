using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class AppointmentCheckOutResult
    {

        [DataMember]
        public string TicketNumber { get; set; } //Ticket Number

        [DataMember]
        public string GoTo { get; set; } //Gabinete

    }
}
