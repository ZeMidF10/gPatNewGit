using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    public class LocalDiet
    {
        public string Code { get; set; }
        public List<LocalMealCategory> MealCategories { get; set; }
        public string Name { get; set; }
    }
}
