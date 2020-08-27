using System.Collections.Generic;
using System.Linq;
using TFProjectAPI.Global.Mappers;
using TFProjectAPI.Global.Models;
using TFProjectAPI.Repo;
using TFProjectAPI.ToolBox.Database;

namespace TFProjectAPI.Global.Services
{
    public class CountryService : ICountryService<Country>
    {
        public void Add(Country ctry)
        {
            DBCommand command = new DBCommand("[AppUser].[AddCtry]", true);
            command.AddParameter("ISO", ctry.ISO);
            command.AddParameter("Ctry", ctry.Ctry);
            command.AddParameter("IsEu", ctry.IsEU);

            ServiceLocator.Instance.Connection.ExecuteScalar(command);
        }

        public bool Del(string ISO)
        {
            DBCommand command = new DBCommand("[AppUser].[DelCurr]", true);
            command.AddParameter("ISO", ISO);

            return ServiceLocator.Instance.Connection.ExecuteNonQuery(command) == 1;
        }

        public IEnumerable<Country> Get()
        {
            DBCommand command = new DBCommand("Select * From [AppUser].[V_Country];");
            return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToCtry());
        }

        public Country Get(string ISO)
        {
            DBCommand command = new DBCommand("Select * From [AppUser].[V_Country] Where [ISO] = @ISO;");
            command.AddParameter("ISO", ISO);
            return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToCtry()).SingleOrDefault();
        }

        public bool Upd(Country ctry)
        {
            DBCommand command = new DBCommand("[AppUser].[UpdCtry]", true);
            command.AddParameter("ISO", ctry.ISO);
            command.AddParameter("Ctry", ctry.Ctry);
            command.AddParameter("IsEu", ctry.IsEU);

            return ServiceLocator.Instance.Connection.ExecuteNonQuery(command) == 1;
        }
    }
}
