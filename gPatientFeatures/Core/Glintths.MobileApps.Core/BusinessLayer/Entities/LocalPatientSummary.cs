using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class LocalPatientSummary
    {
        /// <summary>
        /// Id da Linha de Resumo
        /// </summary>
        [DataMember]
        public string SummaryId { get; set; }

        /// <summary>
        /// Id da Linha de resumo na BD
        /// </summary>
        [DataMember]
        public string SummaryDatabaseId { get; set; }

        /// <summary>
        /// Data de registo da informação correspondente à linha
        /// </summary>
        [DataMember]
        public DateTime SummaryDate { get; set; }

        /// <summary>
        /// Data de registo da informação preenchida
        /// </summary>
        [DataMember]
        public bool SummaryDateHasValue { get; set; }

        /// <summary>
        /// Data de resito da informação correspondente à linha formatada como string
        /// </summary>
        [DataMember]
        public string SummaryDateDisplay { get; set; }

        /// <summary>
        /// Categorização do tipo de informação presente na linha de resumo
        /// </summary>
        [DataMember]
        public LocalSummaryType SummaryType { get; set; }

        /// <summary>
        /// Informação do Colaborador (n_mecan; nome)
        /// </summary>
        [DataMember]
        public LocalHumanResource HumanResource { get; set; }

        /// <summary>
        /// Informação recolhida para o item, versão resumida.
        /// </summary>
        [DataMember]
        public string SummaryDigest { get; set; }

        /// <summary>
        /// Indica se o resumo foi totalmente processado ou se ainda existe informação por processar
        /// </summary>
        [DataMember]
        public bool HasMoreSummary { get; set; }

        /// <summary>
        /// Informação completa da obtida da linha
        /// </summary>
        [DataMember]
        public string SummaryFullText { get; set; }

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

        /// <summary>
        /// t_doente onde a informação foi registada
        /// </summary>
        [DataMember]
        public string PatientType { get; set; }

        /// <summary>
        /// doente onde a informação foi registada
        /// </summary>
        [DataMember]
        public string PatientId { get; set; }

        /// <summary>
        /// cod_serv onde a informação foi registada
        /// </summary>
        [DataMember]
        public string ServiceId { get; set; }

        /// <summary>
        /// tipo de linha do resumo
        /// </summary>
        [DataMember]
        public string LineType { get; set; }

        /// <summary>
        /// Campo para ordenação.
        /// </summary>
        [DataMember]
        public string Order { get; set; }
    }
}
