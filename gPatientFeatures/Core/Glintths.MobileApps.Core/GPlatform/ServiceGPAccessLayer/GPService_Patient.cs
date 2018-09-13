using Glintths.Apps.Base.Internationalization.Resx;
using Glintths.MobileApps.Core.BusinessLayer.Entities;
using Glintths.MobileApps.Core.GPlatform.Generated.Mulesoft;
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
using Xamarin.Forms;

namespace Glintths.MobileApps.Core.GPlatform.ServiceGPAccessLayer
{
    public partial class GPService
    {
        public async Task<ServiceReturn<string>> FindCentralPatientByNIFPhoneAsync(AuthenticationType tipoAuth, string _nif, DateTime? _birthday, string _phoneNumber, string successMessage = "", string errorMessage = "")
        {
            // retorna id pat unico
            string ret = string.Empty;

            #region uimessage
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "Não foi possível encontrar paciente.");
            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);
            #endregion

            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.PatientCoreClient sc = new Generated.PatientCoreClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));

                // if _birthday != datetime.today???
                DateTime defaultDate = DateTime.Now;

                // retorna id pat unico
                if (_birthday.HasValue)
                    ret = await sc.GetCentralPatientByNifPhoneAndBirthDateAsync(_nif, _phoneNumber, string.Empty, string.Empty, _birthday.Value, GetGPAppVersion());
                else
                    ret = await sc.GetCentralPatientByNifAndPhoneAsync(_nif, _phoneNumber, string.Empty, string.Empty, GetGPAppVersion());

                return ServiceReturnHandling.BuildSuccessCallReturn<string>(ret, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<string>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<string>> CreateProPatientAsync(AuthenticationType tipoAuth, string facilityId, string patName, string patEmail, DateTime patBirthDate, string patientNif, string patientPhoneNumber, string patGender, string successMessage = "", string errorMessage = "")
        {
            #region uimessage
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "Não foi possível registar o novo paciente.");
            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);
            #endregion

            try
            {
                facilityId = string.IsNullOrEmpty(facilityId) ? "" : facilityId;

                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.PatientCoreClient sc = new Generated.PatientCoreClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                var ret = await sc.GetCreateProPatientAsync(facilityId, patName, patEmail, patBirthDate, patientNif, patientPhoneNumber, patGender, GetGPAppVersion());

                if (ret != null && !string.IsNullOrEmpty(ret.CorporatePatientId))
                    return ServiceReturnHandling.BuildSuccessCallReturn<string>(ret.CorporatePatientId, uiMessages);
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<string>(ex, uiMessages);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoAuth"></param>
        /// <param name="setUser">Persiste na classe GPService os dados do paciente (conceito UserPatient) obtidos para consumo posterior (GPService funciona tipo repositório/Sessão)</param>
        /// <returns></returns>
        public async Task<bool> GetAndSetPatientInfoByUniqueIdAsync(AuthenticationType tipoAuth, string userID)
        {
            try
            {
                var serviceResponse = await GetPatientInfoByUniqueIdAsync(tipoAuth, userID, string.Empty, string.Empty);
                if (serviceResponse.Success)
                {
                    UserPatient = serviceResponse.Result;
                    User.Name = UserPatient.Name;
                    UserPatient.PatientUniqueId = User.UserId;
                    return true;
                }
                throw new Exception();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error on GetAndSetPatientInfoByUniqueIdAsync: ");
                UserPatient = null;
                return false;
            }
        }

        public async Task<ServiceReturn<BusinessLayer.Entities.Patient>> GetPatientInfoByUniqueIdAsync(AuthenticationType tipoAuth, string uniquePatId, string successMessage = "", string errorMessage = "")
        {
            #region uimessage
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "Não foram encontrados dados do paciente.");
            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);
            #endregion

            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_MULE_URL");
                PatientsPatientClient sc = new PatientsPatientClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                var ret = await sc.IdAsync(uniquePatId);

                BusinessLayer.Entities.Patient localPat = TranslatePatientGPtoLocal(ret);

                return ServiceReturnHandling.BuildSuccessCallReturn<BusinessLayer.Entities.Patient>(localPat, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<BusinessLayer.Entities.Patient>(ex, uiMessages);
            }
        }

        public async Task GetPatientPhoto(AuthenticationType tipoAuth)
        {
            try
            {
                var res = await GPService.Instance.DownloadProfilePhotoAsync(AuthenticationType.UserAuthentication);

                if (res.Success)
                {
                    UserPatient.PhotoUrl = string.Empty;
                    UserPatient.PhotoByte = res.Result;

                    MessagingCenter.Send<GPService>(GPService.instance, "PROFILE_PHOTO_REFRESH");
                }
            }
            catch (Exception ex)
            {
                string a = "";
            }
        }

        public async void GetAndSetDefaultFinancialEntityByUniquePatient(AuthenticationType tipoAuth, string facilityId, string userId)
        {
            try
            {
                var respEfrId = await GetDefaultFinancialEntityByUniquePatientIdAsync(tipoAuth, facilityId, userId);
                if (respEfrId.Success)
                    UserPatient.FinancialEntityId = respEfrId.Result.FinancialEntityId;
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<ServiceReturn<List<DescendantCollectionItem>>> GetUserDescendants(AuthenticationType tipoAuth, string idUser, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.Error);
            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            List<DescendantCollectionItem> listFinal = new List<DescendantCollectionItem>();
            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_MULE_URL");
                PatientsPatientClient sc = new PatientsPatientClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                var resDesc = await sc.IdDescendantsAsync(0, 100, idUser);

                if (resDesc != null)
                    listFinal = resDesc.ToList();

                return ServiceReturnHandling.BuildSuccessCallReturn<List<DescendantCollectionItem>>(listFinal, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<List<DescendantCollectionItem>>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<bool>> UpdatePatientInfoAsync(AuthenticationType tipoAuth, BusinessLayer.Entities.Patient patient)
        {
            var uiMessages = new Dictionary<string, string>();
            uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.Error);
            uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, "Success");

            try
            {
                if (patient == null || string.IsNullOrEmpty(patient.PatientUniqueId))
                    throw new Exception("Parametros inválidos em UpdatePatientInfoAsync");

                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_MULE_URL");
                PatientsPatientClient sc = new PatientsPatientClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));

                var patientGP = TranslatePatientLocaltoGP(patient);

                if (patientGP == null || string.IsNullOrEmpty(patientGP.Id))
                    throw new Exception("Erro a converter Modelo de Paciente em UpdatePatientInfoAsync");

                await sc.IdRequestInfoUpdateAsync(patientGP, patientGP.Id);

                return ServiceReturnHandling.BuildSuccessCallReturn<bool>(true, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<bool>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<bool>> DeletePatientByIDAsync(AuthenticationType tipoAuth, string patientID)
        {
            var uiMessages = new Dictionary<string, string>();
            uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.Error);
            uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, "Success");

            try
            {
                if (string.IsNullOrEmpty(patientID))
                    throw new Exception("Parametros inválidos em DeletePatientByIDAsync");

                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_MULE_URL");
                PatientsPatientClient sc = new PatientsPatientClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));

                await sc.IdDeleteAsync(patientID);

                return ServiceReturnHandling.BuildSuccessCallReturn<bool>(true, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<bool>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<bool>> CreateDescendantAsync(AuthenticationType tipoAuth, string idParent, MobileApps.Core.BusinessLayer.Entities.Patient desc, string colorHex, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.Error);
            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_MULE_URL");
                PatientsPatientClient sc = new PatientsPatientClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));

                var descBody = TranslatePatientLocaltoDescendantGP(desc, colorHex);

                await sc.IdDescendantsAsync(descBody, idParent);

                return ServiceReturnHandling.BuildSuccessCallReturn<bool>(true, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<bool>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<bool>> UpdateDescendantColorAsync(AuthenticationType tipoAuth, string idParent, string idDesc, string colorHex, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.Error);
            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            try
            {
                if (string.IsNullOrEmpty(idParent) || string.IsNullOrEmpty(idDesc) || string.IsNullOrEmpty(colorHex))
                    throw new Exception("Parametros inválidos em UpdateUserDescendantColor");

                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_MULE_URL");
                ChangeColor colorBody = new ChangeColor() { Color = colorHex };
                IdDescendantsDescendantClient sc = new IdDescendantsDescendantClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));

                await sc.IdChangeColorAsync(colorBody, idDesc, idParent);

                return ServiceReturnHandling.BuildSuccessCallReturn<bool>(true, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<bool>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<bool>> DisassociateCurrentDescendantFromParentAsync(AuthenticationType tipoAuth, string idParent, string idDesc, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.Error);
            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            try
            {
                if (string.IsNullOrEmpty(idParent) || string.IsNullOrEmpty(idDesc))
                    throw new Exception("Parametros inválidos em DisassociateCurrentDescendantFromParentAsync");

                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_MULE_URL");
                IdDescendantsDescendantClient sc = new IdDescendantsDescendantClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));

                await sc.IdAsync(idDesc, idParent);

                return ServiceReturnHandling.BuildSuccessCallReturn<bool>(true, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<bool>(ex, uiMessages);
            }
        }

        public BusinessLayer.Entities.Patient TranslatePatientGPtoLocal(Generated.Mulesoft.Patient patGP)
        {
            try
            {
                if (patGP != null)
                {
                    BusinessLayer.Entities.Patient patLocal = new BusinessLayer.Entities.Patient()
                    {
                        PatientUniqueId = patGP.Id,
                        BirthDate = patGP.Birthdate.HasValue ? patGP.Birthdate.Value : DateTime.Now,
                        Email = patGP.Email,
                        City = patGP.Address_local,
                        IdNumber = patGP.Citizen_number,
                        Name = patGP.Name,
                        PhoneNumber1 = patGP.First_phone_number,
                        PhoneNumber2 = patGP.Second_phone_number,
                        NSns = patGP.Ssn,
                        TaxIdNumber = patGP.Tax_number,
                        Sex = patGP.Gender,
                        Street = patGP.Address,
                        PostalCode = patGP.Address_zip_code,
                        IsProPatient = patGP.Temporary.HasValue ? patGP.Temporary.Value : true,
                        HasPendingAlterations = patGP.Updated.HasValue ? !patGP.Updated.Value : false,
                        LastAlterationsDate = patGP.Updated_datetime.HasValue ? patGP.Updated_datetime.Value : DateTime.Now,
                    };
                    return patLocal;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro em TranslatePatientGPtoLocal " + ex.ToString());
                return null;
            }
            return null;
        }

        public Generated.Mulesoft.Patient TranslatePatientLocaltoGP(BusinessLayer.Entities.Patient patLocal)
        {
            try
            {
                Generated.Mulesoft.Patient patGp = new Generated.Mulesoft.Patient()
                {
                    Id = patLocal.PatientUniqueId,
                    Birthdate = patLocal.BirthDate,
                    Email = patLocal.Email,
                    Address_local = patLocal.City,
                    Citizen_number = patLocal.IdNumber,
                    Name = patLocal.Name,
                    First_phone_number = patLocal.PhoneNumber1,
                    Second_phone_number = patLocal.PhoneNumber2,
                    Ssn = patLocal.NSns,
                    Tax_number = patLocal.TaxIdNumber,
                    Gender = patLocal.Sex,
                    Address = patLocal.Street,
                    Address_zip_code = patLocal.PostalCode,
                    //Temporary = patLocal.IsProPatient, // isto deverá ser gerido do lado do GH/Services
                    Updated = false, // Enviar que tenho alterações pendentes de validação
                    //LastAlterationsDate = // isto deverá ser gerido do lado do GH/Services
                };

                return patGp;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro em TranslatePatientLocaltoGP " + ex.ToString());
                return null;
            }
        }

        public Generated.Mulesoft.Descendant TranslatePatientLocaltoDescendantGP(BusinessLayer.Entities.Patient patLocal,string colorHex)
        {
            try
            {
                Generated.Mulesoft.Descendant patGp = new Generated.Mulesoft.Descendant()
                {
                    Id = patLocal.PatientUniqueId,
                    Birthdate = patLocal.BirthDate,
                    Email = patLocal.Email,
                    Address_local = patLocal.City,
                    Citizen_number = patLocal.IdNumber,
                    Name = patLocal.Name,
                    First_phone_number = patLocal.PhoneNumber1,
                    Second_phone_number = patLocal.PhoneNumber2,
                    Ssn = patLocal.NSns,
                    Tax_number = patLocal.TaxIdNumber,
                    Gender = patLocal.Sex,
                    Address = patLocal.Street,
                    Address_zip_code = patLocal.PostalCode,
                    Color = colorHex,
                    Valid = false,
                    Temporary= true,
                };

                return patGp;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro em TranslatePatientLocaltoGP " + ex.ToString());
                return null;
            }
        }


    }
}
