using System;

namespace TFProjectAPI.Client.Models
{
    public class Currency_Exchange
    {

		private int _id;
		private DateTime _dateFrom, _dateTo;
		private string _currFrom, _currTo;
		private float _rate;

        public Currency_Exchange(int id, string currf, string currt, DateTime datef, DateTime datet, float rate)
        {
            Id = id;
            CurrFrom = currf;
            CurrTo = currt;
            DateFrom = datef;
            DateTo = datet;
            Rate = rate;
        }
        public Currency_Exchange()
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

        public DateTime DateFrom
        {
            get
            {
                return _dateFrom;
            }

            set
            {
                _dateFrom = value;
            }
        }

        public DateTime DateTo
        {
            get
            {
                return _dateTo;
            }

            set
            {
                _dateTo = value;
            }
        }

        public string CurrFrom
        {
            get
            {
                return _currFrom;
            }

            set
            {
                _currFrom = value;
            }
        }

        public string CurrTo
        {
            get
            {
                return _currTo;
            }

            set
            {
                _currTo = value;
            }
        }

        public float Rate
        {
            get
            {
                return _rate;
            }

            set
            {
                _rate = value;
            }
        }


	}
}
