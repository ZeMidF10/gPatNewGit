using Glintths.MobileApps.Core.Helpers;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
	public class Session{

        private string encryptionKey;
        public Session()
        {
            encryptionKey = Configuration.Instance.Configurations["APP_SECRET"];
        }

        public Session(string encryptionKey)
        {
            this.encryptionKey = encryptionKey;
        }

        private string _sessionTokenSecret;
        public string SessionTokenSecret
        {
            get { return _sessionTokenSecret; }
            set { _sessionTokenSecret = value; }
		}
        public string EncryptedSessionTokenSecret
        {
            get {

                return CryptoHelper.Encrypt(_sessionTokenSecret, encryptionKey); 
            }
            set {
                _sessionTokenSecret = CryptoHelper.Decrypt(value, encryptionKey); 
            }
        }
	}

    [DataContract]
    public enum UserType
    {
        [EnumMember]
        Patient,
        [EnumMember]
        Doctor,
        [EnumMember]
        Nurse,
        [EnumMember]
        Administrative,
        [EnumMember]
        Technician,
        [EnumMember]
        Pharmaceutical,
        [EnumMember]
        Auxiliary,
        [EnumMember]
        Donor,
        [EnumMember]
        OperatorCC
    }

    public class User : INotifyPropertyChanged
	{
		public UserType Type;
		public Session Session;

        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                if (value != _Name)
                {
                    _Name = value;
                    NotifyPropertyChanged("Name");
                }
            }

        }

        //private string _nMecan;

        //public string nMecan
        //{
        //    get { return _nMecan; }
        //    set { _nMecan = value; }
        //}


        public string SecurityId;

        private string _userId;

        public string UserId
        {
            get {
                return _userId;
            }
            set {
                
                _userId = value;
            }
        }


        public string PessHospId;

        public string Username;

        private HumanResource _medicData;

        public HumanResource MedicData
        {
            get {
                return _medicData;
            }
            set {
                _medicData = value;
            }
        }


        public User ()
		{
		}



        #region IPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion IPropertyChanged
    }


}

