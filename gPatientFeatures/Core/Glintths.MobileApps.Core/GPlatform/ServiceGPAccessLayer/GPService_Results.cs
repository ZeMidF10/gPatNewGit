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
        public async Task<ServiceReturn<List<LocalFinancialDocument>>> GetFinancialDocumentsAsync(AuthenticationType tipoAuth, List<string> userIds, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.FailGetResultsList);

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            List<LocalFinancialDocument> documentsLocal = new List<LocalFinancialDocument>();

            try
            {
                DateTime startDate = DateTime.MinValue;
                DateTime endDate = DateTime.Today.AddDays(1);

                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.FinancialClient sc = new Generated.FinancialClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));

                //foreach (var item in userIds)
                //{
                var result = await sc.GetFinancialDocuments2Async(userIds, startDate, endDate, 0, 100, GetGPAppVersion());

                if (result != null)
                {
                    foreach (var resGP in result)
                        documentsLocal.Add(TranslateFinancialDocumentGPToLocal(resGP, userIds));
                }
                //}

                return ServiceReturnHandling.BuildSuccessCallReturn<List<LocalFinancialDocument>>(documentsLocal, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<List<LocalFinancialDocument>>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<List<ResultDocument>>> GetResultsAsync(AuthenticationType tipoAuth, List<string> userIds, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.FailGetResultsList);

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            List<ResultDocument> resultsLocal = new List<ResultDocument>();

            try
            {
                DateTime startDate = DateTime.MinValue;
                DateTime endDate = DateTime.Today.AddDays(1);

                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.ResultsClient sc = new Generated.ResultsClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));

                foreach (var item in userIds)
                {
                    var result = await sc.GetResultsAsync(item, startDate, endDate, false, 0, 100, GetGPAppVersion());

                    if (result != null)
                    {
                        foreach (var resGP in result)
                            resultsLocal.Add(TranslateResultDocumentGPToLocal(resGP,item));
                    }
                }

                return ServiceReturnHandling.BuildSuccessCallReturn<List<ResultDocument>>(resultsLocal, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<List<ResultDocument>>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<ResultDocumentFile>> GetResultDocumentFileAsync(AuthenticationType tipoAuth, string IdDocument, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.FailGetResults);

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            ResultDocumentFile res;
            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.ResultsClient sc = new Generated.ResultsClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                var result = await sc.GetResultFile2Async(IdDocument, GetGPAppVersion());

                res = TranslateResultDocumentFileGPToLocal(result);

                return ServiceReturnHandling.BuildSuccessCallReturn<ResultDocumentFile>(res, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<ResultDocumentFile>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<bool>> ShareResultDocumentFileAsync(AuthenticationType tipoAuth, List<string> emails, List<string> IdDocumentList, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.FailGetResults);

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            bool res;

            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.SyncronizingClient sc = new Generated.SyncronizingClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));

                Generated.ShareResultsFilter filter = new Generated.ShareResultsFilter();
                filter.DocumentIds = new System.Collections.ObjectModel.ObservableCollection<string>(IdDocumentList);
                filter.Emails = new System.Collections.ObjectModel.ObservableCollection<string>(emails);

                var result = await sc.ShareResultsAsync(filter, User.UserId, "Documento", GetGPAppVersion());

                res = true; // checkar return?

                return ServiceReturnHandling.BuildSuccessCallReturn<bool>(res, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<bool>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<bool>> SyncRelatsPacsShareImageAsync(AuthenticationType tipoAuth, List<string> emails, List<string> idDocuments, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, AppResources.FailGetResults);

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            bool res;

            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.SyncronizingClient sc = new Generated.SyncronizingClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));

                // Neste momento só permite partilhar 1 doc/img de cada vez
                var idDocument = idDocuments.FirstOrDefault();
                var emailsConcat = string.Empty;

                foreach (var email in emails)
                    emailsConcat += email + ";";

                if (!string.IsNullOrEmpty(emailsConcat) && emailsConcat.Length > 0)
                    emailsConcat.Remove(emailsConcat.Length - 1);

                var result = await sc.SyncRelatsPacsShareImageAsync(idDocument, emailsConcat, GetGPAppVersion());

                res = true; // checkar return?

                return ServiceReturnHandling.BuildSuccessCallReturn<bool>(res, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<bool>(ex, uiMessages);
            }
        }

        public BusinessLayer.Entities.ResultDocumentFile TranslateResultDocumentFileGPToLocal(Generated.ResultDocumentFile gpRes)
        {
            ResultDocumentFile localRes = new ResultDocumentFile();
            try
            {
                if (gpRes != null)
                {
                    localRes.IdDocument = gpRes.DocumentId;
                    localRes.MimeType = gpRes.MimeType;
                    localRes.File = gpRes.File;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro a realizar o convert de ResultDocumentFile");
                return localRes;
            }

            return localRes;
        }

        public BusinessLayer.Entities.LocalFinancialDocument TranslateFinancialDocumentGPToLocal(Generated.FinancialDocument2 gpDoc, List<string> userIds)
        {
            LocalFinancialDocument localDoc = new LocalFinancialDocument();
            try
            {
                if (gpDoc != null)
                {
                    localDoc.FacilityId = Int32.Parse(gpDoc.FacilityId);
                    localDoc.AmountPendingPayment = gpDoc.AmountPendingPayment.HasValue ? ((decimal)gpDoc.AmountPendingPayment.Value) : 0M;
                    localDoc.Date = gpDoc.Date.HasValue ? gpDoc.Date.Value : DateTime.Now;
                    localDoc.DocNumber = gpDoc.DocNumber;
                    localDoc.IdDocument = gpDoc.DocumentId;
                    localDoc.IdPatient = gpDoc.PatientId;
                    localDoc.LastUpdateDate = gpDoc.LastUpdateDate.HasValue ? gpDoc.LastUpdateDate.Value : DateTime.Now;
                    localDoc.SCN = gpDoc.SCN;
                    localDoc.DocumentStatus = gpDoc.DocumentStatus;
                    localDoc.Value = gpDoc.Value.HasValue ? ((decimal)gpDoc.Value.Value) : 0M;
                }

                if(gpDoc.PaymentData != null)
                {
                    localDoc.PaymentData = new PaymentReference();
                    localDoc.PaymentData.Amount = gpDoc.PaymentData.Amount.HasValue ? ((decimal)gpDoc.PaymentData.Amount.Value) : 0M;
                    localDoc.PaymentData.EntityCode = gpDoc.PaymentData.EntityCode;
                    localDoc.PaymentData.Reference = gpDoc.PaymentData.Reference;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro a realizar o convert de FinancialDocument");
                return localDoc;
            }

            return localDoc;
        }

        public BusinessLayer.Entities.ResultDocument TranslateResultDocumentGPToLocal(Generated.ResultDocument gpRes, string patientId)
        {
            ResultDocument localRes = new ResultDocument();
            try
            {
                if (gpRes != null)
                {
                    localRes.CentralType = gpRes.CentralType;
                    localRes.DocumentDate = gpRes.DocumentDate.HasValue ? gpRes.DocumentDate.Value : DateTime.Now;

                    List<EpisodeData> eps = new List<EpisodeData>();
                    foreach (var item in gpRes.Episodes)
                        eps.Add(TranslateEpisodeDataGPToLocal(item));
                    localRes.Episodes = eps;

                    localRes.FacilityId = gpRes.FacilityId;
                    localRes.PatientId = patientId;
                    localRes.FileName = gpRes.FileName;
                    localRes.IdDocument = gpRes.IdDocument.HasValue ? gpRes.IdDocument.Value.ToString() : "0";
                    localRes.IdPatient = gpRes.IdPatient;
                    localRes.MimeType = gpRes.MimeType;
                    localRes.OriginDescription = gpRes.OriginDescription;
                    localRes.OriginId = gpRes.OriginId;
                    localRes.Restrict = gpRes.Restrict.HasValue ? gpRes.Restrict.Value : false;
                    localRes.SCN = gpRes.SCN.HasValue ? gpRes.SCN.Value.ToString() : "0";
                    localRes.TypeDescription = gpRes.TypeDescription;
                    localRes.TypeId = gpRes.TypeId;
                    localRes.UrlFile = gpRes.UrlFile;
                    localRes.HasImage = gpRes.HasImage.HasValue ? gpRes.HasImage.Value : false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro a realizar o convert de ResultDocument");
                return localRes;
            }

            return localRes;
        }

        public BusinessLayer.Entities.EpisodeData TranslateEpisodeDataGPToLocal(Generated.ResultEpisodeData gpRes)
        {
            EpisodeData localRes = new EpisodeData();
            try
            {
                if (gpRes != null)
                {
                    localRes = new EpisodeData(); // Objecto local não tem atributos
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro a realizar o convert de EpisodeData");
                return localRes;
            }

            return localRes;
        }


    }
}
