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
    public class CountryService : ICountryService<Country>
    {
        private string where = "GCTRY";
        private string Str_Get = "Select * From [AppUser].[V_Country]";

        public IEnumerable<Country> Get()
        {
            try
            {
                DBCommand command = new DBCommand(Str_Get + ";");
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToCtry());
            }
            catch (Exception e) { throw e; }
        }

        public Country Get(string ISO)
        {
            try
            {
                DBCommand command = new DBCommand(Str_Get + " Where [ISO] = @ISO;");
                command.AddParameter("ISO", ISO);
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToCtry()).SingleOrDefault();
            }
            catch (Exception e) { throw e; }
        }

        public void Add(Country ctry)
        {
            try
            {
                if (ctry is null) throw new DataException("Country Data empty (" + where + ") (ADD)");
                DBCommand command = new DBCommand("[AppUser].[AddCtry]", true);
                command.AddParameter("ISO", ctry.ISO);
                command.AddParameter("Ctry", ctry.Ctry);
                command.AddParameter("IsEu", ctry.IsEU);
                ServiceLocator.Instance.Connection.ExecuteScalar(command);
            }
            catch (Exception e) { throw e; }
        }

        public bool Upd(Country ctry)
        {
            try
            {
                if (ctry is null) throw new DataException("Country Data empty (" + where + ") (UPD)");
                DBCommand command = new DBCommand("[AppUser].[UpdCtry]", true);
                command.AddParameter("ISO", ctry.ISO);
                command.AddParameter("Ctry", ctry.Ctry);
                command.AddParameter("IsEu", ctry.IsEU);
                return ServiceLocator.Instance.Connection.ExecuteNonQuery(command) == 1;
            }
            catch (Exception e) { throw e; }
        }

        public bool Del(string ISO)
        {
            try
            {
                DBCommand command = new DBCommand("[AppUser].[DelCtry]", true);
                command.AddParameter("ISO", ISO);
                return ServiceLocator.Instance.Connection.ExecuteNonQuery(command) == 1;
            }
            catch (Exception e) { throw e; }
        }

        public int IsUsed(string ISO)
        {
            try
            {
                DBCommand command = new DBCommand("[AppUser].[CheckCtry]", true);
                command.AddParameter("ISO", ISO);
                return (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
            }
            catch (Exception e) { throw e; }
        }
    }
}
