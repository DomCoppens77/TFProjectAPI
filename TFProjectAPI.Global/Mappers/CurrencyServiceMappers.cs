using System.Data;
using TFProjectAPI.Global.Models;


namespace TFProjectAPI.Global.Mappers
{
    internal static class CurrencyServiceMappers
    {
        internal static Currency ToCurr(this IDataRecord dr)
        {
            return new Currency()
            {
                Curr = (string)dr["Curr"],
                Desc = (string)dr["Description"]
            };

        }
    }
}
