using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Diagnostics;

namespace Glintths.MobileApps.Core.GPlatform
{
    class CommunicationHelper
    {
        private static async Task<HttpResponseMessage> ExecuteCall<T>(string url, HttpMethod method, List<KeyValuePair<string, string>> headers, List<KeyValuePair<string, string>> urlParameters, T bodyContent, string accessToken = null)
        {
            if (urlParameters != null && urlParameters.Count > 0)
            {
                if (urlParameters.Count == 1 && urlParameters.First().Key == "#id#")
                {
                    url += urlParameters.First().Value;
                }
                else
                {

                    url += "?";
                    for (int i = 0; i < urlParameters.Count; i++)
                    {
                        url += (i == 0 ? "" : "&") + urlParameters[i].Key + "=" + urlParameters[i].Value;
                    }
                }
            }

            var uri = new Uri(url);

            try
            {

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");

                    if (!string.IsNullOrEmpty(accessToken))
                    {
                        client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", accessToken));
                    }

                    if (headers != null && headers.Count > 0)
                    {
                        foreach (var header in headers)
                        {
                            client.DefaultRequestHeaders.Add(header.Key, System.Convert.ToBase64String(Encoding.UTF8.GetBytes(header.Value)));
                        }
                    }

                    HttpResponseMessage response;

                    if (method == HttpMethod.Get)
                    {
                        response = await client.GetAsync(uri);
                    }
                    else
                    {
                        var requestContent = JsonConvert.SerializeObject(bodyContent);

                        var request = new StringContent(requestContent)
                        {
                            Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
                        };

                        response = await client.PostAsync(uri, request);

                    }

                    //PLIMA
                    /*if (response.StatusCode == HttpStatusCode.BadRequest)
                        throw new HttpResponseException(response);*/
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                        throw new HttpRequestException(await response.Content.ReadAsStringAsync());

                    if (!response.IsSuccessStatusCode)
                        throw new HttpRequestException(await response.Content.ReadAsStringAsync());

                    response.EnsureSuccessStatusCode();

                    return response;
                }
            }
            catch (SecurityException e1)
            {
                throw e1;
            }

            catch (HttpRequestException e)
            {
                throw e;
            }

            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro calling " + uri.AbsoluteUri, ex);
            }
        }

        private static async Task<HttpResponseMessage> ExecuteCall<T>(string url, HttpMethod method, List<KeyValuePair<string, string>> formUrlEncodedContent, string accessToken = null)
        {
            var uri = new Uri(url);

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");

                    if (!string.IsNullOrEmpty(accessToken))
                    {
                        client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
                    }

                    var request = new HttpRequestMessage(method, url);
                    request.Content = new FormUrlEncodedContent(formUrlEncodedContent);
                    var response = await client.SendAsync(request);
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    response.EnsureSuccessStatusCode();

                    return response;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro calling " + uri.AbsoluteUri, ex);
            }
        }

        public static async Task Call<T>(string url, HttpMethod method, List<KeyValuePair<string, string>> headers, List<KeyValuePair<string, string>> urlParameters, T bodyContent, string accessToken = null)
        {
            var response = await ExecuteCall<T>(url, method, headers, urlParameters, bodyContent, accessToken);
            return;
        }

        public static async Task<U> Call<T, U>(string url, HttpMethod method, List<KeyValuePair<string, string>> headers, List<KeyValuePair<string, string>> urlParameters, T bodyContent, string accessToken = null)
        {
            var response = await ExecuteCall<T>(url, method, headers, urlParameters, bodyContent, accessToken);
            var result = await response.Content.ReadAsStringAsync();
            U ret = JsonConvert.DeserializeObject<U>(result);
            return ret;
        }

        public static async Task<U> Call<U>(string url, HttpMethod method, List<KeyValuePair<string, string>> headers, List<KeyValuePair<string, string>> urlParameters, string accessToken = null)
        {
            var response = await ExecuteCall<string>(url, method, headers, urlParameters, string.Empty, accessToken);
            var result = await response.Content.ReadAsStringAsync();
            U ret = JsonConvert.DeserializeObject<U>(result);
            return ret;
        }

        public static async Task<U> Call<U>(string url, HttpMethod method, List<KeyValuePair<string, string>> formUrlEncodedContent, string accessToken = null)
        {
            var response = await ExecuteCall<string>(url, method, formUrlEncodedContent, accessToken);
            var result = await response.Content.ReadAsStringAsync();
            U ret = JsonConvert.DeserializeObject<U>(result);
            return ret;
        }
    }



    public class ServiceManager
    {

        private string AppName { get; set; }
        private string AppVersion { get; set; }
        private string SDUrl { get; set; }

        public ServiceManager(string appName, string appVersion, string sdURL)
        {
            AppName = appName;
            AppVersion = appVersion;
            SDUrl = sdURL;
        }

        public async Task CallServiceAsync<T>(string serviceKey, HttpMethod method, List<KeyValuePair<string, string>> headers, List<KeyValuePair<string, string>> urlParameters, T bodyContent, string accessToken = null)
        {
            await CommunicationHelper.Call<T>(await GetServiceEndpoint(serviceKey), method, headers, urlParameters, bodyContent, accessToken);
            return;
        }

        public async Task<U> CallServiceAsync<T, U>(string serviceKey, HttpMethod method, List<KeyValuePair<string, string>> headers, List<KeyValuePair<string, string>> urlParameters, T bodyContent, string accessToken = null)
        {
            return await CommunicationHelper.Call<T, U>(await GetServiceEndpoint(serviceKey), method, headers, urlParameters, bodyContent, accessToken);
        }

        public async Task<U> CallServiceAsync<U>(string serviceKey, HttpMethod method, List<KeyValuePair<string, string>> headers, List<KeyValuePair<string, string>> urlParameters, string accessToken = null)
        {
            return await CommunicationHelper.Call<U>(await GetServiceEndpoint(serviceKey), method, headers, urlParameters, accessToken);
        }

        public async Task<U> CallServiceAsync<U>(string serviceKey, HttpMethod method, List<KeyValuePair<string, string>> formUrlEncodedContent, string accessToken = null)
        {
            return await CommunicationHelper.Call<U>(await GetServiceEndpoint(serviceKey), method, formUrlEncodedContent, accessToken);
        }

        internal async Task<string> GetServiceEndpoint(string serviceKey)
        {

            
            switch (serviceKey)
            {
                case "GP_SEC_ACCESS_TOKEN_URL":
                    return Configuration.Instance.Configurations["GP_SEC_ACCESS_TOKEN_URL"];
                case "GP_SEC_ACCESS_TOKEN_URL_SET_CULTURE":
                    return Configuration.Instance.Configurations["GP_SEC_ACCESS_TOKEN_URL_SET_CULTURE"];
                case "GP_BASE_URL":
                    return Configuration.Instance.Configurations["GP_BASE_URL"];
                case "GP_BASE_MULE_URL":
                    return Configuration.Instance.Configurations["GP_BASE_MULE_URL"];
                default:
                    return string.Empty;
            }

        }


    }
}
