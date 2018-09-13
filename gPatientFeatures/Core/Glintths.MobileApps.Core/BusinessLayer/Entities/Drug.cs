using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    // Summary:
    //     PH_MEDICAMENTO
    [DataContract]
    public class Drug
    {
        [DataMember]
        public string ABC { get; set; }
        [DataMember]
        public bool AmbulatorySurgeryDrug { get; set; }
        [DataMember]
        public string ArticleType { get; set; }
        [DataMember]
        public string ATCCode { get; set; }
        [DataMember]
        public string AveragePrice { get; set; }
        [DataMember]
        public bool Biologic { get; set; }
        [DataMember]
        public string Brand { get; set; }
        [DataMember]
        public string BrandCode { get; set; }
        [DataMember]
        public string CapacityUnit { get; set; }
        [DataMember]
        public bool ChangeNursingDose { get; set; }
        [DataMember]
        public bool Characterized { get; set; }
        [DataMember]
        public decimal? CHNM { get; set; }
        [DataMember]
        public decimal CHNMFactor { get; set; }
        [DataMember]
        public bool ClinicalTest { get; set; }
        [DataMember]
        public string ComercialName { get; set; }
        [DataMember]
        public string ConservType { get; set; }
        [DataMember]
        public short? DaysNumber { get; set; }
        [DataMember]
        public bool DomicileTest { get; set; }
        [DataMember]
        public decimal? DosePoss { get; set; }
        [DataMember]
        public decimal? DrugDose { get; set; }
        [DataMember]
        public string DrugMasc { get; set; }
        [DataMember]
        public decimal DrugUniqueId { get; set; }
        [DataMember]
        public string EndInt { get; set; }
        [DataMember]
        public bool EnteralFeeding { get; set; }
        [DataMember]
        public string Excipient { get; set; }
        [DataMember]
        public string ExtName { get; set; }
        [DataMember]
        public string Family { get; set; }
        [DataMember]
        public string FamilyCode { get; set; }
        [DataMember]
        public bool FixePVFlag { get; set; }
        [DataMember]
        public string Form { get; set; }
        [DataMember]
        public string FormDescription { get; set; }
        [DataMember]
        public bool Frequency { get; set; }
        [DataMember]
        public bool GenericArt { get; set; }
        [DataMember]
        public string GR_ANAT { get; set; }
        [DataMember]
        public string GR_QUIM { get; set; }
        [DataMember]
        public string GR_QUIM_TR { get; set; }
        [DataMember]
        public string GRTA { get; set; }
        //
        // Summary:
        //     MEDICAMENTO
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string IGIF { get; set; }
        [DataMember]
        public bool IGInterFlag { get; set; }
        [DataMember]
        public string IndexValBrand { get; set; }
        [DataMember]
        public string IndexValDci { get; set; }
        [DataMember]
        public bool IsEnteric { get; set; }
        [DataMember]
        public bool IsFree { get; set; }
        [DataMember]
        public string IVA { get; set; }
        [DataMember]
        public bool IvaDeductibleFlag { get; set; }
        [DataMember]
        public decimal? IvaDeductibleTax { get; set; }
        [DataMember]
        public short? MaxDose { get; set; }
        [DataMember]
        public bool MedicalDevice { get; set; }
        [DataMember]
        public string MedType { get; set; }
        [DataMember]
        public string NarcoticId { get; set; }
        [DataMember]
        public bool NeedCalendary { get; set; }
        [DataMember]
        public bool NeedPrescDrugObservation { get; set; }
        [DataMember]
        public bool NeedPrescribedBrand { get; set; }
        [DataMember]
        public bool NotUseCapacity { get; set; }
        [DataMember]
        public string Observations { get; set; }
        [DataMember]
        public decimal? PrescDose { get; set; }
        [DataMember]
        public string PrescFrequency { get; set; }
        [DataMember]
        public string PrescUnitDose { get; set; }
        [DataMember]
        public string PresentationKind { get; set; }
        [DataMember]
        public bool ProtocolPrescrDrug { get; set; }
        [DataMember]
        public string ScientificAbbreviation { get; set; }
        [DataMember]
        public string ScientificName { get; set; }
        [DataMember]
        public bool SIT_MOVI { get; set; }
        [DataMember]
        public bool SMOVFlag { get; set; }
        [DataMember]
        public string Source { get; set; }
        [DataMember]
        public bool SpecialDrug { get; set; }
        [DataMember]
        public string Stability { get; set; }
        [DataMember]
        public bool Sterilizable { get; set; }
        [DataMember]
        public bool Stockable { get; set; }
        [DataMember]
        public string SubGRTA { get; set; }
        [DataMember]
        public bool TecHelps { get; set; }
        [DataMember]
        public decimal? TemporalStability { get; set; }
        [DataMember]
        public string Time { get; set; }
        [DataMember]
        public bool TraditionalFlag { get; set; }
        [DataMember]
        public string UnitTemporalStability { get; set; }
        [DataMember]
        public bool Use { get; set; }
        [DataMember]
        public bool ValidatePrescription { get; set; }
        [DataMember]
        public decimal? VPPrice { get; set; }
    }
}
