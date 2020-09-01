namespace TFProjectAPI.Client.Models
{
    public class Shop
    {

		private  int    _id;
		private  string _name;
		private  string _address1;
		private  string _address2;
		private  string _zIP;
		private  string _city;
		private  string _country;
		private  string _phone;
		private  string _email;
		private  string _webSite;
		private  string _localisationURL;
		private  bool   _closed;

        public Shop()  {  }

        public Shop(int id, string name, string address1, string address2, string zip, string city, string country, string phone, string email, string website, string localisationUrl, bool closed)
        {
            Id = id;
            Name = name;
            Address1 = address1;
            Address2 = address2;
            ZIP = zip;
            City = city;
            Country = country;
            Phone = phone;
            Email = email;
            WebSite = website;
            LocalisationURL = localisationUrl;
            Closed = closed;
        }

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string Address1
        {
            get
            {
                return _address1;
            }

            set
            {
                _address1 = value;
            }
        }

        public string Address2
        {
            get
            {
                return _address2;
            }

            set
            {
                _address2 = value;
            }
        }

        public string ZIP
        {
            get
            {
                return _zIP;
            }

            set
            {
                _zIP = value;
            }
        }

        public string City
        {
            get
            {
                return _city;
            }

            set
            {
                _city = value;
            }
        }

        public string Country
        {
            get
            {
                return _country;
            }

            set
            {
                _country = value;
            }
        }

        public string Phone
        {
            get
            {
                return _phone;
            }

            set
            {
                _phone = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public string WebSite
        {
            get
            {
                return _webSite;
            }

            set
            {
                _webSite = value;
            }
        }

        public string LocalisationURL
        {
            get
            {
                return _localisationURL;
            }

            set
            {
                _localisationURL = value;
            }
        }

        public bool Closed
        {
            get
            {
                return _closed;
            }

            set
            {
                _closed = value;
            }
        }
    }
}
