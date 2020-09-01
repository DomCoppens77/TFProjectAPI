using System.Data;
using TFProjectAPI.Global.Models;

namespace TFProjectAPI.Global.Mappers
{
    internal static class CountryServiceMappers
    {

        internal static Country ToCtry(this IDataRecord dr)
        {
            return new Country()
            {
                ISO = dr["ISO"].ToString(),
                Ctry = dr["Ctry"].ToString(),
                IsEU = (bool)dr["IsEU"]
            };

        }
    }
}
