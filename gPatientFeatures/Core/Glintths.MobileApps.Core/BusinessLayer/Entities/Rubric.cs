using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class Rubric
    {
        /// <summary>
        /// Agrupador de Unidades Hospitalares
        /// </summary>
        public const string DP_LOCALRUBRICS = "DP_LOCALRUBRICS";

        [DataMember]
        public string Group { get; set; }
        [DataMember]
        public string RubricId { get; set; }
        [DataMember]
        public string RubricCode { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public bool Schedulable { get; set; }
        [DataMember]
        public bool Requestable { get; set; }
        [DataMember]
        public COEntityStatus Status { get; set; }
        [DataMember]
        public bool Visible { get; set; }

        [DataMember]
        public List<LocalRubric> LocalRubrics { get; set; }

        [DataMember]
        public List<LocalMedicalAct> LocalMedicalActs { get; set; }

        /*[DataMember]
        public long SCN { get; set; }*/
    }

    [DataContract]
    public class LocalRubric
    {
        /// <summary>
        /// Agrupador de Unidades Hospitalares
        /// </summary>
        [DataMember]
        public string Group { get; set; }
        [DataMember]
        public string FacilityId { get; set; }

        [DataMember]
        public string RubricCode { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string RubricGroup { get; set; }

        [DataMember]
        public bool Schedulable { get; set; }
        [DataMember]
        public bool Requestable { get; set; }

        [DataMember]
        public LocalEntityStatus EntityStatus { get; set; }

        [DataMember]
        public RelationshipEntityStatus RelationshipStatus { get; set; }

    }
}
