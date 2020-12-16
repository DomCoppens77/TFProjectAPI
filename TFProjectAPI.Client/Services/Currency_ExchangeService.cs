using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TFProjectAPI.Client.Mappers;
using TFProjectAPI.Client.Models;
using TFProjectAPI.Repo;
using GS = TFProjectAPI.Global.Services.ServiceLocator;

namespace TFProjectAPI.Client.Services
{
    public class Currency_ExchangeService : ICurrency_Exchange<Currency_Exchange>
    {

        private string where = "CCX";
        public IEnumerable<Currency_Exchange> Get()
        {
            try { return GS.Instance.Currency_ExchangeService.Get().Select(cxc => cxc.ToClient()); }
            catch (Exception e) { throw e; }
        }

        public Currency_Exchange Get(int id)
        {
            try { return GS.Instance.Currency_ExchangeService.Get(id)?.ToClient(); }
            catch (Exception e) { throw e; }
        }
        public void Add(Currency_Exchange cxc)
        {
            try
            {
                if (cxc is null) throw new DataException("Currency Exchange Data empty (" + where + ") (ADD)");
                if (cxc.CurrFrom.Length != 3) throw new DataException("Issue with Data entered for Add (" + where + ") (ADD1)");
                if (cxc.CurrTo.Length != 3) throw new DataException("Issue with Data entered for Add (" + where + ") (ADD2)");
                if (cxc.Rate <= 0) throw new DataException("Issue with Data entered for Add (" + where + ") (ADD3)");
                GS.Instance.Currency_ExchangeService.Add(cxc.ToGlobal());
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
                if (cxc.Rate <= 0) throw new DataException("Issue with Data entered for Add (" + where + ") (UPD3)");
                return GS.Instance.Currency_ExchangeService.Upd(cxc.ToGlobal());
            }
            catch (Exception e) { throw e; }
        }

        public bool Del(int id)
        {
            try { return GS.Instance.Currency_ExchangeService.Del(id); }
            catch (Exception e) { throw e; }
        }

        public int Check_DateF(Currency_Exchange cxc)
        {
            try
            {
                if (cxc is null) throw new DataException("Currency Exchange Data empty (" + where + ") (CF)");
                if (cxc.CurrFrom.Length != 3) throw new DataException("Issue with Data entered for Add (" + where + ") (CF1)");
                if (cxc.CurrTo.Length != 3) throw new DataException("Issue with Data entered for Add (" + where + ") (CF2)");
                return GS.Instance.Currency_ExchangeService.Check_DateF(cxc.ToGlobal());
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
                return GS.Instance.Currency_ExchangeService.Check_DateF(cxc.ToGlobal());
            }
            catch (Exception e) { throw e; }
        }
    }
}
