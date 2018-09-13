using Glintths.Apps.Base.Internationalization.Resx;
using Glintths.MobileApps.Core.BusinessLayer.Entities;
using Glintths.MobileApps.Core.ServiceAccessLayer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.GPlatform.ServiceGPAccessLayer
{
    public partial class GPService
    {
        public async Task<ServiceReturn<List<Notification>>> NotificationsByUserTypeAsync(AuthenticationType tipoAuth, string userId, string successMessage = "", string errorMessage = "")
        {
           
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.FailGetNotificationsList);

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            List<Notification> notifications = null;

            try {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.NotificationsClient sc = new Generated.NotificationsClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                var retTemp = await sc.NotificationsByUserTypeAsync(null, Generated.UserType4.Patient, userId, 0, 1000, GetGPAppVersion());

                if (retTemp != null)
                {
                    notifications = new List<Notification>();
                    foreach (var item in retTemp)
                    {
                        notifications.Add(TranslateNotificationsGPToLocal(item));
                    }
                }
               
                return ServiceReturnHandling.BuildSuccessCallReturn<List<Notification>>(notifications, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<List<Notification>>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<bool>> SetNotificationReadStatusAsync(AuthenticationType tipoAuth,Notification notification, bool markAsRead, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.FailGetNotificationsList);

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            bool success;

            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.NotificationsClient sc = new Generated.NotificationsClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                success = await sc.SetNotificationReadStatusAsync(notification.IdNotification, markAsRead, GetGPAppVersion());

                return ServiceReturnHandling.BuildSuccessCallReturn<bool>(success, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<bool>(ex, uiMessages);
            }
        }

        private Notification TranslateNotificationsGPToLocal(Generated.Notification notifGP)
        {
            Notification notifLocal = new Notification();
            try
            {
                if (notifGP != null)
                {
                    notifLocal.Context = notifGP.Context;
                    notifLocal.Date = notifGP.Date.HasValue ? notifGP.Date.Value : DateTime.Now;
                    notifLocal.DateString = notifGP.Date.ToString();
                    notifLocal.ExpiringDate = notifGP.ExpiringDate.HasValue ? notifGP.ExpiringDate.Value : DateTime.Now.AddDays(7);
                    notifLocal.FacilityId = notifGP.FacilityId;
                    notifLocal.IdNotification = notifGP.IdNotification;
                    notifLocal.MarkedAsRead = notifGP.MarkedAsRead.HasValue ? notifGP.MarkedAsRead.Value : false;
                    notifLocal.PatientUniqueId = notifGP.PatientUniqueId;
                    notifLocal.SCN = notifGP.SCN;
                    notifLocal.Status = notifGP.Status;
                    notifLocal.TextContent = notifGP.TextContent;
                    notifLocal.TimeString = notifGP.Date.ToString();
                    notifLocal.Title = notifGP.Title;
                    notifLocal.Url = notifGP.Url;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro a realizar o convert de Notification (GP) para Notification (local)");
            }

            return notifLocal;
        }


    }
}
