using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
    [DataContract]
    public class DoctorIncome
    {
        [DataMember]
        public int Ano { get; set; }
        [DataMember]
        public int IdDoctorIncome { get; set; }
        [DataMember]
        public int IdInstituicao { get; set; }
        [DataMember]
        public int IdPessHosp { get; set; }
        [DataMember]
        public List<DoctorIncomeDet> ListDoctorIncomes { get; set; }
        [DataMember]
        public int Mes { get; set; }
        [DataMember]
        public int SCN { get; set; }
    }
}
