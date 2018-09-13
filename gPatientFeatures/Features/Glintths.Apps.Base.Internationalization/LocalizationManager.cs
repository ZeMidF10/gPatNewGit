using Glintths.Apps.Base.Internationalization;
using Glintths.Apps.Base.Internationalization.Interfaces;
using Glintths.Apps.Base.Internationalization.Resx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(LocalizationManager))]
namespace Glintths.Apps.Base.Internationalization
{

    public class LocalizationManager : ILocalizationManager
    {
        public static void Init()
        {

            if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android)
            {
                // determine the correct, supported .NET culture
                var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                Resx.AppResources.Culture = ci; // set the RESX for resource localization
                DependencyService.Get<ILocalize>().SetLocale(ci); // set the Thread for locale-aware methods
            }
        }

        public string GetLocalizedString(string stringName)
        {
            return AppResources.ResourceManager.GetString(stringName, AppResources.Culture);
        }
    }
}
