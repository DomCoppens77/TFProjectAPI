using System;
using System.Collections.Generic;
using System.Data;

namespace TFProjectAPI.ToolBox.Database
{
    public interface IConnection
    {
        int ExecuteNonQuery(DBCommand command);
        IEnumerable<TResult> ExecuteReader<TResult>(DBCommand command, Func<IDataRecord, TResult> selector);
        object ExecuteScalar(DBCommand command);
    }
}
