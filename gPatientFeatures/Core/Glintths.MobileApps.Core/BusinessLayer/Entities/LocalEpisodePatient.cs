using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class LocalEpisodePatient
    {
        /// <summary>
        /// t_episodio onde a informação foi registada
        /// </summary>
        [DataMember]
        public string EpisodeType { get; set; }

        /// <summary>
        /// episodio onde a informação foi registada
        /// </summary>
        [DataMember]
        public string EpisodeId { get; set; }

        [DataMember]
        public DateTime Data { get; set; }

        [DataMember]
        public DateTime Hora { get; set; }

        [DataMember]
        public bool HasDuration { get; set; }

        [DataMember]
        public DateTime Duration { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string N_Mecan { get; set; }

        [DataMember]
        public LocalPatientData Doente { get; set; }

        [DataMember]
        public string Photo { get; set; }
    }
}
