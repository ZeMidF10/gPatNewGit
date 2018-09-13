using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    public class LocalSurgeryServ
    {
        /*
        public const string DeepPropertyNurseOfficeList = "NurseOfficeList";
        */

        public string Description { get; set; }
        public bool IsDefault { get; set; }
        public string LocalSurgeryServiceCode { get; set; }
        public List<LocalNurseOffice> NurseOfficeList { get; set; }
    }
}
