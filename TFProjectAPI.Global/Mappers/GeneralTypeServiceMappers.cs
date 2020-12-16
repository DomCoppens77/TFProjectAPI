using System;
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
                Name = dr["Name"].ToString()
            };
        }


        internal static GenYearPurch ToGenYP(this IDataRecord dr)
        {
             return new GenYearPurch()
            {
                Year = (int)dr["Year"],
                TypeId = (int)dr["TypeId"],
                GenTypeName = dr["GenTypeName"].ToString(),
                Price = (float)(decimal)dr["sumprice"]
            };

        }

        internal static GenObjectSearch ToObjSearch(this IDataRecord dr)
        {
            return new GenObjectSearch()
            {
                Id = (int)dr["Id"],
                PRICE_EUR = (dr["PRICE_EUR"] == DBNull.Value) ? 0 : (float)(decimal)dr["PRICE_EUR"],
                TypeId = (int)dr["TypeId"],
                GenTypeName = dr["GenTypeName"].ToString(),
                EAN = dr["EAN"].ToString(),
                EAN_EXT = dr["EAN_EXT"].ToString(),
                EAN_FULL = dr["EAN_FULL"].ToString(),
                ShopId = (int)dr["ShopId"],
                ShopName = dr["ShopName"].ToString(),
                OBJTEXT = dr["OBJTEXT"].ToString(),
            };

        }

    }
}
