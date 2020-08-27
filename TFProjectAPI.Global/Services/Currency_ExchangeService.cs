using System.Collections.Generic;
using System.Linq;
using TFProjectAPI.Global.Mappers;
using TFProjectAPI.Global.Models;
using TFProjectAPI.Repo;
using TFProjectAPI.ToolBox.Database;

namespace TFProjectAPI.Global.Services
{
    public class Currency_ExchangeService : ICurrency_Exchange<Currency_Exchange>
    {
        public void Add(Currency_Exchange cxc)
        {
            DBCommand command = new DBCommand("[AppUser].[AddCurrency_Exchange]", true);
            command.AddParameter("CurrF", cxc.CurrFrom);
            command.AddParameter("CurrT", cxc.CurrTo);
            command.AddParameter("DateF", cxc.DateFrom);
            command.AddParameter("DateT", cxc.DateTo);
            command.AddParameter("Rate", cxc.Rate);

            cxc.Id = (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
        }

        public bool Del(int id)
        {
            DBCommand command = new DBCommand("[AppUser].[DelCurrency_Exchange]", true);
            command.AddParameter("Id", id);

            return 1 == ServiceLocator.Instance.Connection.ExecuteNonQuery(command);

        }

        public IEnumerable<Currency_Exchange> Get()
        {
            DBCommand command = new DBCommand("Select * From [AppUser].[V_Currency_Exchange];");
            return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToCurrXchg());
        }

        public Currency_Exchange Get(int id)
        {
            DBCommand command = new DBCommand("Select * From [AppUser].[V_Currency_Exchange] Where [Id] = @Id;");
            command.AddParameter("Id", id);
            return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToCurrXchg()).SingleOrDefault();
        }

        public bool Upd(Currency_Exchange cxc)
        {
            DBCommand command = new DBCommand("[AppUser].[UpdCurrency_Exchange]", true);
            command.AddParameter("Id", cxc.Id);
            command.AddParameter("CurrF", cxc.CurrFrom);
            command.AddParameter("CurrT", cxc.CurrTo);
            command.AddParameter("DateF", cxc.DateFrom);
            command.AddParameter("DateT", cxc.DateTo);
            command.AddParameter("Rate", cxc.Rate);

            return 1 == ServiceLocator.Instance.Connection.ExecuteNonQuery(command);

        }

        public int Check_DateF(Currency_Exchange cxc)
        {
            DBCommand command = new DBCommand("[AppUser].[Check_CX_DateF]", true);
            command.AddParameter("CurrF", cxc.CurrFrom);
            command.AddParameter("CurrT", cxc.CurrTo);
            command.AddParameter("Date2Chk", cxc.DateFrom);
            return (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
        }

        public int Check_DateT(Currency_Exchange cxc)
        {
            DBCommand command = new DBCommand("[AppUser].[Check_CX_DateT]", true);
            command.AddParameter("CurrF", cxc.CurrFrom);
            command.AddParameter("CurrT", cxc.CurrTo);
            command.AddParameter("Date2Chk", cxc.DateFrom);
            return (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
        }
    }
}
