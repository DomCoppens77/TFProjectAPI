using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TFProjectAPI.Global.Models;

namespace TFProjectAPI.Global.Mappers
{
    internal static class UsersServiceMapper
    {
        internal static User ToUser(this IDataRecord dr)
        {
            return new User()
            {
                Id = (int)dr["Id"],
                FirstName = (dr["FirstName"] == DBNull.Value) ? "" : dr["FirstName"].ToString(),
                LastName = (dr["LastName"] == DBNull.Value) ? "" : dr["LastName"].ToString(),
                Email = dr["Email"].ToString(),
                Active = (bool)dr["Active"],
                Status = (int)dr["Status"],
                ConnectionCount = (int)dr["ConnectionCount"],
                ConnectionLast = (DateTime)dr["ConnectionLast"],
                Passwd = "" // Put passwd to BLANK to avoid having NULL
            };
        }
    }
}
