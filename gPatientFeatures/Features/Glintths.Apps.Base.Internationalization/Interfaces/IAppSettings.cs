using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.Apps.Base.Internationalization.Interfaces
{
    public enum AppVersionStatus { Latest, OutDated,Unknown }

    public interface IAppSettings
    {
        Dictionary<string, string> GetSettings();
    }
    public interface IAppVersionChecker
    {
        Task<string> GetAppStoreAppVersion();
        Task<AppVersionStatus> IsAppUpToDate();
        void OpenAppStorePage();
    }
}
