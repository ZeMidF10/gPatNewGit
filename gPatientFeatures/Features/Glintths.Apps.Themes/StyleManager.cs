using Glintths.Apps.Base.Interfaces;
using Glintths.Apps.Themes.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.Apps.Themes
{
    public class StyleManager
    {
        private static volatile StyleManager instance;
        private static object syncRoot = new Object();

        public IAppStyle Style;

        private StyleManager()
        {
            this.Style = new StyleBase();
        }

        public static StyleManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new StyleManager();
                        }
                    }
                }
                return instance;
            }
        }


    }
}
