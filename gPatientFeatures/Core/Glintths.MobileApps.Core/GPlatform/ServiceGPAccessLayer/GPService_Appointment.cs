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
using System.Threading;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.GPlatform.ServiceGPAccessLayer
{
    public partial class GPService
    {
        public async Task<ServiceReturn<ScheduledAppointment>> ScheduleAppointmentForUniquePatientAsync(AuthenticationType tipoAuth, string userId, string facilityId, FreeTimeSlot freeTimeSlotLocal, DateTime efrExpDate, string efrCard, string successMessage = "", string errorMessage = "")
        {
            #region uimessage
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "Não foi possível efetuar a marcação.");
            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);
            #endregion

            ScheduledAppointment scheduledAppoint;

            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.AppointmentClient sc = new Generated.AppointmentClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                string group = Configuration.Instance.Configurations["GROUP"];
                Generated.FreeTimeSlot2 freeSlotGP = TranslateFreeTimeSlotLocalToGP(freeTimeSlotLocal);
                int operationTimeOut = 30;
                var res = await sc.ScheduleAppointmentForUniquePatientAsync(freeSlotGP, facilityId, userId, efrCard, efrExpDate, operationTimeOut, GetGPAppVersion());

                if (res != null)
                    scheduledAppoint = TranslateScheduledAppointmentGPToLocal(res.First());
                else
                    throw new Exception();

                return ServiceReturnHandling.BuildSuccessCallReturn<ScheduledAppointment>(scheduledAppoint, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<ScheduledAppointment>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<ScheduledAppointment>> RescheduleAppointmentAsync(AuthenticationType tipoAuth, string userId, string facilityId, FreeTimeSlot freeTimeSlotLocal, Appointment oldApp, string cod_motivo, DateTime efrExpDate, string efrCard, string successMessage = "", string errorMessage = "")
        {
            #region uimessage
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "Não foi possível efetuar a marcação.");
            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);
            #endregion

            ScheduledAppointment scheduledAppoint;

            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.AppointmentClient sc = new Generated.AppointmentClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                var obsFinal = !string.IsNullOrEmpty(freeTimeSlotLocal.Observations) ? freeTimeSlotLocal.Observations : string.Empty;

                var resApp = TranslateFreeTimeSlotLocalToGP(freeTimeSlotLocal);

                var res = await sc.RescheduleAppointmentAsync(resApp, facilityId, oldApp.Id.ToString(), userId, obsFinal, cod_motivo, efrCard, efrExpDate, GetGPAppVersion());

                if (res != null)
                    scheduledAppoint = TranslateScheduledAppointmentGPToLocal(res.First());
                else
                    throw new Exception();

                return ServiceReturnHandling.BuildSuccessCallReturn<ScheduledAppointment>(scheduledAppoint, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<ScheduledAppointment>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<bool>> CancelAppointmentForUniquePatientAsync(AuthenticationType tipoAuth, string facilityId, string apptId, string userID, string cancelObs, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "Não foi possível cancelar a marcação.");
            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.AppointmentClient sc = new Generated.AppointmentClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                //string userID = (User != null && !string.IsNullOrEmpty(User.UserId)) ? User.UserId : string.Empty;
                int operationTimeOut = 30;

                await sc.CancelAppointmentByUniquePatientIdAsync(facilityId, apptId, userID, operationTimeOut, GetGPAppVersion());

                return ServiceReturnHandling.BuildSuccessCallReturn<bool>(true, uiMessages);

            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<bool>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<List<AppRequested>>> GetSchedulingRequestsAsync(AuthenticationType tipoAuth, List<string> userIds, IEnumerable<string> facilityIds, DateTime minDate, DateTime maxDate, int skip, int take, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "Não é possível obter lista de pedidos de marcações");

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            try
            {
                List<AppRequested> appointments = new List<AppRequested>();
                var locIds = facilityIds.Select(x => double.Parse(x)).ToList();

                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.SchedulingRequestClient sc = new Generated.SchedulingRequestClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));

                foreach (var userID in userIds)
                {
                    var result = await sc.GetPendingScheduleByUniquePatientAsync(locIds, Generated.RequestType4.TELEF, userID, skip, take, GetGPAppVersion());

                    if (result != null)
                    {
                        foreach (var item in result)
                        {
                            appointments.Add(TranslateRequestedApptGPToLocal(item, userID));
                        }
                    }
                }

                return ServiceReturnHandling.BuildSuccessCallReturn<List<AppRequested>>(appointments, uiMessages);

            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<List<AppRequested>>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<Dictionary<string, string>>> GetSchedulingIdsAsync(AuthenticationType tipoAuth, List<string> schedulingApptIDs, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "Não é possível obter lista de IDs de pedidos de marcações");

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.SchedulingRequestClient sc = new Generated.SchedulingRequestClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));

                var dicIds = new Dictionary<string, string>();

                foreach (var schedulingApptID in schedulingApptIDs)
                {
                    var appId = await sc.GetAppointmentIdByScheduleRequestAsync(schedulingApptID, GetGPAppVersion());

                    if (!string.IsNullOrEmpty(appId))
                    {
                        dicIds.Add(schedulingApptID, appId);
                    }
                }

                return ServiceReturnHandling.BuildSuccessCallReturn<Dictionary<string, string>>(dicIds, uiMessages);

            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<Dictionary<string, string>>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<bool>> CreateSchedulingRequestAsync(AuthenticationType tipoAuth, string userId, string facilityId, string medActId, string specialityId, string humanResourceId, string observations, DateTime datePref, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "Não é possível criar o pedido de marcação");

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.SchedulingRequestClient sc = new Generated.SchedulingRequestClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                var facilityIdFinal = !string.IsNullOrEmpty(facilityId) ? facilityId : string.Empty;
                var medActIdFinal = !string.IsNullOrEmpty(medActId) ? medActId : string.Empty;
                var specialityIdFinal = !string.IsNullOrEmpty(specialityId) ? specialityId : string.Empty;
                var humanResourceIdFinal = !string.IsNullOrEmpty(humanResourceId) ? humanResourceId : string.Empty;
                var observationsFinal = !string.IsNullOrEmpty(observations) ? observations : string.Empty;

                //var result = await sc.CreateSchedulingRequestAsync(Generated.RequestType.TELEF, User.UserId, facilityIdFinal, medActIdFinal, specialityIdFinal, humanResourceIdFinal, observationsFinal, datePref, GetGPAppVersion());
                var result = await sc.CreateSchedulingRequestAsync(Generated.RequestType3.TELEF, userId, facilityIdFinal, medActIdFinal, specialityIdFinal, humanResourceIdFinal, observationsFinal, datePref, DateTime.Now, string.Empty, string.Empty, GetGPAppVersion());

                return ServiceReturnHandling.BuildSuccessCallReturn<bool>(true, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<bool>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<List<Appointment>>> GetAllPatientAndDescendantsAppointmentsAsync(AuthenticationType tipoAuth, IEnumerable<string> facilityIds, IEnumerable<string> patientIds, DateTime minDate, DateTime maxDate, int skip, int take, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "Não é possível obter lista de marcações");

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            try
            {
                List<Appointment> appointments = null;
                string userID = (User != null && !string.IsNullOrEmpty(User.UserId)) ? User.UserId : string.Empty; // Patient uniqueid??? Validar caso seja anonimo access??

                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.AppointmentClient sc = new Generated.AppointmentClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                Generated.AppointmentFilter filter = new Generated.AppointmentFilter();

                if (facilityIds.Count() > 0)
                    filter.FacilityIds = new ObservableCollection<double>(facilityIds.Select(x => double.Parse(x)));

                filter.DescendantPatientUniqueIds = new ObservableCollection<string>(patientIds);

                var result = await sc.AppointmentsByParentAsync(filter, userID, "true", minDate, maxDate, skip, take, GetGPAppVersion());

                if (result != null)
                {
                    appointments = new List<Appointment>();
                    foreach (var item in result)
                    {
                        appointments.Add(TranslateAppointmentGPToLocal(item));
                    }
                }

                return ServiceReturnHandling.BuildSuccessCallReturn<List<Appointment>>(appointments, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<List<Appointment>>(ex, uiMessages);
            }
        }

        /// <summary>
        /// Este método obtem todas as marcações para um determinado paciente
        /// Na GPatient após a fase "Descendentes" deverá ser chamado o método que obtem as consultas do paciente e dos descendentes
        /// </summary>
        /// <param name="tipoAuth"></param>
        /// <param name="facilityIds"></param>
        /// <param name="minDate"></param>
        /// <param name="maxDate"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="successMessage"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public async Task<ServiceReturn<List<Appointment>>> GetAllAppointmentsAsync(AuthenticationType tipoAuth, IEnumerable<string> facilityIds, DateTime minDate, DateTime maxDate, int skip, int take, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "Não é possível obter lista de marcações");

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            try
            {
                List<Appointment> appointments = null;
                string userID = (User != null && !string.IsNullOrEmpty(User.UserId)) ? User.UserId : string.Empty; // Patient uniqueid??? Validar caso seja anonimo access??

                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.AppointmentClient sc = new Generated.AppointmentClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                var result = await sc.GetAllAppointmentsAsync(facilityIds.Select(x => double.Parse(x)), userID, minDate, maxDate, skip, take, GetGPAppVersion());

                if (result != null)
                {
                    appointments = new List<Appointment>();
                    foreach (var item in result)
                    {
                        appointments.Add(TranslateAppointmentGPToLocal(item));
                    }
                }

                return ServiceReturnHandling.BuildSuccessCallReturn<List<Appointment>>(appointments, uiMessages);

            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<List<Appointment>>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<bool>> IsPatientPresentAsync(AuthenticationType tipoAuth, string _facilityId, string successMessage = "", string errorMessage = "")
        {
            #region uimessage
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "Não foi possivel verificar presença.");
            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);
            #endregion

            bool isPresent = false;

            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.AppointmentClient sc = new Generated.AppointmentClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                //TODO nao existe o metodo IsPatientPresentAsync no AppointmentClient
                //var result = sc.AllApointmentsAsync(userID, facilityIds, minDate.ToString(), maxDate.ToString(), skip, take, GetGPAppVersion());

                //isPresent = result;

                return ServiceReturnHandling.BuildSuccessCallReturn<bool>(isPresent, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<bool>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<bool>> CheckInFromDeviceAsync(AuthenticationType tipoAuth, string _facilityId, string _appointmentId, string successMessage = "", string errorMessage = "")
        {
            #region uimessage
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "Não foi possível efectuar checkin do dispositivo.");
            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);
            #endregion

            bool CheckedIn = false;

            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.AppointmentClient sc = new Generated.AppointmentClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                //TODO nao existe o metodo CheckInFromDevice no AppointmentClient
                //var result = sc.(userID, facilityIds, minDate.ToString(), maxDate.ToString(), skip, take, GetGPAppVersion());

                //CheckedIn = result;

                return ServiceReturnHandling.BuildSuccessCallReturn<bool>(CheckedIn, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<bool>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<bool>> RegistryPatientPresenceByCodeAsync(AuthenticationType tipoAuth, string _checkInCode, string successMessage = "", string errorMessage = "")
        {
            #region uimessage
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "Pin inválido. Por favor tente de novo.");
            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);
            #endregion

            bool CheckedIn = false;

            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.AppointmentProcessingClient sc = new Generated.AppointmentProcessingClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                //TODO nao existe o metodo RegistryPatientPresenceByCode no AppointmentProcessingClient
                //var result = sc. //GetGPAppVersion();

                //CheckedIn = result;

                return ServiceReturnHandling.BuildSuccessCallReturn<bool>(CheckedIn, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<bool>(ex, uiMessages);
            }

        }

        public async Task<ServiceReturn<List<Appointment>>> GetAppointmentByDatesAsync(AuthenticationType tipoAuth, int skip, int take, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
            {
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            }
            else
            {
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "Não é possível obter lista de marcações");
            }

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.AppointmentProcessingClient sc = new Generated.AppointmentProcessingClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                // Nao existe no cliente AppointmentProcessingClient o GetAppointmentByDates .. usar o ALLAppointments?
                //var appts = await sc.(null,null, DateTime.Now.AddYears(-3).ToString(), DateTime.Now.AddYears(3).ToString(), skip, take, GetGPAppVersion());

                List<Appointment> appts = new List<Appointment>();

                foreach (var item in appts)
                {
                    appts.Add(TranslateAppointmentGPToLocal(null));
                }

                return ServiceReturnHandling.BuildSuccessCallReturn<List<Appointment>>(appts, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<List<Appointment>>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<List<Preparation>>> GetPreparationsAfterScheduleAsync(AuthenticationType tipoAuth, string facilityId, string IdAppointment, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "Não é possível obter lista de preparações");

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            List<Preparation> preps = null;

            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.AppointmentClient sc = new Generated.AppointmentClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                var prepIni = await sc.GetPreparationsAfterScheduleAsync(facilityId, IdAppointment, GetGPAppVersion());

                if (prepIni != null)
                {
                    preps = new List<Preparation>();
                    foreach (var item in prepIni)
                    {
                        Preparation prep = TranslatePreparationGPToLocal(item);
                        prep.FacilityId = facilityId; // facility nao vem mapeada.. adicionada manualmente pois é necessária no GetLoadPreparationObjectAsync (obter doc da preparação)
                        preps.Add(prep);
                    }
                }

                return ServiceReturnHandling.BuildSuccessCallReturn<List<Preparation>>(preps, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<List<Preparation>>(ex, uiMessages);
            }
        }

        public async Task<ServiceReturn<Preparation>> GetLoadPreparationObjectAsync(AuthenticationType tipoAuth, Preparation prep, string facilityId, string IdAppointment, string successMessage = "", string errorMessage = "")
        {
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "Não é possível obter lista de preparações");

            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);

            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.AppointmentClient sc = new Generated.AppointmentClient(baseUrl, await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                Generated.Preparation prepGP = TranslatePreparationLocalToGP(prep);
                ObservableCollection<Generated.Preparation> tmp = new ObservableCollection<Generated.Preparation>(new List<Generated.Preparation>() { prepGP });
                var prepFinal = await sc.LoadLocalPreparationsDocumentsAsync(tmp, facilityId, User.UserId, string.Empty, GetGPAppVersion());

                if (prepFinal != null)
                    prep = TranslatePreparationGPToLocal(prepFinal.First());

                return ServiceReturnHandling.BuildSuccessCallReturn<Preparation>(prep, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<Preparation>(ex, uiMessages);
            }
        }

        private Preparation TranslatePreparationGPToLocal(Generated.Preparation prepGP)
        {
            Preparation prepLocal = new Preparation();
            try
            {
                if (prepGP != null)
                {
                    prepLocal.Description = prepGP.Description;
                    prepLocal.DescriptionAbbreviation = prepGP.DescriptionAbbreviation;
                    prepLocal.IsPreparation = prepGP.IsPreparation.HasValue ? prepGP.IsPreparation.Value : true;
                    prepLocal.LocalEpisodeType = prepGP.LocalEpisodeType;
                    prepLocal.LocalEpisodeId = prepGP.LocalEpisodeId;
                    prepLocal.LocalServiceId = prepGP.LocalServiceId;
                    prepLocal.NumCopies = prepGP.NumCopies.HasValue ? prepGP.NumCopies.Value : 1;
                    prepLocal.PreparationDocumentLoaded = prepGP.PreparationDocumentLoaded.HasValue ? prepGP.PreparationDocumentLoaded.Value : false;
                    prepLocal.PreparationDocument = prepGP.PreparationDocument;
                    prepLocal.Template = prepGP.Template;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro a realizar o convert de Preparation (GP) para Preparation (local)");
            }

            return prepLocal;
        }

        private Generated.Preparation TranslatePreparationLocalToGP(Preparation prepLocal)
        {
            Generated.Preparation prepGP = new Generated.Preparation();
            try
            {
                if (prepLocal != null)
                {
                    prepGP.Description = prepLocal.Description;
                    prepGP.DescriptionAbbreviation = prepLocal.DescriptionAbbreviation;
                    prepGP.IsPreparation = prepLocal.IsPreparation;
                    prepGP.LocalEpisodeType = prepLocal.LocalEpisodeType;
                    prepGP.LocalEpisodeId = prepLocal.LocalEpisodeId;
                    prepGP.LocalServiceId = prepLocal.LocalServiceId;
                    prepGP.NumCopies = prepLocal.NumCopies;
                    prepGP.PreparationDocumentLoaded = prepLocal.PreparationDocumentLoaded;
                    prepGP.PreparationDocument = prepLocal.PreparationDocument;
                    prepGP.Template = prepLocal.Template;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro a realizar o convert de Preparation (Local) para Preparation (GP)");
            }

            return prepGP;
        }

        public BusinessLayer.Entities.FreeTimeSlot TranslateFreeTimeSlotGPToLocal(Generated.FreeTimeSlot2 freeSlotGP)
        {
            FreeTimeSlot freeSlotLocal = new FreeTimeSlot();
            try
            {
                if (freeSlotGP != null)
                {
                    freeSlotLocal.Begin = freeSlotGP.StartDate.HasValue ? freeSlotGP.StartDate.Value : DateTime.Today; // necessario validar este campo..colocada data de hoje
                    freeSlotLocal.End = freeSlotGP.EndDate.HasValue ? freeSlotGP.EndDate.Value : DateTime.Today;
                    freeSlotLocal.HumanResourceId = (int)freeSlotGP.HumanResourceId;
                    freeSlotLocal.Id = freeSlotGP.FreeTimeSlotId;
                    //freeSlotLocal.ClinicalServiceId = freeSlotGP.;
                    freeSlotLocal.MedicalActCode = freeSlotGP.MedicalActId.ToString();
                    freeSlotLocal.CabinetId = freeSlotGP.LocalCabinetId;
                    freeSlotLocal.ScheduleId = freeSlotGP.LocalScheduleId;
                    //freeSlotLocal.PersonnelNumber = freeSlotGP.;
                    freeSlotLocal.FacilityId = (int)freeSlotGP.FacilityId;
                    //freeSlotLocal.Group = freeSlotGP.;
                    freeSlotLocal.Duration = freeSlotGP.Duration.HasValue ? freeSlotGP.Duration.Value : new DateTime();
                    freeSlotLocal.FirstTimeFlag = freeSlotGP.IsFirstTime.HasValue ? freeSlotGP.IsFirstTime.Value : false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro a realizar o convert de FreeTimeSlot (GP) para FreeTimeSlot (local)");
            }

            return freeSlotLocal;
        }

        public Generated.FreeTimeSlot2 TranslateFreeTimeSlotLocalToGP(BusinessLayer.Entities.FreeTimeSlot freeSlotLocal)
        {
            try
            {
                if (freeSlotLocal != null)
                {
                    Generated.FreeTimeSlot2 freeSlotGP = new Generated.FreeTimeSlot2()
                    {
                        Observations = freeSlotLocal.Observations,
                        LocalScheduleId = freeSlotLocal.ScheduleId,
                    };

                    if (freeSlotLocal.Id != null && freeSlotLocal.Id != string.Empty)
                        freeSlotGP.FreeTimeSlotId = freeSlotLocal.Id.ToString();

                    if (freeSlotLocal.FacilityId != null && freeSlotLocal.FacilityId != 0)
                        freeSlotGP.FacilityId = (double)freeSlotLocal.FacilityId;

                    if (freeSlotLocal.FinancialEntityCode != null && freeSlotLocal.FinancialEntityCode != 0)
                        freeSlotGP.FinancialEntityId = (double)freeSlotLocal.FinancialEntityCode;

                    if (freeSlotLocal.HumanResourceId != null && freeSlotLocal.HumanResourceId != 0)
                        freeSlotGP.HumanResourceId = (double)freeSlotLocal.HumanResourceId;

                    if (!string.IsNullOrEmpty(freeSlotLocal.MedicalActCode))
                        freeSlotGP.MedicalActId = double.Parse(freeSlotLocal.MedicalActCode);

                    return freeSlotGP;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro a realizar o convert de FreeTimeSlot (local) para FreeTimeSlot (GP)");
            }

            return null;
        }

        public BusinessLayer.Entities.ScheduledAppointment TranslateScheduledAppointmentGPToLocal(Generated.ScheduleAppointment schGP)
        {
            ScheduledAppointment schLocal = new ScheduledAppointment();
            try
            {
                if (schGP != null)
                {
                    schLocal.FacilityId = schGP.FacilityId;
                    schLocal.Id = schGP.ScheduleId;
                    schLocal.PreparationDocuments = schGP.PreparationDocuments.ToList<string>();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro a realizar o convert de ScheduleAppointment (GP) para ScheduledAppointment (local)");
            }

            return schLocal;
        }

        private BusinessLayer.Entities.AppRequested TranslateRequestedApptGPToLocal(Generated.SchedulingRequest2 apptGP, string userId)
        {
            AppRequested apptLocal = new AppRequested();
            try
            {
                if (apptGP != null)
                {
                    apptLocal.Id = Int32.Parse(apptGP.Number);
                    apptLocal.PatientId = userId;
                    apptLocal.Observations = apptGP.Observation;
                    apptLocal.ActMedType = MedicalActType.OutPatientConsult;
                    apptLocal.FinaltialEntityId = apptGP.FinancialEntityId;
                    apptLocal.AppointmentId = apptGP.AppointmentLocalId;
                    apptLocal.Date = apptGP.RequestDate.HasValue ? apptGP.RequestDate.Value : DateTime.Now;
                    apptLocal.DatePrefered = apptGP.RequestedDate.HasValue ? apptGP.RequestedDate.Value : DateTime.Now;
                    apptLocal.HumanResourceId = apptGP.HumanResourceId;
                    apptLocal.FacilityId = (int)apptGP.FacilityId;
                    apptLocal.FinaltialEntityDescr = "";
                    apptLocal.HumanResourceTitle = string.Empty;
                    apptLocal.HumanResourceDescription = "";
                    apptLocal.MedicalActDescription = "";
                    apptLocal.OfficeCode = string.Empty;
                    apptLocal.OfficeDescription = string.Empty;
                    apptLocal.MedicalActId = apptGP.MedicalActId;
                    apptLocal.RubricId = string.Empty;
                    apptLocal.SpecialityDescription = "";
                    apptLocal.StatusCTH_Code = apptGP.State;
                    apptLocal.SpecialityId = apptGP.ServiceId;
                    apptLocal.Status = AppRequested.ConvertAppRequestedStatus(apptGP.State);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro a realizar o convert de RequestedAppts (GP) para RequestedAppts (local)");
            }

            return apptLocal;

        }

        private Appointment TranslateAppointmentGPToLocal(Generated.Appointment2 apptGP)
        {
            Appointment apptLocal = new Appointment();
            try
            {
                if (apptGP != null)
                {
                    apptLocal.LocalPatientId = apptGP.PatientUniqueId;
                    apptLocal.Date = apptGP.Date.HasValue && apptGP.Hour.HasValue ? new DateTime(apptGP.Date.Value.Year, apptGP.Date.Value.Month, apptGP.Date.Value.Day, apptGP.Hour.Value.Hour, apptGP.Hour.Value.Minute, 0) : DateTime.Today; // Dia e Hora obtidos de campos diferentes
                    apptLocal.EndDate = apptGP.Date.HasValue ? apptGP.Date.Value : DateTime.Today;
                    apptLocal.FinaltialEntity = new FinancialEntity()
                    {
                        FinancialEntityId = (int)apptGP.FinancialEntityId,
                    };
                    apptLocal.FirstTimeFlag = apptGP.IsFirstTime.HasValue ? apptGP.IsFirstTime.Value : false;
                    apptLocal.HumanResourceDescription = "";
                    apptLocal.HumanResourceId = Int32.Parse(apptGP.HumanResourceId);
                    apptLocal.HumanResourceTitle = "";
                    apptLocal.Id = Int32.Parse(apptGP.AppointmentId);
                    apptLocal.MedicalActId = Int32.Parse(apptGP.MedicalActId);
                    apptLocal.MedicalActDescription = "";
                    apptLocal.Status = Appointment.ConvertLocalAppointmentStatus(apptGP.Status);
                    apptLocal.FacilityId = (int)apptGP.FacilityId;
                    apptLocal.ActMedType = MedicalActType.OutPatientConsult;
                    apptLocal.SpecialityDescription = "";
                    apptLocal.SpecialityId = Int32.Parse(apptGP.SpecialityId);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro a realizar o convert de AppointmentCore (GP) para Appointment (local)");
            }

            return apptLocal;
        }

    }

}
