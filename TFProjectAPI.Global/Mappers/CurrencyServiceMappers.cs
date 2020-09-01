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
                Curr = dr["Curr"].ToString(),
                Desc = dr["Description"].ToString()
            };

        }
    }
}
