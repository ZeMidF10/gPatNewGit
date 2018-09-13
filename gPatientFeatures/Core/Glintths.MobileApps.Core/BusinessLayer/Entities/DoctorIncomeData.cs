using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class DoctorIncomeData
    {
        [DataMember]
        public DateTime MaxDate { get; set; }
        [DataMember]
        public DateTime MinDate { get; set; }
    }
}
