using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.Apps.Themes
{
    public partial class ThemeResolver
    {
        private static volatile ThemeResolver instance;
        private static object syncRoot = new Object();
        public UnityContainer Container { get; set; }

        private ThemeResolver()
        {
        }

        public static ThemeResolver Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new ThemeResolver();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
