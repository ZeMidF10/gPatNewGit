using Glintths.Apps.Base.Internationalization.Resx;
using Glintths.MobileApps.Core.BusinessLayer.Entities;
using Glintths.MobileApps.Core.ServiceAccessLayer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.GPlatform.ServiceGPAccessLayer
{
    public partial class GPService
    {

        public async Task<ServiceReturn<List<HumanResource>>> GetHumanResourceAsync(AuthenticationType tipoAuth, List<int> facilityIds, int? speciality = null, int? medicalAct = null, int? financialEntity = null, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.GetMedicsListError);

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            List<HumanResource> listRes = null;

            try
            {
                string baseMuleUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_MULE_URL");
                Generated.Mulesoft.GETClient sc = new Generated.Mulesoft.GETClient(baseMuleUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));

                var ret = await sc.OfferStaffAsync(facilityIds, speciality , medicalAct, financialEntity, "", 0, 10000);

                if (ret != null)
                {
                    listRes = new List<HumanResource>();
                    foreach (var item in ret)
                    {
                        listRes.Add(TranslateHumanResourceGPToLocal(item));
                    }
                }

                return ServiceReturnHandling.BuildSuccessCallReturn<List<HumanResource>>(listRes, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<List<HumanResource>>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<List<HumanResource>>> GetHumanResourceByIdsAsync(AuthenticationType tipoAuth, List<int> providerIDs, int skip, int take, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
            {
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            }
            else
            {
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.GetMedicsListError);
            }

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            List<HumanResource> listRes = null;
            try
            {
                string baseMuleUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_MULE_URL");
                Generated.Mulesoft.GETClient sc = new Generated.Mulesoft.GETClient(baseMuleUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));

                var ret = await sc.StaffAsync(providerIDs, null, null, skip, take);

                if (ret != null)
                {
                    listRes = new List<HumanResource>();
                    foreach (var item in ret)
                    {
                        listRes.Add(TranslateHumanResourceGPToLocal(item));
                    }
                }
                return ServiceReturnHandling.BuildSuccessCallReturn<List<HumanResource>>(listRes, uiMessages);

            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<List<HumanResource>>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<string>> GetHumanResourceCvAsync(AuthenticationType tipoAuth, int humanResourceID, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.GetMedicInfoError);

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            string result = string.Empty;

            try
            {
                string baseMuleUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_MULE_URL");
                Generated.Mulesoft.GETClient sc = new Generated.Mulesoft.GETClient(baseMuleUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));

                var ret = (await sc.StaffIdCvAsync(humanResourceID));

                if (ret != null)
                    result = ret.Data;

                return ServiceReturnHandling.BuildSuccessCallReturn<string>(result, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<string>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<List<string>>> GetHumanResourceFacilitiesAsync(AuthenticationType tipoAuth, string providerID, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.GetFacilitiesError);

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            List<string> facilitiesIds = new List<string>();

            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.HumanResourceClient sc = new Generated.HumanResourceClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));

                ObservableCollection<double> listFilter = new ObservableCollection<double>();
                listFilter.Add(double.Parse(providerID));
                var ret = await sc.GetByIdsAsync(listFilter, GetGPAppVersion());

                if (ret != null)
                    foreach (var item in ret)
                        if (item.FacilityId.HasValue)
                            facilitiesIds.Add(item.FacilityId.Value.ToString());

                return ServiceReturnHandling.BuildSuccessCallReturn<List<string>>(facilitiesIds, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<List<string>>(ex, uiMessages);
            }
        }

        public BusinessLayer.Entities.HumanResource TranslateHumanResourceGPToLocal(Generated.Mulesoft.Staff humGP)
        {

            try
            {
                if (humGP != null)
                {
                    HumanResource humLocal = new HumanResource()
                    {
                        Name = humGP.Name,
                        PersonnelNumber = humGP.Personal_number,
                        ProfessionalNumberId = humGP.Professional_number,
                        Title = humGP.Title,
                        HumanResourceId = humGP.Id,
                    };
                    return humLocal;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro a realizar o convert de HumanResourceCore (GP) para HumanResource (local)");
            }
            return null;
        }

    }
}
