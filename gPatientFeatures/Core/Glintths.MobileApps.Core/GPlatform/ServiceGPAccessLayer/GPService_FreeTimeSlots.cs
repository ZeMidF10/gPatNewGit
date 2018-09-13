using Glintths.MobileApps.Core.BusinessLayer.Entities;
using Glintths.MobileApps.Core.ServiceAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.GPlatform.ServiceGPAccessLayer
{
    public partial class GPService
    {
        public async Task<ServiceReturn<List<FreeTimeSlot>>> GetFreeTimeSlotsAsync(AuthenticationType tipoAuth,string facilityId, string specialtyId, string medicalActId, string humanResourceId, DateTime beginDate, DateTime endDate, List<DayOfWeek> daysOfWeek, List<int> hours, string efrId, string successMessage = "", string errorMessage = "")
        {

            #region uimessage
            var uiMessages = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(errorMessage))
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, errorMessage);
            else
                uiMessages.Add(ServiceReturnHandling.GenericMessageKey, "Não foi possível obter vagas.");
            if (!string.IsNullOrEmpty(successMessage))
                uiMessages.Add(ServiceReturnHandling.SuccessMessageKey, successMessage);
            #endregion

            List<FreeTimeSlot> freeTimeSlots = null;

            try
            {
                string baseUrl = await CommunicationManager.ServiceManager.GetServiceEndpoint("GP_BASE_URL");
                Generated.FreeTimeSlotsClient sc = new Generated.FreeTimeSlotsClient(baseUrl,  await CommunicationManager.Instance.GetHttpClientWithToken(tipoAuth, new HttpClient()));
                string user = (this.User != null && !string.IsNullOrEmpty(User.UserId)) ? User.UserId : string.Empty;
                Generated.FreeTimeSlotsFilter filter = new Generated.FreeTimeSlotsFilter()
                {
                    BeginDate = beginDate,
                    EndDate = endDate,
                    HumanResourceId = humanResourceId,
                    FinancialEntityId = efrId,
                    MedicalActId = medicalActId,
                    SpecialityId = specialtyId,
                    FacilityId = facilityId,
                    PatientUniqueId = user,
                };

                var result = await sc.SearchFreeTimeSlotsAsync(filter, GetGPAppVersion());

                if (result != null)
                {
                    freeTimeSlots = new List<FreeTimeSlot>();
                    foreach (var item in result)
                    {
                        if (item.HumanResourceId != null)
                            freeTimeSlots.Add(TranslateFreeTimeSlotGPToLocal(item));
                    }

                    if (daysOfWeek != null && daysOfWeek.Count > 0)
                    {
                        freeTimeSlots = freeTimeSlots.Where(x => daysOfWeek.Contains(x.Begin.DayOfWeek)).ToList();
                    }
                    if (hours != null && hours.Count > 0)
                    {
                        freeTimeSlots = freeTimeSlots.Where(x => hours.Contains(x.Begin.Hour)).ToList();
                    }
                    //retorna apenas a primeira vaga por slot para os médicos
                    //as slots têm de ser sempre horas 
                    if (freeTimeSlots.Count > 1)
                    {
                        List<FreeTimeSlot> ret = new List<FreeTimeSlot>();
                        foreach (var slotsGroup in freeTimeSlots.GroupBy(x => new { x.HumanResourceId, x.Begin.Date, x.Begin.Hour }))
                        {
                            ret.Add(slotsGroup.OrderBy(x => x.Begin).First());
                        }
                        freeTimeSlots = ret;
                    }
                }

                return ServiceReturnHandling.BuildSuccessCallReturn<List<FreeTimeSlot>>(freeTimeSlots, uiMessages);
            }
            catch (Exception ex)
            {
                return ServiceReturnHandling.HandleException<List<FreeTimeSlot>>(ex, uiMessages);
            }
        }

    }
}
