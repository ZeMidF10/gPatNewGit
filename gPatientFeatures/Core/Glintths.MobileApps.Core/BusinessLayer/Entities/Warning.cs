using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    public class Warning
    {
        public string AppointmentId;
        public string Description;
        //public WarningAction action;
        public string Action;
        public System.DateTime BeginDate;
        public string Content;
        public System.DateTime EndDate;
        public string FacilityId;
        public string Filepath;
        public FinancialEntity FinancialEntity;
        public string FinancialEntityGroup;
        public HumanResource Humanresource;
        //public Medicalactivitycore Medicalact;
        public MedicalAct MedicalAct;
        public Rubric Rubric;
        public Specialty Specialty;
        public string Title;
        public Double? WarningCode;
        public Double? WarningId;
        //public Warningtype Warningtype;
        public string WarningType;
        public Double? Version;
        public string Status;
    }
}
