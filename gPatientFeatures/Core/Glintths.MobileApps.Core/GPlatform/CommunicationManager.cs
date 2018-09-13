using Glintths.MobileApps.Core.GPlatform;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Glintths.MobileApps.Core.GPlatform.ServiceGPAccessLayer.GPService;

namespace Glintths.MobileApps.Core.GPlatform
{
    public sealed class CommunicationManager
    {
        private static volatile CommunicationManager instance;
        private static object syncRoot = new Object();
        private static bool anonymousAuthentication;
        private static bool userAuthentication;
        private static string _userName;
        private static string _userPassWord;
        private static DateTime authenticationDate;

        private CommunicationManager() { }

        public static CommunicationManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new CommunicationManager();
                    }
                }

                return instance;
            }
        }

        public static Token AccessToken { get; set; }
        public static string UserName { get => _userName; set => _userName = value; }
        public static string UserPassWord { get => _userPassWord; set => _userPassWord = value; }

        private static ServiceManager _ServiceManager;

        public static ServiceManager ServiceManager { get => _ServiceManager == null ? new ServiceManager(Configuration.Instance.Configurations["GP_APP_ID"], GetGPAppVersion(), string.Empty) : _ServiceManager; set => _ServiceManager = value; }

        public async Task<HttpClient> GetHttpClientWithToken(AuthenticationType tipoAuth, HttpClient client)
        {
            if (!IsAuthenticated(tipoAuth))
                await Authenticate(tipoAuth);

            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");

            if (!string.IsNullOrEmpty(AccessToken.AccessToken))
            {
                client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", AccessToken.AccessToken));
            }

            return client;
        }

        public bool IsAuthenticated(AuthenticationType tipoAuth)
        {
            try
            {
                if (tipoAuth == AuthenticationType.AnonymousAuthentication)
                    return IsAnonymousAuthenticated();
                else if (tipoAuth == AuthenticationType.UserAuthentication)
                    return IsUserAuthenticated();

                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro em CommunicationManager - IsAuthenticated");
                return false;
            }
        }

        public async Task<bool> CheckIfPasswordIsCorrect(string user, string pass)
        {
            try
            {
                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                    return false;
                await Authenticate(AuthenticationType.UserAuthentication, user, pass);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool IsAnonymousAuthenticated()
        {
            // Não deve ser impeditivo a um user autenticado ( userAuthentication = true e anonymousAuthentication = false) não conseguir utilizar webservs com autenticaçao anónima~ // ( anonymousAuthentication || userAuthentication )
            return (anonymousAuthentication || userAuthentication) && (authenticationDate.AddSeconds((double)AccessToken.ExpiresIn) > DateTime.Now);
        }

        private bool IsUserAuthenticated()
        {
            return userAuthentication && (authenticationDate.AddSeconds((double)AccessToken.ExpiresIn) > DateTime.Now);
        }

        public async Task Authenticate(AuthenticationType tipoAuth, string user = "", string pass = "")
        {
            UserName = !string.IsNullOrEmpty(user) ? user : UserName;
            UserPassWord = !string.IsNullOrEmpty(pass) ? pass : UserPassWord;

            var cult = CultureInfo.CurrentCulture.Name;

            if (tipoAuth == AuthenticationType.AnonymousAuthentication)
                await AuthenticateAnonymous(Configuration.Instance.Configurations["GP_CLIENT_ID"], Configuration.Instance.Configurations["GP_CLIENT_SECRET"], Configuration.Instance.Configurations["GP_APP_ID"], GetGPAppVersion(), string.Empty, string.Empty, cult, Configuration.Instance.Configurations["GP_FACILITY_ID"], Configuration.Instance.Configurations["GP_TENANT_ID"]);
            else if (tipoAuth == AuthenticationType.UserAuthentication)
                await AuthenticateUser(Configuration.Instance.Configurations["GP_CLIENT_ID"], Configuration.Instance.Configurations["GP_CLIENT_SECRET"], UserName, UserPassWord, Configuration.Instance.Configurations["GP_APP_ID"], GetGPAppVersion(), string.Empty, string.Empty, cult, Configuration.Instance.Configurations["GP_FACILITY_ID"], Configuration.Instance.Configurations["GP_TENANT_ID"]);
        }

        private async static Task AuthenticateUser(string clientId, string clientSecret, string username, string password, string applicationID, string applicationVersion, string userId, string userType, string culture, string facilityid, string tenantid)
        {
            try
            {
                AccessToken = await ServiceManager.CallServiceAsync<Token>("GP_SEC_ACCESS_TOKEN_URL", HttpMethod.Post,
                                                       new List<KeyValuePair<string, string>>() {
                                                         new KeyValuePair<string, string>("grant_type", "password"),
                                                         new KeyValuePair<string, string>("client_id", clientId),
                                                         new KeyValuePair<string, string>("client_secret", clientSecret),
                                                         new KeyValuePair<string, string>("username", username),
                                                         new KeyValuePair<string, string>("password", password),
                                                         new KeyValuePair<string, string>("ApplicationID", applicationID),
                                                         new KeyValuePair<string, string>("ApplicationVersion", applicationVersion),
                                                         new KeyValuePair<string, string>("tenantID", tenantid),
                                                         //new KeyValuePair<string, string>("userid", userId),
                                                         //new KeyValuePair<string, string>("usertype", userType),
                                                         new KeyValuePair<string, string>("culture", culture),
                                                         new KeyValuePair<string, string>("facilityID", facilityid)
                                                       });

                authenticationDate = DateTime.Now;

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    userAuthentication = true;
                    anonymousAuthentication = false;
                }
                else
                {
                    userAuthentication = false;
                    anonymousAuthentication = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async static Task AuthenticateAnonymous(string clientId, string clientSecret, string applicationID, string applicationVersion, string userId, string userType, string culture, string facilityId, string tenantId)
        {
            await AuthenticateUser(clientId, clientSecret, string.Empty, string.Empty, applicationID, applicationVersion, userId, userType, culture, facilityId,tenantId);
        }

        public async Task<bool> ChangeTokenCulture(string culture)
        {
            bool success = false;

            try
            {
                var tmpToken = await ServiceManager.CallServiceAsync<Token>("GP_SEC_ACCESS_TOKEN_URL_SET_CULTURE", HttpMethod.Put,
                  new List<KeyValuePair<string, string>>() {
                                                         new KeyValuePair<string, string>("culture", culture),
                                                         }, AccessToken.AccessToken);

                if (tmpToken != null && !string.IsNullOrEmpty(tmpToken.AccessToken)  // Validar que novo token retorna realmente info
                    && AccessToken != null && !string.IsNullOrEmpty(AccessToken.AccessToken))  // Validar que token antigo tinha info (caso contrário porta de entrada para hackers)
                {
                    success = true;
                    AccessToken = tmpToken;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro a fazer update da culture (token)");
            }

            return success;
        }
    }
}
