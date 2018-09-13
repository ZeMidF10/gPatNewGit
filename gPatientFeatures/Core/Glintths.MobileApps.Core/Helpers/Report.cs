using Glintths.MobileApps.Core.Helpers.Reporting;
using System;

namespace Glintths.MobileApps.Core.Helpers
{
	public sealed class Reporter
	{
		private static Reporter _instance;
		private IReport _courier;

		public static IReport Instance(IReport imp = null)
		{
			_instance = _instance ?? new Reporter(imp);
			return _instance._courier;
		}

		private Reporter(IReport imp)
		{
			if (imp == null) throw new ArgumentNullException("Argument has to be non null the first time.");
			_isInitialized = true;
			_courier = imp;
		}

		private static bool _isInitialized;

		public static bool IsInitialized
		{
			get
			{
				return _isInitialized;
			}
			private set { _isInitialized = value; }
		}
	}
}