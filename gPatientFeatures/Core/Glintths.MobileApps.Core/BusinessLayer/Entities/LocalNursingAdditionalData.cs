using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class LocalNursingAdditionalData
    {
        /// <summary>
        /// NOME_PREF
        /// </summary>
        [DataMember]
        public string Pref_Name { get; set; }

        /// <summary>
        /// MOTIVO_INTERNAMENTO
        /// </summary>
        [DataMember]
        public string Hosp_Reason { get; set; }

        /// <summary>
        /// ANOTACOES
        /// </summary>
        [DataMember]
        public string Annotations { get; set; }

        /// <summary>
        /// TRANSFERENCIAS
        /// </summary>
        [DataMember]
        public string Transfers { get; set; }

        /// <summary>
        /// ENF_RES
        /// </summary>      
        public string Nurse_Resp { get; set; }

        /// <summary>
        /// KIT
        /// </summary>
        [DataMember]
        public string KIT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string UserCri { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string UserAct { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime? DtCri { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime? DtAct { get; set; }

        /// <summary>
        /// COD_DIETA
        /// </summary>
        [DataMember]
        public string Diet_Cod { get; set; }

        /// <summary>
        /// DESCR_DIETA
        /// </summary>
        [DataMember]
        public string Diet_Descr { get; set; }

        /// <summary>
        /// KIT_DESC
        /// </summary>
        [DataMember]
        public string KIT_Desc { get; set; }

        /// <summary>
        /// KIT_TIPO
        /// </summary>
        [DataMember]
        public string KIT_Type { get; set; }

        /// <summary>
        /// KIT_DT
        /// </summary>
        [DataMember]
        public DateTime? KIT_Date { get; set; }
    }
}
