using System;
using System.Collections.Generic;
using System.Text;

namespace TFProjectAPI.ToolBox.Database
{
    public class DBConnectionInfo : IConnectionInfo
    {
        public string ConnectionString { get; private set; }

        public DBConnectionInfo(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
