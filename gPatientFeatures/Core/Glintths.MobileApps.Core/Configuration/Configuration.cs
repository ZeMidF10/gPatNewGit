using Glintths.Apps.Base.Internationalization.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace Glintths.MobileApps.Core
{
    /// <summary>
    /// Instanciação das configurações!
    /// Estas encontram-se definidas na classe da (PCL) gPatientFeatures.ConfigurationProvider
    /// </summary>
    /// 
    public class Configuration
    {
        public Dictionary<string, string> Configurations;

        private static Configuration _instance;
        private static string _filename;

        private Configuration()
        {
            Configurations = new Dictionary<string, string>();
        }

        public static Configuration Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                _instance = new Configuration();
                _instance.Init();
                return _instance;
            }
            //set 
            //{ 
            //    _instance = value; 
            //}
        }

        public void Init()
        {
            Configurations = DependencyService.Get<IConfigurationsProvider>().GetConfigurations();
        }

        /// <summary>
        /// This method is used to prevent crashes without enough information to fix
        /// </summary>
        /// <param name="confCode"></param>
        /// <returns></returns>
        public string GetConfig(string confCode)
        {
            try
            {
                if (Configurations.Count == 0)
                    Configurations = DependencyService.Get<IConfigurationsProvider>().GetConfigurations();

                return Configurations[confCode];
            }
            catch (Exception e)
            {
                Debug.WriteLine("Erro a consultar variavel de configuracoes:" + confCode);
                throw new Exception(e.Message + " => " + confCode);
            }
        }

        public static bool IsSet()
        {
            return _instance != null;
        }
    }
}

