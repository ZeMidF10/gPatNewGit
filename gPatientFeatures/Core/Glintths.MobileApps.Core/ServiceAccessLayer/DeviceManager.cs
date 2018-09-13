using Glintths.MobileApps.Core.BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.ServiceAccessLayer
{

    //Interface do Serviço para as pushnotifications
    //void RegisterForPushNotification(
    //string deviceid,
    //string userid,
    //string deviceos,
    //string devicemodel,
    //string deviceversion,
    //string appname,
    //string appversion);


    public interface IDevice
    {
        string GetDeviceID();
        string GetDeviceOS();
        string GetDeviceModel();
        string GetDeviceVersion();
        string GetLanguage();

        void ShowKeyboard();
        void HideKeyboard();
        void SetDeviceId(string registrationId);
    }

    public class DeviceManager
    {
        private static DeviceManager _instance;
        private IDevice _device;

        public string DeviceIDPushNotif { get; set; }

        public DeviceInfo DeviceInfo
        {
            get {
                return new DeviceInfo()
                {
                    AppName = Configuration.Instance.Configurations["APP_NAME"],
                    AppVersion = Configuration.Instance.Configurations["APP_VERSION"],
                    DeviceId = DeviceIDPushNotif,
                    DeviceModel = Device.GetDeviceModel(),
                    DeviceOS = Device.GetDeviceOS(),
                    DeviceVersion = Device.GetDeviceVersion(),
                    Language = Device.GetLanguage()
                };
            }
        }

        public IDevice Device
        {
            get { return _device; }
            set { _device = value; }
        }

        protected DeviceManager() { }

        public static DeviceManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DeviceManager();
                }
                return _instance;
            }
        }

    }
}
