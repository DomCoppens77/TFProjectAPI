using System;
using System.Data;
using TFProjectAPI.Global.Models;

namespace TFProjectAPI.Global.Mappers
{
    internal static class ShopsServiceMappers
    {
        internal static Shop ToShop(this IDataRecord dr)
        {
            return new Shop()
            {
                Id = (int)dr["Id"],
                Name = dr["Name"].ToString(),
                Address1 = (dr["Address1"] == DBNull.Value) ? "" : dr["Address1"].ToString(),
                Address2 = (dr["Address2"] == DBNull.Value) ? "" : dr["Address2"].ToString(),
                ZIP = (dr["ZIP"] == DBNull.Value) ? "" : dr["ZIP"].ToString(),
                City = (dr["City"] == DBNull.Value) ? "" : dr["City"].ToString(),
                Country = dr["Country"].ToString(),
                Phone = (dr["Phone"] == DBNull.Value) ? "" : dr["Phone"].ToString(),
                Email = (dr["Email"] == DBNull.Value) ? "" : dr["Email"].ToString(),
                WebSite = (dr["WebSite"] == DBNull.Value) ? "" : dr["WebSite"].ToString(),
                LocalisationURL = (dr["LocalisationURL"] == DBNull.Value) ? "" : dr["LocalisationURL"].ToString(),
                Closed = (bool)dr["Closed"]
            };
        }
    }
}
