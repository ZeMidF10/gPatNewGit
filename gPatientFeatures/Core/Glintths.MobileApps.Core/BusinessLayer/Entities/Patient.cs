using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{

    [DataContract]
    public class PatientToFacilityAssoc
    {
        [DataMember]
        public string IdNumber { get; set; } //BI

        [DataMember]
        public int FacilityId { get; set; }

        [DataMember]
        public string LocalPatientType { get; set; } //t_doente
        [DataMember]
        public string LocalPatientId { get; set; } //doente


    }

    [DataContract]
    public class Patient
    {
        public const string DeepPropertyLocalPatUniqueAss = "LocalPatUniqueAss";

        [DataMember]
        public string PatientUniqueId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public DateTime BirthDate { get; set; }
        //[DataMember]
        //public int? Age { get; set; }
        [DataMember]
        public string BirthCountryId { get; set; }
        [DataMember]
        public string BirthSubDistrictId { get; set; } //concelho
        [DataMember]
        public string Street { get; set; } //morada
        [DataMember]
        public string PostalCode { get; set; }
        //[DataMember]
        //public int? NSeqPostalCode { get; set; }
        [DataMember]
        public string City { get; set; } //localidade
        [DataMember]
        public string CountryId { get; set; }
        [DataMember]
        public string DistrictId { get; set; } //distrito
        [DataMember]
        public string SubDistrictId { get; set; } //concelho
        [DataMember]
        public string VillageId { get; set; } //freguesia
        [DataMember]
        public string PhoneNumber1 { get; set; }
        [DataMember]
        public string PhoneNumber2 { get; set; }
        [DataMember]
        public string Sex { get; set; }
        [DataMember]
        public string IdNumber { get; set; } //BI
        [DataMember]
        public string IdNumberArchive { get; set; } //arquivo
        [DataMember]
        public string NSns { get; set; }
        [DataMember]
        public string TaxIdNumber { get; set; } //NIF
        [DataMember]
        public string NBenef { get; set; } //número de beneficiário
        [DataMember]
        public bool FlagDeath { get; set; }
        [DataMember]
        public bool FlagCanceled { get; set; }
        //[DataMember]
        //public DateTime? DeathDate { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Observations { get; set; }

        private bool _IsProPatient = true;
        [DataMember]
        public bool IsProPatient
        {
            get
            {
                return _IsProPatient;
            }
            set
            {
                _IsProPatient = value;
            }
        }

        private bool _HasPendingAlterations = true;
        [DataMember]
        public bool HasPendingAlterations
        {
            get
            {
                if (IsProPatient) // Quando é PRO nunca deixa alterar nada (simula alterações pendentes)
                    return true;
                else
                    return _HasPendingAlterations;
            }
            set
            {
                _HasPendingAlterations = value;
            }
        }

        [DataMember]
        private DateTime _LastAlterationsDate;
        public DateTime LastAlterationsDate
        {
            get
            {
                return _LastAlterationsDate;
            }
            set
            {
                _LastAlterationsDate = value;
            }
        }

        [DataMember]
        public List<PatientToFacilityAssoc> PatientToFacilityAssoc { get; set; }

        [DataMember]
        public int FinancialEntityId { get; set; } //EFR

        public DateTime LastRegisterDate { get; set; } 

        public string PhotoUrl { get; set; } // FOTO DO PACIENTE (será usada inicialmente para um avatar local ..até a foto do paciente ser realmente trasnferida)

        public byte[] PhotoByte { get; set; } // FOTO DO PACIENTE 

    }
}
