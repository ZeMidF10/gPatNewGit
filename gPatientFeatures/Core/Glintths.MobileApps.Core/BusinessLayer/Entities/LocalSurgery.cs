using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    public class LocalSurgery
    {
        /*
        public const string DoctorName = "DOCTORNAME";
        public const string PatientName = "PATIENTNAME";
        public const string SurgeryDate = "SURGERYDATE";
        public const string SurgeryName = "SURGERYNAME";
        */

        public DateTime? AdmissionTrackingHr { get; set; }
        public string AdmissionTrackingState { get; set; }
        public DateTime? AfterSurgeryTrackingHr { get; set; }
        public string AfterSurgeryTrackingState { get; set; }
        public LocalSurgeryAnesthesia Anesthesia { get; set; }
        public DateTime? CallPatientTrackingHr { get; set; }
        public string CallPatientTrackingState { get; set; }
        public LocalEpisode Episode { get; set; }
        public DateTime? ExitSurgeryTrackingHr { get; set; }
        public string ExitSurgeryTrackingState { get; set; }
        public DateTime? HrAnestesiaEnd { get; set; }
        public DateTime? HrAnestesiaInit { get; set; }
        public DateTime? HrBlockEntry { get; set; }
        public DateTime? HrBlockExit { get; set; }
        public DateTime? HrCallPatient { get; set; }
        public DateTime? HrCirurgEnd { get; set; }
        public DateTime? HrCirurgInit { get; set; }
        public DateTime? HrPreRoomEntry { get; set; }
        public DateTime? HrPreRoomExit { get; set; }
        public DateTime? HrRecoverEnd { get; set; }
        public DateTime? HrRecoverInit { get; set; }
        public DateTime? HrReport { get; set; }
        public DateTime? HrReportAct { get; set; }
        public DateTime? HrReportAss { get; set; }
        public DateTime? HrRoomEntry { get; set; }
        public DateTime? HrRoomExit { get; set; }
        public LocalSurgeryLaterality Laterality { get; set; }
        public LocalPatient Patient { get; set; }
        public DateTime? PreSurgeryTrackingHr { get; set; }
        public string PreSurgeryTrackingState { get; set; }
        public string ReportState { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public LocalHumanResource Surgeon { get; set; }
        public string SurgeryBlockDescr { get; set; }
        public string SurgeryProcedure { get; set; }
        public DateTime? SurgeryReportTrackingHr { get; set; }
        public string SurgeryReportTrackingState { get; set; }
        public LocalSurgeryServ SurgeryServ { get; set; }
        public LocalSurgerySpecialty SurgerySpeciality { get; set; }
        public DateTime? SurgeryTrackingHr { get; set; }
        public string SurgeryTrackingState { get; set; }
        public string SurgeryType { get; set; }
        public LocalSurgeryWing Wing { get; set; }
    }
}
