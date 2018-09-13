using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.ServiceAccessLayer
{
    public class ServiceReturn<T>
    {
        public T Result { get; set; }

        public bool Success { get; set; }

        public string UIMessage { get; set; }

        public string ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public Exception CallException { get; set; }
    }
}
