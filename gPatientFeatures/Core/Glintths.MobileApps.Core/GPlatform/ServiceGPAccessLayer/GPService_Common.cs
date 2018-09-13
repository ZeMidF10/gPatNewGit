using Glintths.MobileApps.Core.BusinessLayer.Entities;
using Glintths.Apps.Base.Internationalization.Resx;
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
        public async Task<ServiceReturn<List<FinancialEntity>>> GetFinancialEntitiesAsync(AuthenticationType tipoAuth, List<double> facilityIds, List<double> humanResourceId, string specialtyId, List<double> medicalActId, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.GetFinancialEntitiesError);

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            List<FinancialEntity> lstFinEnt = null;

            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.FinancialEntityClient sc = new Generated.FinancialEntityClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));

                var facilityIdsFinal = (facilityIds != null) ? facilityIds : new List<double>();
                var humanResourceIdFinal = (humanResourceId != null) ? humanResourceId : new List<double>();
                var specialtyIdFinal = (!string.IsNullOrEmpty(specialtyId)) ? specialtyId : string.Empty;
                var medicalActIdFinal = (medicalActId != null) ? medicalActId : new List<double>();
                //var rubricIdFinal = (!string.IsNullOrEmpty(rubricId)) ? rubricId : string.Empty;

                Generated.FinancialEntityBaseFilter filter = new Generated.FinancialEntityBaseFilter()
                {
                    ListFacilityIds = new ObservableCollection<double>(facilityIdsFinal),
                    ListHumanResource = new ObservableCollection<double>(humanResourceIdFinal),
                    ListMedicalActIds = new ObservableCollection<double>(medicalActIdFinal)
                };

                var retTemp = await sc.GetFinancialEntitiesBaseAsync(filter, specialtyIdFinal, "S", 0, 10000, GetGPAppVersion());

                if (retTemp != null)
                {
                    lstFinEnt = new List<FinancialEntity>();
                    foreach (var item in retTemp)
                    {
                        lstFinEnt.Add(TranslateFinancialEntityGPToLocal(item));
                    }
                }

                // Cacete.. o metodo seguinte valida para uma determinada facility se a EFR tem obrigatoriedade de enviar Cartao/dataExpCartao
                // Estes campos só são necessários em momentos de marcação/remarcação de consultas daí o if facilityIds.Count (nas marcações tenho sempre a facility definida no inicio)
                // Não é realizada quando existem mais facilities porque, apesar de raro, a mesma EFR numa inst pode obrigar e noutra não..e os dados seriam insconsistentes
                if (facilityIds != null && facilityIds.Count == 1 && lstFinEnt != null && lstFinEnt.Count > 0)
                {
                    try
                    {
                        lstFinEnt = (await GetFinancialEntitiesCardInformationForSpecificFAcAsync(tipoAuth, facilityIds[0].ToString(), lstFinEnt)).Result;
                    }
                    catch (Exception) { }
                }

                return ServiceReturnHandling.BuildSuccessCallReturn<List<FinancialEntity>>(lstFinEnt, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<List<FinancialEntity>>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<List<FinancialEntity>>> GetFinancialEntitiesByIdsAsync(AuthenticationType tipoAuth, List<string> efrIds, string skip, string take, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.GetFinancialEntitiesError);

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            List<FinancialEntity> lstFinEnt = null;

            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.FinancialEntityClient sc = new Generated.FinancialEntityClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                ObservableCollection<Generated.ExternalFilterFinancialEntity> listFilters = new ObservableCollection<Generated.ExternalFilterFinancialEntity>();
                foreach (var item in efrIds)
                {
                    Generated.ExternalFilterFinancialEntity filter = new Generated.ExternalFilterFinancialEntity()
                    {
                        Id = item,
                    };
                    listFilters.Add(filter);
                }

                var retTemp = await sc.SearchFinancialEntitiesAsync(string.Empty, listFilters, skip, take, GetGPAppVersion());

                if (retTemp != null)
                {
                    lstFinEnt = new List<FinancialEntity>();
                    foreach (var item in retTemp)
                    {
                        lstFinEnt.Add(TranslateFinancialEntityGPToLocal(item));
                    }
                }

                // Aqui deveria ser realizada uma nova chamada assincrona para complementar os objectos finantial entities com os campos  cardmandatory/expDatemandatory/cardFormats
                // como este método é apenas chamado num método que não irá utilizar estes campo não foi adicionada esta mesma rotina..
                // Posteriormente se estes campos forem necessário será necessário realizar refactor e obrigar este método a ter como input um dicionário com <idFacility,List<idsFinantialEnts>>
                // por forma a carregar corretamente os dados no 

                return ServiceReturnHandling.BuildSuccessCallReturn<List<FinancialEntity>>(lstFinEnt, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<List<FinancialEntity>>(ex, uiMessages);
            }
        }

        private async Task<ServiceReturn<List<FinancialEntity>>> GetFinancialEntitiesCardInformationForSpecificFAcAsync(AuthenticationType tipoAuth, string facilityId, List<FinancialEntity> finantialEnts, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
            {

            }
            uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.GetFinancialEntitiesError);

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.FinancialEntityClient sc = new Generated.FinancialEntityClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));

                var facilityIdFinal = (!string.IsNullOrEmpty(facilityId)) ? facilityId : string.Empty;
                var finatialEntIdsFinal = finantialEnts != null ? finantialEnts.Select(x => (double)x.FinancialEntityId).ToList() : new List<double>();

                var retTemp = await sc.FinancialEntitiesByCodeListAsync(finatialEntIdsFinal, facilityIdFinal, GetGPAppVersion());

                if (retTemp != null && retTemp.Count > 0)
                {
                    foreach (var efrMoreInfo in retTemp)
                    {
                        finantialEnts.Where(x => x.FinancialEntityId == efrMoreInfo.Id.Value).Select(s => { s.Format1 = efrMoreInfo.CardFormat1; s.Format2 = efrMoreInfo.CardFormat2; s.CardMandatoryFlag = efrMoreInfo.IsCardMandatory.Value; s.ExpDateMandatoryFlag = efrMoreInfo.IsExpirationDateMandatory.Value; return s; }).ToList();
                    }
                }

                return ServiceReturnHandling.BuildSuccessCallReturn<List<FinancialEntity>>(finantialEnts, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.BuildSuccessCallReturn<List<FinancialEntity>>(finantialEnts, uiMessages); // Retornar sempre sucesso..para devolver as efr mesmo sem a info de cartao e formatos
                //return ServiceReturnHandling.HandleException<List<FinancialEntity>>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<FinancialEntity>> GetDefaultFinancialEntityByUniquePatientIdAsync(AuthenticationType tipoAuth, string facilityID, string uniqueUserId, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.GetFinancialEntitiesError);

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            FinancialEntity efrId = null;

            try
            {
                string baseMuleUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_MULE_URL");
                Generated.Mulesoft.GETClient sc = new Generated.Mulesoft.GETClient(baseMuleUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));

                var retTemp = await sc.FinancialEntitiesDefaultAsync(facilityID, uniqueUserId);

                if (retTemp != null)
                {
                    efrId = TranslateDefaultFinancialEntityGPToLocal(retTemp);
                }

                return ServiceReturnHandling.BuildSuccessCallReturn<FinancialEntity>(efrId, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<FinancialEntity>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<List<Facility>>> GetFacilitiesFilteredByDoctorAsync(AuthenticationType tipoAuth, string medicID, int skip, int take, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.GetFacilitiesError);

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            List<Facility> facilities = null;

            Generated.FacilityBaseFilter humanR = new Generated.FacilityBaseFilter();
            humanR.ListHumanResources = new ObservableCollection<double>();
            humanR.ListHumanResources.Add(double.Parse(medicID));

            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.FacilityClient sc = new Generated.FacilityClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                var retTemp = await sc.GetFacilitiesBaseAsync(humanR, "", "", "", skip, take, GetGPAppVersion());

                if (retTemp != null)
                {
                    facilities = new List<Facility>();
                    foreach (var item in retTemp)
                        facilities.Add(TranslateFacilityDoctorGPToLocal(item));
                }

                return ServiceReturnHandling.BuildSuccessCallReturn<List<Facility>>(facilities, uiMessages);

            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<List<Facility>>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<List<Facility>>> GetFacilitiesAsync(AuthenticationType tipoAuth, int skip, int take, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.GetFacilitiesError);

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);


            List<double> locationIds = new List<double>(); //Enviar lista vazia
            List<Facility> facilities = null;

            try
            {
                string baseMuleUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_MULE_URL");
                Generated.Mulesoft.GETClient sc = new Generated.Mulesoft.GETClient(baseMuleUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));

                var retTemp = await sc.FacilitiesAsync(null, null, null, skip, take);

                if (retTemp != null)
                {
                    facilities = new List<Facility>();
                    foreach (var item in retTemp)
                        facilities.Add(TranslateFacilityGPToLocal(item));
                }

                return ServiceReturnHandling.BuildSuccessCallReturn<List<Facility>>(facilities, uiMessages);

            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<List<Facility>>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<List<FacilityInfoContext>>> GetFacilitiesInfoContextDetailAsync(AuthenticationType tipoAuth, int facilityId, int skip, int take, string successMessage = "", string errorMessage = "")
        {

            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.GetFacilitiesError);

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            List<FacilityInfoContext> facilitiesInfoDetails = null;

            try
            {
                string baseMuleUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_MULE_URL");
                Generated.Mulesoft.GETClient sc = new Generated.Mulesoft.GETClient(baseMuleUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                var retTemp = await sc.FacilitiesIdInfoAsync(skip, take, facilityId);

                if (retTemp != null)
                {
                    facilitiesInfoDetails = new List<FacilityInfoContext>();
                    var groupedByContext = retTemp.GroupBy(x => x.Context);

                    foreach (var sameContextItem in groupedByContext)
                    {
                        var res = TranslateFacilityInfoDetail2GPToLocal(sameContextItem);
                        if (res != null)
                            facilitiesInfoDetails.Add(res);
                    }
                }

                return ServiceReturnHandling.BuildSuccessCallReturn<List<FacilityInfoContext>>(facilitiesInfoDetails, uiMessages);

            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<List<FacilityInfoContext>>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<List<MedicalAct>>> GetMedicalActsAsync(AuthenticationType tipoAuth, List<int> facilityIds, int? specialtyId, int? humanResourceID, int? financialEntity, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.GetMedicalActsError);

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            List<MedicalAct> ret = null;

            try
            {
                string baseMuleUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_MULE_URL");
                Generated.Mulesoft.GETClient sc = new Generated.Mulesoft.GETClient(baseMuleUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));

                //var specialtyIdFinal = !string.IsNullOrEmpty(specialtyId) ? specialtyId : "";
                //var humanResourceIdFinal = !string.IsNullOrEmpty(humanResourceId) ? humanResourceId : "";
                //var efrIdFinal = !string.IsNullOrEmpty(efrId) ? efrId : "";
                //var facilityIdsFinal = facilityIds.Select(x => double.Parse(x)).ToList();

                var retTemp = await sc.OfferMedicalActsAsync(facilityIds, specialtyId, humanResourceID, null, financialEntity, "", 0, 10000);

                if (retTemp != null)
                {
                    ret = new List<MedicalAct>();
                    foreach (var item in retTemp)
                        ret.Add(TranslateMedicalActGPToLocal(item));
                }

                return ServiceReturnHandling.BuildSuccessCallReturn<List<MedicalAct>>(ret, uiMessages);

            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<List<MedicalAct>>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<List<MedicalAct>>> GetMedicalActsByIdsAsync(AuthenticationType tipoAuth, List<int> medicalActsIds, List<int> facilitiesIDs, int skip, int take, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.GetMedicalActsError);

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            List<MedicalAct> ret = null;

            try
            {
                string baseMuleUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_MULE_URL");
                Generated.Mulesoft.GETClient sc = new Generated.Mulesoft.GETClient(baseMuleUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));

                var retTemp = await sc.MedicalActsAsync(medicalActsIds, facilitiesIDs, "", skip, take);

                if (retTemp != null)
                {
                    ret = new List<MedicalAct>();
                    foreach (var item in retTemp)
                        ret.Add(TranslateMedicalActGPToLocal(item));
                }

                return ServiceReturnHandling.BuildSuccessCallReturn<List<MedicalAct>>(ret, uiMessages);

            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<List<MedicalAct>>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<List<BusinessLayer.Entities.Warning>>> GetSearchWarningsAync(AuthenticationType tipoAuth, int facilityId, string appointId, string skip, string take, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.GetMedicalActsError);

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            List<BusinessLayer.Entities.Warning> ret = null;
            try
            {
                string baseMuleUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_MULE_URL");
                Generated.Mulesoft.GETClient sc = new Generated.Mulesoft.GETClient(baseMuleUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));

                var retTemp = await sc.AppointmentsIdNotesDescriptionAsync(facilityId, appointId);

                if (retTemp != null)
                {
                    ret = new List<BusinessLayer.Entities.Warning>();
                    var warning = TranslateWarningGPToLocal(retTemp);
                    warning.AppointmentId = appointId;
                    ret.Add(warning);
                }

                return ServiceReturnHandling.BuildSuccessCallReturn<List<BusinessLayer.Entities.Warning>>(ret, uiMessages);

            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<List<BusinessLayer.Entities.Warning>>(ex, uiMessages);
            }
        }

        #region Translates_GP

        private BusinessLayer.Entities.Warning TranslateWarningGPToLocal(Generated.Mulesoft.NotesDescription warnGP)
        {
            BusinessLayer.Entities.Warning warnLocal = new BusinessLayer.Entities.Warning();

            try
            {
                if (warnGP != null)
                {
                    warnLocal.Description = warnGP.Notes_description;

                    // TODO MApear
                    //warnLocal.Action = warnGP.Action.ToString();
                    //warnLocal.BeginDate = warnGP.BeginDate.HasValue ? warnGP.BeginDate.Value : DateTime.Now;
                    //warnLocal.Content = warnGP.Content;
                    //warnLocal.EndDate = warnGP.EndDate.HasValue ? warnGP.EndDate.Value : DateTime.Now;
                    //warnLocal.FacilityId = warnGP.FacilityId.ToString();
                    //warnLocal.Filepath = warnGP.FilePath;
                    //warnLocal.FinancialEntity = TranslateFinancialEntityLightGPToLocal(warnGP.FinancialEntity);
                    //warnLocal.MedicalAct = TranslateMedicalActGPToLocal(warnGP.MedicalAct);
                    //warnLocal.Status = warnGP.Status;
                    //warnLocal.Title = warnGP.Title;
                    //warnLocal.WarningCode = warnGP.WarningCode;
                    //warnLocal.WarningId = warnGP.WarningId;
                    //warnLocal.WarningType = warnGP.WarningType.ToString();
                    //warnLocal.Rubric = warnGP.RubricId;
                    //warnLocal.Financialentitygroup = warnGP.FinancialEntity.gr;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro a realizar o convert de Warning (GP) para Warning (local)");
                return warnLocal;
            }

            return warnLocal;
        }

        public BusinessLayer.Entities.FinancialEntity TranslateFinancialEntityGPToLocal(Generated.FinancialEntity2 efrGP)
        {
            FinancialEntity efrLocal = new FinancialEntity();
            try
            {
                if (efrGP != null)
                {
                    efrLocal.FinancialEntityCode = efrGP.Code;
                    if (efrGP.Id != null)
                        efrLocal.FinancialEntityId = (int)efrGP.Id;
                    efrLocal.Name = efrGP.Description;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro a realizar o convert de FinancialEntity (GP) para FinancialEntityLight (local)");
                return efrLocal;
            }
            return efrLocal;
        }

        public BusinessLayer.Entities.FinancialEntity TranslateDefaultFinancialEntityGPToLocal(Generated.Mulesoft.FinancialEntity efrGP)
        {
            FinancialEntity efrLocal = new FinancialEntity();
            try
            {
                if (efrGP != null)
                {
                    efrLocal.FinancialEntityCode = efrGP.Code;
                    if (efrGP.Id != null)
                        efrLocal.FinancialEntityId = efrGP.Id;
                    efrLocal.Name = efrGP.Description;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro a realizar o convert de FinancialEntity (GP) para FinancialEntityLight (local)");
                return efrLocal;
            }
            return efrLocal;
        }

        public BusinessLayer.Entities.MedicalAct TranslateMedicalActGPToLocal(Generated.Mulesoft.MedicalAct actMed)
        {
            try
            {
                if (actMed != null)
                {
                    MedicalAct actMedLocal = new MedicalAct()
                    {
                        MedicalActId = actMed.Id,
                        Name = actMed.Description,
                        SpecialtyId = actMed.Speciality_id,
                        IsAvailableForScheduling = true,
                    };

                    return actMedLocal;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro a realizar o convert de MedicalActivityCore (GP) para MedicalAct (local)");
            }

            return null;
        }

        public BusinessLayer.Entities.Facility TranslateFacilityDoctorGPToLocal(Generated.Facility2 facGP)
        {
            Facility facLocal = new Facility();
            try
            {
                if (facGP != null)
                {
                    facLocal.Address = facGP.Name; // Provavelmente nao é este o mapeamento
                    facLocal.FacilityId = (int)facGP.FacilityId;
                    facLocal.Name = facGP.Name;
                    facLocal.Ordem = facGP.Order.Value.ToString();
                    facLocal.Type = facGP.Type;
                    facLocal.Visible = true; // Colocar a true?
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro a realizar o convert de TranslateFacilityGPToLocal Facility (GP) para Facility (local)");
            }

            return facLocal;
        }

        public BusinessLayer.Entities.Facility TranslateFacilityGPToLocal(Generated.Mulesoft.Facility facGP)
        {
            Facility facLocal = new Facility();
            try
            {
                if (facGP != null)
                {
                    facLocal.Address = facGP.Name; // Provavelmente nao é este o mapeamento
                    facLocal.FacilityId = (int)facGP.Id;
                    facLocal.Name = facGP.Name;
                    facLocal.Ordem = facGP.Order.HasValue ? facGP.Order.Value.ToString() : "";
                    facLocal.Type = facGP.Type.ToString();
                    facLocal.Visible = true; // Colocar a true?
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro a realizar o convert de TranslateFacilityGPToLocal Facility (GP) para Facility (local)");
            }

            return facLocal;
        }

        public BusinessLayer.Entities.FacilityInfoContext TranslateFacilityInfoDetail2GPToLocal(IGrouping<string, Generated.Mulesoft.ContextInfo> facGPList)
        {
            FacilityInfoContext facLocal = new FacilityInfoContext()
            {
                FacilityInfoContextDetail = new List<FacilityContextDetail>(),
                Context = facGPList.Key,
            };

            try
            {
                foreach (var item in facGPList)
                {
                    FacilityContextDetail detail = new FacilityContextDetail()
                    {
                        Context = item.Context,
                        SubContext = item.Sub_context,
                        Title = item.Title_info,
                        Text = item.Text,
                        URLLogoBig = item.Url_logo_big,
                        URLLogoSmall = item.Url_logo_small,
                        InfoURLLogoBig = item.Info_url_logo_big,
                        InfoURLLogoSmall = item.Info_url_logo_small,
                    };

                    if (!string.IsNullOrEmpty(item.Title) && string.IsNullOrEmpty(facLocal.Title))
                        facLocal.Title = item.Title;

                    //if (!string.IsNullOrEmpty(item.Url_logo_big) && string.IsNullOrEmpty(facLocal.URLLogoBig))
                    //    facLocal.URLLogoBig = item.Url_logo_big;

                    //if (!string.IsNullOrEmpty(item.Url_logo_small) && string.IsNullOrEmpty(facLocal.URLLogoSmall))
                    //    facLocal.URLLogoSmall = item.Url_logo_small;

                    facLocal.FacilityInfoContextDetail.Add(detail);
                }
            }
            catch (Exception)
            {

            }

            return facLocal;
        }

        #endregion Translates_GP
    }
}
