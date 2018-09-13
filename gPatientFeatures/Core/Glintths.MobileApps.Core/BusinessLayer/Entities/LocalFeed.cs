using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    public class LocalFeed
    {
        public bool CashIn { get; set; }
        public string Code { get; set; }
        public bool IsSuplement { get; set; }
        public string Name { get; set; }
        public string Observation { get; set; }
        public double Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
