using System;
using System.Collections.Generic;
using System.Text;

namespace TFProjectAPI.Client.Models
{
    public class GenObjectSearch
    {
        private int _id;
        private float _pRICE_EUR;
        private int _typeId;
        private string _genTypeName;
        private string _eAN;
        private string _eAN_EXT;
        private int _shopId;
        private string _shopName;
        private string _oBJTEXT;

        public GenObjectSearch(int id, float pRICE_EUR, int typeId, string genTypeName, string eAN, string eAN_EXT, int shopId, string shopName, string oBJTEXT)
        {
            Id = id;
            PRICE_EUR = pRICE_EUR;
            TypeId = typeId;
            GenTypeName = genTypeName;
            EAN = eAN;
            EAN_EXT = eAN_EXT;
            ShopId = shopId;
            ShopName = shopName;
            OBJTEXT = oBJTEXT;
        }

        public GenObjectSearch()
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

        public float PRICE_EUR
        {
            get
            {
                return _pRICE_EUR;
            }

            set
            {
                _pRICE_EUR = value;
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

        public string GenTypeName
        {
            get
            {
                return _genTypeName;
            }

            set
            {
                _genTypeName = value;
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

        public string ShopName
        {
            get
            {
                return _shopName;
            }

            set
            {
                _shopName = value;
            }
        }

        public string OBJTEXT
        {
            get
            {
                return _oBJTEXT;
            }

            set
            {
                _oBJTEXT = value;
            }
        }
    }
}
