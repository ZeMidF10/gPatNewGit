
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.Apps.Base.Internationalization.Interfaces
{
    public interface IConfigurationsProvider
    {
        Dictionary<string, string> GetConfigurations();
    }
}
