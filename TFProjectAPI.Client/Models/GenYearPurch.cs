using System;
using System.Collections.Generic;
using System.Text;

namespace TFProjectAPI.Client.Models
{
    public class GenYearPurch
    {
        private int _year;
        private int _typeId;
        private float _price;
        private string _genTypeName;

        public GenYearPurch(int year, int typeid, string genTypeName, float price)
        {
            Year = year;
            TypeId = typeid;
            GenTypeName = genTypeName;
            Price = price;
        }
        public GenYearPurch()
        {

        }

        public int Year
        {
            get
            {
                return _year;
            }

            set
            {
                _year = value;
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
    }
}
