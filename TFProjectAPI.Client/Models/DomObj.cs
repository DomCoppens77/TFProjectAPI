using System;

namespace TFProjectAPI.Client.Models
{
    public abstract class DomObj
    {
		private int _id;
		private float _price;
		private string _curr;
		private int _shopId;
		private DateTime _date;
		private int _typeId;
		private bool _signed;
		private string _signedBy;
		private string _eAN;
		private string _eAN_EXT;
		private string _comment1;
		private string _comment2;
		private bool _onwed;

        public DomObj(int id, float price, string curr, int shopId, DateTime date, int typeId, bool signed, string signedBy, string eAN, string eAN_EXT, string comment1, string comment2, bool onwed)
        {
            Id = id;
            Price = price;
            Curr = curr;
            ShopId = shopId;
            Date = date;
            TypeId = typeId;
            Signed = signed;
            SignedBy = signedBy;
            EAN = eAN;
            EAN_EXT = eAN_EXT;
            Comment1 = comment1;
            Comment2 = comment2;
            Onwed = onwed;
        }
        public DomObj()
        {

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

        public float Price
        {
            get
            {
                return _price;
            }

            set
            {
                _price = value;
            }
        }

        public string Curr
        {
            get
            {
                return _curr;
            }

            set
            {
                _curr = value;
            }
        }

        public int ShopId
        {
            get
            {
                return _shopId;
            }

            set
            {
                _shopId = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
            }
        }

        public int TypeId
        {
            get
            {
                return _typeId;
            }

            set
            {
                _typeId = value;
            }
        }

        public bool Signed
        {
            get
            {
                return _signed;
            }

            set
            {
                _signed = value;
            }
        }

        public string SignedBy
        {
            get
            {
                return _signedBy;
            }

            set
            {
                _signedBy = value;
            }
        }

        public string EAN
        {
            get
            {
                return _eAN;
            }

            set
            {
                _eAN = value;
            }
        }

        public string EAN_EXT
        {
            get
            {
                return _eAN_EXT;
            }

            set
            {
                _eAN_EXT = value;
            }
        }

        public string Comment1
        {
            get
            {
                return _comment1;
            }

            set
            {
                _comment1 = value;
            }
        }

        public string Comment2
        {
            get
            {
                return _comment2;
            }

            set
            {
                _comment2 = value;
            }
        }

        public bool Onwed
        {
            get
            {
                return _onwed;
            }

            set
            {
                _onwed = value;
            }
        }
    }
}
