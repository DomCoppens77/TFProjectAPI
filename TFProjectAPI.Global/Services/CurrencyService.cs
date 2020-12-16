using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TFProjectAPI.Global.Mappers;
using TFProjectAPI.Global.Models;
using TFProjectAPI.Repo;
using TFProjectAPI.ToolBox.Database;

namespace TFProjectAPI.Global.Services
{
    public class CurrencyService : ICurrencyService<Currency>
    {
        private string where = "GCU";
        private string Str_Get = "Select * From [AppUser].[V_Curr]";

        public IEnumerable<Currency> Get()
        {
            try
            {
                DBCommand command = new DBCommand(Str_Get + ";");
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToCurr());
            }
            catch (Exception e) { throw e; }
        }

        public Currency Get(string curr)
        {
            try
            {
                DBCommand command = new DBCommand(Str_Get + " Where [Curr] = @Curr;");
                command.AddParameter("Curr", curr);
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToCurr()).SingleOrDefault();
            }
            catch (Exception e) { throw e; }
        }

        public void Add(Currency cur)
        {
            try
            {
                if (cur is null) throw new DataException("Currency Data empty (" + where + ") (ADD)");
                DBCommand command = new DBCommand("[AppUser].[AddCurr]", true);
                command.AddParameter("Curr", cur.Curr);
                command.AddParameter("Desc", cur.Desc);
                ServiceLocator.Instance.Connection.ExecuteScalar(command);
            }
            catch (Exception e) { throw e; }
        }

        public bool Upd(Currency cur)
        {
            try
            {
                if (cur is null) throw new DataException("Currency Data empty (" + where + ") (UPD)");
                DBCommand command = new DBCommand("[AppUser].[UpdCurr]", true);
                command.AddParameter("Curr", cur.Curr);
                command.AddParameter("Desc", cur.Desc);
                return ServiceLocator.Instance.Connection.ExecuteNonQuery(command) == 1;
            }
            catch (Exception e) { throw e; }
        }

        public bool Del(string curr)
        {
            try
            {
                DBCommand command = new DBCommand("[AppUser].[DelCurr]", true);
                command.AddParameter("Curr", curr);
                return ServiceLocator.Instance.Connection.ExecuteNonQuery(command) == 1;
            }
            catch (Exception e) { throw e; }
        }

        public int CurrencyIsUsed(string curr)
        {
            try
            {
                DBCommand command = new DBCommand("[AppUser].[CheckCurr]", true);
                command.AddParameter("Curr", curr);
                return (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
            }
            catch (Exception e) { throw e; }
        }
    }
}
