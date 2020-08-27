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
                ISO = (string)dr["ISO"],
                Ctry = (string)dr["Ctry"],
                IsEU = (bool)dr["IsEU"]
            };

        }
    }
}
