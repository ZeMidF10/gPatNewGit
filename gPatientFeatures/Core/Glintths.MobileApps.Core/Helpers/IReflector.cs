using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.Helpers
{
	public interface IReflector
	{
		Object CreateInstanceFrom(string assemblyName, string typeName);
	}
}
