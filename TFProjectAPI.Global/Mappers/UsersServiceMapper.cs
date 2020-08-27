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
                FirstName = (string)dr["FirstName"],
                LastName = (string)dr["LastName"],
                Email = (string)dr["Email"],
                Active = (bool)dr["Active"],
                Status = (int)dr["Status"],
                ConnectionCount = (int)dr["ConnectionCount"],
                ConnectionLast = (DateTime)dr["ConnectionLast"],
                Passwd = "" // Put passwd to BLANK to avoid having NULL
            };
        }
    }
}
