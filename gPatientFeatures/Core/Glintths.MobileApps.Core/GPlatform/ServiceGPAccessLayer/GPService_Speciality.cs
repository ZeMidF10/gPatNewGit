using Glintths.Apps.Base.Internationalization.Resx;
using Glintths.MobileApps.Core.BusinessLayer.Entities;
using Glintths.MobileApps.Core.ServiceAccessLayer;
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
        public async Task<ServiceReturn<List<Specialty>>> GetSpecialtiesByIdsAsync(AuthenticationType tipoAuth, List<int> specialitiesIds, List<int> facilitiesIds, int skip, int take, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
            {
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            }
            else
            {
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.GetSpecialtyError);
            }

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            List<Specialty> ret = null;
            try
            {
                string baseMuleUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_MULE_URL");
                Generated.Mulesoft.GETClient sc = new Generated.Mulesoft.GETClient(baseMuleUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));

                //ObservableCollection<Generated.ExternalFilterSpeciality> listFilter = new ObservableCollection<Generated.ExternalFilterSpeciality>();
                //foreach (var item in specialitiesIds)
                //{
                //    Generated.ExternalFilterSpeciality filter = new Generated.ExternalFilterSpeciality()
                //    {
                //        Id = item
                //    };
                //    listFilter.Add(filter);
                //}

                var retTemp = await sc.SpecialitiesAsync(specialitiesIds, facilitiesIds, null, skip, take);

                if (retTemp != null)
                {
                    ret = new List<Specialty>();
                    foreach (var item in retTemp)
                        ret.Add(TranslateSpecialty2GPToLocal(item));
                }

                return ServiceReturnHandling.BuildSuccessCallReturn<List<Specialty>>(ret, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<List<Specialty>>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<List<Specialty>>> GetSpecialtiesAsync(AuthenticationType tipoAuth,List<int> facilityIds, int? financialEntity = null, int? humanResourceId = null, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.GetSpecialtiesError);

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            List<Specialty> ret = null;

            try
            {
                string baseMuleUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_MULE_URL");
                Generated.Mulesoft.GETClient sc = new Generated.Mulesoft.GETClient(baseMuleUrl,  await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                //Generated.SpecialityBaseFilter extFilter = new Generated.SpecialityBaseFilter();
                //extFilter.ListFacilityIds = new ObservableCollection<double>(facilityIds.Select(x => double.Parse(x)).ToList());

                var retTemp = await sc.OfferSpecialitiesAsync(facilityIds, humanResourceId, financialEntity, null, 0, 10000);

                if (retTemp != null)
                {
                    ret = new List<Specialty>();
                    foreach (var item in retTemp)
                        ret.Add(TranslateSpecialty2GPToLocal(item));
                }

                return ServiceReturnHandling.BuildSuccessCallReturn<List<Specialty>>(ret, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<List<Specialty>>(ex, uiMessages);
            }
        }

        private BusinessLayer.Entities.Specialty TranslateSpecialty2GPToLocal(Generated.Mulesoft.Speciality specGP)
        {
            
            try
            {
                if (specGP != null)
                {
                    Specialty specLocal = new Specialty()
                    {
                        Description = specGP.Description,
                        SpecialtyCode = specGP.Code,
                        SpecialtyId = specGP.Id,
                    };

                    return specLocal;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro a realizar o convert de Specialty2 (GP) para Specialty (local)");
            }

            return null;
        }


    }
}
