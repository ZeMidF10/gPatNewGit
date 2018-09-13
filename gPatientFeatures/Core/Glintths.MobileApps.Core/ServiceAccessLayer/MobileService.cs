using System;
using Xamarin.Forms;

namespace Glintths.MobileApps.Core.ServiceAccessLayer
{

	
	public partial class MobileService
	{
		public const string MESSAGING_ERROR = "ERROR";
        public const string MESSAGING_INFO = "INFO";
        public const string OPSUCCESS = "OPSUCCESS";
        public const string MESSAGING_AUX = "AUX";
        public const string SELECT_TAB = "SELECT_TAB";

		//public enum ServiceResponseType
		//{
		//    ERROR,
		//    SUCCESS
		//}

		private static volatile MobileService instance;
		private static object syncRoot = new Object();

        private MobileService() {

		}

		public static MobileService Instance
		{
			get
			{
				if(instance == null)
				{
					lock (syncRoot) {
						if (instance == null) {
							instance = new MobileService ();
						}
					}
				}
				return instance;
			}
		}
		
	}
}

