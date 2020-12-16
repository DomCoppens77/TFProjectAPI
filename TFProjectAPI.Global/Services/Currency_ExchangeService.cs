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
    public class Currency_ExchangeService : ICurrency_Exchange<Currency_Exchange>
    {
        private string where = "GCX";
        private string Str_Get = "Select * From [AppUser].[V_Currency_Exchange]";

        public IEnumerable<Currency_Exchange> Get()
        {
            try
            {
                DBCommand command = new DBCommand(Str_Get + " ORDER BY [DateFrom] ASC, [DateTo] ASC, [CurrFrom] ASC;");
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToCurrXchg());
            }
            catch (Exception e) { throw e; }
        }

        public Currency_Exchange Get(int id)
        {
            try
            {
                DBCommand command = new DBCommand(Str_Get + " Where [Id] = @Id;");
                command.AddParameter("Id", id);
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToCurrXchg()).SingleOrDefault();
            }
            catch (Exception e) { throw e; }
        }
        public void Add(Currency_Exchange cxc)
        {
            try
            {
                if (cxc is null) throw new DataException("Currency Exchange Data empty (" + where + ") (ADD)");
                if (cxc.CurrFrom.Length != 3) throw new DataException("Issue with Data entered for Add (" + where + ") (ADD1)");
                if (cxc.CurrTo.Length != 3) throw new DataException("Issue with Data entered for Add (" + where + ") (ADD2)");
                if ( cxc.CurrFrom == cxc.CurrTo) throw new DataException("Issue with Data entered for Add CurrTo=CurrF (" + where + ") (ADD3)");
                if (cxc.Rate <= 0) throw new DataException("Issue with Data entered for Add (" + where + ") (ADD4)");

                DBCommand command = new DBCommand("[AppUser].[AddCurrency_Exchange]", true);
                command.AddParameter("CurrF", cxc.CurrFrom);
                command.AddParameter("CurrT", cxc.CurrTo);
                command.AddParameter("DateF", cxc.DateFrom);
                command.AddParameter("DateT", cxc.DateTo);
                command.AddParameter("Rate", cxc.Rate);

                cxc.Id = (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
            }
            catch (Exception e) { throw e; }
        }
        public bool Upd(Currency_Exchange cxc)
        {
            try
            {
                if (cxc is null) throw new DataException("Currency Exchange Data empty (" + where + ") (UPD)");
                if (cxc.CurrFrom.Length != 3) throw new DataException("Issue with Data entered for Add (" + where + ") (UPD1)");
                if (cxc.CurrTo.Length != 3) throw new DataException("Issue with Data entered for Add (" + where + ") (UPD2)");
                if (cxc.CurrFrom == cxc.CurrTo) throw new DataException("Issue with Data entered for Add CurrTo=CurrF (" + where + ") (UPD3)");
                if (cxc.Rate <= 0) throw new DataException("Issue with Data entered for Add (" + where + ") (UPD4)");

                DBCommand command = new DBCommand("[AppUser].[UpdCurrency_Exchange]", true);
                command.AddParameter("Id", cxc.Id);
                command.AddParameter("CurrF", cxc.CurrFrom);
                command.AddParameter("CurrT", cxc.CurrTo);
                command.AddParameter("DateF", cxc.DateFrom);
                command.AddParameter("DateT", cxc.DateTo);
                command.AddParameter("Rate", cxc.Rate);
                return 1 == ServiceLocator.Instance.Connection.ExecuteNonQuery(command);
            }
            catch (Exception e) { throw e; }
        }
        public bool Del(int id)
        {
            try
            {
                DBCommand command = new DBCommand("[AppUser].[DelCurrency_Exchange]", true);
                command.AddParameter("Id", id);
                return 1 == ServiceLocator.Instance.Connection.ExecuteNonQuery(command);
            }
            catch (Exception e) { throw e; }
        }

        public int Check_DateF(Currency_Exchange cxc)
        {
            try
            {
                if (cxc is null) throw new DataException("Currency Exchange Data empty (" + where + ") (CF)");
                if (cxc.CurrFrom.Length != 3) throw new DataException("Issue with Data entered for Add (" + where + ") (CF1)");
                if (cxc.CurrTo.Length != 3) throw new DataException("Issue with Data entered for Add (" + where + ") (CF2)");

                DBCommand command = new DBCommand("[AppUser].[Check_CX_DateF]", true);
                command.AddParameter("CurrF", cxc.CurrFrom);
                command.AddParameter("CurrT", cxc.CurrTo);
                command.AddParameter("Date2Chk", cxc.DateFrom);
                return (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
            }
            catch (Exception e) { throw e; }
        }

        public int Check_DateT(Currency_Exchange cxc)
        {
            try
            {
                if (cxc is null) throw new DataException("Currency Exchange Data empty (" + where + ") (CT)");
                if (cxc.CurrFrom.Length != 3) throw new DataException("Issue with Data entered for Add (" + where + ") (CT1)");
                if (cxc.CurrTo.Length != 3) throw new DataException("Issue with Data entered for Add (" + where + ") (CT2)");

                DBCommand command = new DBCommand("[AppUser].[Check_CX_DateT]", true);
                command.AddParameter("CurrF", cxc.CurrFrom);
                command.AddParameter("CurrT", cxc.CurrTo);
                command.AddParameter("Date2Chk", cxc.DateFrom);
                return (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
            }
            catch (Exception e) { throw e; }
        }
    }
}
