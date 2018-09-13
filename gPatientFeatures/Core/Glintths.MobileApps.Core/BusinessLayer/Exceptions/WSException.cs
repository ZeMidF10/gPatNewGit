using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Exceptions
{
    public class WSException : Exception
    {
        public WSException(string message)
            : base(message)
        {
        }
        public WSException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public WSException()
            : base("Could not download data")
        {
        }
    }

    public class ExceptionData
    {
        private string _errorMsg;
        public string ErrorMsg
        {
            get {
                return _errorMsg;
            }

            set
            {
                _errorMsg = value;
            }
        }
    }
}
