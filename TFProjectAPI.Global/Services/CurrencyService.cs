using System.Collections.Generic;
using System.Linq;
using TFProjectAPI.Global.Mappers;
using TFProjectAPI.Global.Models;
using TFProjectAPI.Repo;
using TFProjectAPI.ToolBox.Database;

namespace TFProjectAPI.Global.Services
{
    public class CurrencyService : ICurrencyService<Currency>
    {
        public void Add(Currency cur)
        {
            DBCommand command = new DBCommand("[AppUser].[AddCurr]", true);
            command.AddParameter("Curr", cur.Curr);
            command.AddParameter("Desc", cur.Desc);

            ServiceLocator.Instance.Connection.ExecuteScalar(command);
        }

        public int CurrencyIsUsed(string curr)
        {
            //// plante je sais pas pq
            //DBCommand command = new DBCommand("[AppUser].[CheckCurr]", true);
            //command.AddParameter("Curr", curr);
            //return (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);

            //// Cette Version Là aussi
            //DBCommand command = new DBCommand("[AppUser].[CheckCurr]", true);
            //command.AddParameter("Curr", curr);
            //var i = ServiceLocator.Instance.Connection.ExecuteScalar(command);
            //return (int)i;

            DBCommand command = new DBCommand("SELECT COUNT(*) FROM [AppUser].[V_Object] where [Curr] = @Curr;");
            command.AddParameter("Curr", curr);
            int i = (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
            return i;
        }

        public bool Del(string curr)
        {
            DBCommand command = new DBCommand("[AppUser].[DelCurr]", true);
            command.AddParameter("Curr", curr);

            return ServiceLocator.Instance.Connection.ExecuteNonQuery(command) == 1;
        }

        public IEnumerable<Currency> Get()
        {
            DBCommand command = new DBCommand("Select * From [AppUser].[V_Curr];");
            return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToCurr());
        }

        public Currency Get(string curr)
        {
            DBCommand command = new DBCommand("Select * From [AppUser].[V_Curr] Where [Curr] = @Curr;");
            command.AddParameter("Curr", curr);
            return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToCurr()).SingleOrDefault();
        }

        public bool Upd(Currency cur)
        {
            DBCommand command = new DBCommand("[AppUser].[UpdCurr]", true);
            command.AddParameter("Curr", cur.Curr);
            command.AddParameter("Desc", cur.Desc);

            return ServiceLocator.Instance.Connection.ExecuteNonQuery(command) == 1;
        }
    }
}
