using Glintths.Apps.Base.Internationalization.Resx;
using Glintths.MobileApps.Core.BusinessLayer.Entities;
using Glintths.MobileApps.Core.Helpers;
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
using Xamarin.Forms;

namespace Glintths.MobileApps.Core.GPlatform.ServiceGPAccessLayer
{
    public partial class GPService
    {
        public static string AUTHENTICATED_MSG = "AUTHENTICATED_USER";
        public static string UNAUTHENTICATED_MSG = "UNAUTHENTICATED_USER";

        public User User { get; set; }


        private Patient _UserPatient;
        public Patient UserPatient
        {
            get { return _UserPatient; }
            set
            {
                _UserPatient = value;
                if (value != null)
                    MessagingCenter.Send<GPService>(this, GPService.AUTHENTICATED_MSG);
                else
                    MessagingCenter.Send<GPService>(this, GPService.UNAUTHENTICATED_MSG);
            }
        }

        public async Task<bool> RegistryUserFromDeviceAndLogin(AuthenticationType tipoAuth, UserType userType, string userId, string username, string password, Guid validationCodeId)
        {
            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.SecurityClient sc = new Generated.SecurityClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                var result = await sc.GetRegistryUserFromDeviceAndLoginAsync(username, password, TranslateUserTypeLocalToGP(userType), userId, GetGPAppVersion());

                bool isAuthenticated = result.IsAuthenticated.HasValue ? result.IsAuthenticated.Value : false;

                if (isAuthenticated)
                {
                    SessionExternal Session = TranslateSessionExternalGPToLocal(result);
                    User = new User()
                    {
                        Name = Session.Name,
                        Type = Session.UserType,
                        UserId = Session.UserId,
                        Username = Session.Username,
                        //Session = new Session(encryptKey) { EncryptedSessionTokenSecret = Session.EncryptedAccessTokenSecret }, // É necessário?? Não está a ser devolvida... AccessToken substitui?
                        SecurityId = Session.SecurityId
                    };

                    // Este assign permite/serve para posteriormente a esta chamada quando algum serv for invocado com AuthenticationType = UserAuthentication utilizar estas credenciais para obter token
                    CommunicationManager.UserName = username;
                    CommunicationManager.UserPassWord = password;

                    var resultTMP = await GPService.Instance.GetAndSetPatientInfoByUniqueIdAsync(AuthenticationType.UserAuthentication, User.UserId); // Sincronamente irá obter dados paciente

                    GPService.Instance.GetPatientPhoto(AuthenticationType.UserAuthentication);  // obter foto do paciente ( colocar sincrono?? é necessária para a primeira página -filtro na página da agenda)
                    GPService.Instance.GetAndSetDefaultFinancialEntityByUniquePatient(AuthenticationType.UserAuthentication, null, null/*User.UserId*/);   // obter/preencher EFRID do paciente assincronamente 

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Logout()
        {
            User = null;
            UserPatient = null;
            // Os valores abaixo deverão ser alterados se na GPlatform for definido com as credenciais do AuthenticationType = AnonymousAuthentication..atualmente são string.Empty; 
            CommunicationManager.UserName = string.Empty;
            CommunicationManager.UserPassWord = string.Empty;
        }

        public async Task<ServiceReturn<bool>> UploadProfilePhotoAsync(AuthenticationType tipoAuth, byte[] photo, string extension, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.Error);
            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            bool uploadSuccess = false;
            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.PatientDataClient sc = new Generated.PatientDataClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                await sc.PostUploadProfilePhotoAsync(photo, extension, GetGPAppVersion());

                uploadSuccess = true;

                return ServiceReturnHandling.BuildSuccessCallReturn<bool>(uploadSuccess, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<bool>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<byte[]>> DownloadProfilePhotoAsync(AuthenticationType tipoAuth, string successMessage = "", string errorMessage = "")
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
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.PatientDataClient sc = new Generated.PatientDataClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                var result = await sc.GetDownloadPatientPhotoAsync(string.Empty, "300", "300", GetGPAppVersion());

                return ServiceReturnHandling.BuildSuccessCallReturn<byte[]>(result, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<byte[]>(ex, uiMessages);
            }
        }

        public string GetEncryptionKey()
        {
            string encryptKey = Configuration.Instance.Configurations["APP_SECRET"];
            if (Configuration.Instance.Configurations["SECURITY_TYPE"] != "OAUTH")
            {
                encryptKey = Configuration.Instance.Configurations["UNSECURE_APP_SECRET"];
            }
            return encryptKey;
        }

        public async Task<Guid> ValidateCodeAsync(AuthenticationType tipoAuth, string _action, string _patientId, string _validationCode)
        {
            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.SecurityClient sc = new Generated.SecurityClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                var result = await sc.GetValidateCodeAsync(Generated.UserType2.Patient, _patientId, _action, _validationCode, GetGPAppVersion());

                Guid ret = Guid.Parse(result.ToString());

                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Guid> GetValidateCodeByUsernameAsync(AuthenticationType tipoAuth, string _action, string _username, string _validationCode)
        {
            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.SecurityClient sc = new Generated.SecurityClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                var result = await sc.GetValidateCodeByUsernameAsync(_username, _action, _validationCode, GetGPAppVersion());

                var ret = Guid.Parse(result.ToString());

                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> CreateAndSendValidationCodeAsync(AuthenticationType tipoAuth, string username, string _action)
        {
            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.SecurityClient sc = new Generated.SecurityClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                var result = await sc.GetCreateAndSendValidationCodeAsync(username, _action, string.Empty, string.Empty, string.Empty, string.Empty, GetGPAppVersion());

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ResetUserPasswordAsync(AuthenticationType tipoAuth, string username, string newPassword, Guid validationCodeId)
        {
            string codeVal = validationCodeId.ToString().ToUpper();
            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.SecurityClient sc = new Generated.SecurityClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                var result = await sc.GetResetUserPasswordAsync(username, newPassword, codeVal, GetGPAppVersion());

                if (result)
                {
                    // Este assign permite/serve para posteriormente a esta chamada quando algum serv for invocado com AuthenticationType = UserAuthentication utilizar estas credenciais para obter token
                    CommunicationManager.UserName = username;
                    CommunicationManager.UserPassWord = newPassword;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ChangeUserPasswordAsync(AuthenticationType tipoAuth, string username, string oldPassword, string newPassword)
        {
            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.SecurityClient sc = new Generated.SecurityClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                var result = await sc.GetChangeUserPasswordAsync(username, oldPassword, newPassword, GetGPAppVersion());

                if (result)
                {
                    // Este assign permite/serve para posteriormente a esta chamada quando algum serv for invocado com AuthenticationType = UserAuthentication utilizar estas credenciais para obter token
                    CommunicationManager.UserName = username;
                    CommunicationManager.UserPassWord = newPassword;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> CheckIfUserEmailsIsAlreadyRegistered(AuthenticationType tipoAuth, string email)
        {

            string excepMessage = string.Empty;
            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.UsersClient sc = new Generated.UsersClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                var result = await sc.GetByUsernameAsync(email, GetGPAppVersion());

                SessionExternal session = TranslateSessionExternalGPToLocal(result);
                if (session.UserId != null)
                {
                    excepMessage = AppResources.ExistingUserEmail;
                    throw new Exception(AppResources.ExistingUserEmail);
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                if (string.IsNullOrEmpty(excepMessage)) // Erros genericos
                    throw new Exception(AppResources.CouldNotValidateExistingUserEmail);

                throw ex; // Erros com mensagem definida
            }

        }

        public async Task<ServiceReturn<string>> VerifyUserAndCreatePatient(AuthenticationType tipoAuth, string username, string nif, System.DateTime birthDate, string name, string email, string phoneNumber, string gender, string destination, string version, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.NotPossibleCreatePacient);

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.UsersClient sc = new Generated.UsersClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                var result = await sc.VerifyUserAndCreatePatientAsync(username, nif, "SMS", birthDate, name, email, phoneNumber, gender, destination, phoneNumber, string.Empty, string.Empty, string.Empty, string.Empty, true, GetGPAppVersion());

                return ServiceReturnHandling.BuildSuccessCallReturn<string>(result, uiMessages);
            }
            catch (Exception ex)
            {
                try
                {
                    var gpExp = ((Generated.GPlatformException)ex).Response;
                    var localExcp = Newtonsoft.Json.JsonConvert.DeserializeObject<GPlatformClientException>(gpExp);

                    if (!string.IsNullOrEmpty(ex.Message) && ex.Message.Contains("The HTTP status code of the response was not expected (40"))
                        uiMessages[ServiceReturnHandling.GenericMessageKey] = localExcp.Description;
                }
                catch (Exception) { }

                return ServiceReturnHandling.HandleException<string>(ex, uiMessages);
            }
        }

        public async Task<User> GetMyUserIdAsync(AuthenticationType tipoAuth, bool setUser = true)
        {
            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.SecurityClient sc = new Generated.SecurityClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                var result = await sc.GetMyUserIdAsync(GetGPAppVersion());

                SessionExternal session = TranslateSessionExternalGPToLocal(result);
                if (session.UserId != null)
                {
                    var tmpUser = new User()
                    {
                        Name = session.Name,
                        Type = session.UserType,
                        UserId = session.UserId,
                        Username = session.Username,
                        //Session = new Session(encryptKey) { EncryptedSessionTokenSecret = Session.EncryptedAccessTokenSecret }, // É necessário?? Não está a ser devolvida... AccessToken substitui?
                        SecurityId = session.SecurityId
                    };

                    if (setUser)
                        User = tmpUser;

                    return tmpUser;
                }

                return null;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro em GetMyUserIdAsync");
                return null;
            }
        }

        #region Translates_GP

        public BusinessLayer.Entities.UserType TranslateUserTypeGPToLocal(Generated.UserType gtUser_type)
        {
            return (BusinessLayer.Entities.UserType)gtUser_type;
        }

        public Generated.UserType TranslateUserTypeLocalToGP(BusinessLayer.Entities.UserType localUser_type)
        {
            return (Generated.UserType)localUser_type;
        }

        public BusinessLayer.Entities.UserType TranslateUserType2GPToLocal(Generated.UserType2 gtUserType2_type)
        {
            return (BusinessLayer.Entities.UserType)gtUserType2_type;
        }

        public Generated.UserType2 TranslateUserType2LocalToGP(BusinessLayer.Entities.UserType localUserType2_type)
        {
            return (Generated.UserType2)localUserType2_type;
        }

        public BusinessLayer.Entities.SessionExternal TranslateSessionExternalGPToLocal(Generated.UserData gt_sessionExt)
        {
            SessionExternal localSession = new SessionExternal();
            try
            {
                if (gt_sessionExt != null)
                {
                    localSession.IsAuthenticated = gt_sessionExt.IsAuthenticated.HasValue ? gt_sessionExt.IsAuthenticated.Value : false;
                    localSession.Name = gt_sessionExt.Name;
                    localSession.SecurityId = gt_sessionExt.SecurityId;
                    localSession.UserId = gt_sessionExt.UserId;
                    localSession.Username = gt_sessionExt.Username;
                    localSession.UserType = UserType.Patient; // TODO Validar esta instrução.. Forçado type = patient? 
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro a realizar o convert de UserData para SessionExternal");
                return localSession;
            }

            return localSession;
        }

        #endregion Translates_GP


    }
}
