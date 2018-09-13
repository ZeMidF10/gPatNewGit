using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Glintths.MobileApps.Core.GPlatform.ServiceGPAccessLayer
{
    public partial class GPService
    {
        public const string MESSAGING_ERROR = "ERROR";
        public const string MESSAGING_INFO = "INFO";
        public const string OPSUCCESS = "OPSUCCESS";
        public const string MESSAGING_AUX = "AUX";
        public const string SELECT_TAB = "SELECT_TAB";

        private static volatile GPService instance;
        private static object syncRoot = new Object();

        public enum AuthenticationType
        {
            AnonymousAuthentication, UserAuthentication
        }

        private GPService()
        {
        }

        public static GPService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new GPService();
                    }
                }

                return instance;
            }
        }

        public static string GetGPAppVersion()
        {
            return Configuration.Instance.Configurations["GP_APP_VERSION"];
        }


        /// <summary>
        /// ATENÇÃO ESTA EXCEPTION/FORMATO APENAS SE VERIFICA NOS ERROS HTTP 400
        /// </summary>
        public class GPlatformClientException
        {
            public string Code { get; set; }
            public string Description { get; set; }
            public string Detail { get; set; }
        }
    }
}
