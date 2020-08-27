using System;
using System.Data;
using TFProjectAPI.Global.Models;

namespace TFProjectAPI.Global.Mappers
{
    internal static class Currency_ExchangeServiceMappers
    {
        internal static Currency_Exchange ToCurrXchg(this IDataRecord dr)
        {
            return new Currency_Exchange()
            {
                CurrFrom = (string)dr["CurrFrom"],
                CurrTo = (string)dr["CurrTo"],
                DateFrom = (DateTime)dr["DateFrom"],
                DateTo = (DateTime)dr["DateTo"],
                Rate = (float)(double)dr["Rate"]
            };

        }
    }
}
