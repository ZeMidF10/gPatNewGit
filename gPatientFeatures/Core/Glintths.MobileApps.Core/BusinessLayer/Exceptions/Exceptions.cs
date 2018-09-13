using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.BusinessLayer.Exceptions
{
    public class NoTranslationAvailableException : Exception
    {
        public NoTranslationAvailableException(string message)
            : base(message)
        {
        }

        public NoTranslationAvailableException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public NoTranslationAvailableException()
            : base("No translation is available")
        {
        }
    }


    public class EFRException : Exception
    {
        public EFRException() : base() { }
        public EFRException(string message) : base(message) { }
    }

    public class BookAppointmentException : Exception
    {
        public BookAppointmentException() : base() { }
        public BookAppointmentException(string message) : base(message) { }
    }
}
