using Glintths.MobileApps.Core.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.ServiceAccessLayer
{
    public class FormsMediaPicker
    {
        private static FormsMediaPicker _instance;
        private IFormsMediaPicker _mediaPicker;


        public IFormsMediaPicker MediaPicker
        {
            get { return _mediaPicker; }
            set { _mediaPicker = value; }
        }


        protected FormsMediaPicker()
        {
        }

        public static FormsMediaPicker Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FormsMediaPicker();
                }
                return _instance;
            }
        }
    }


}
