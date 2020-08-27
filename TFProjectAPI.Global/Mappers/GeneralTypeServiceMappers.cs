using System.Data;
using TFProjectAPI.Global.Models;

namespace TFProjectAPI.Global.Mappers
{
    internal static class GeneralTypeServiceMappers
    {

        internal static GeneralType ToGenType(this IDataRecord dr)
        {
            return new GeneralType()
            {
                Id = (int)dr["Id"],
                Name = (string)dr["Name"]
            };
        }
    }
}
