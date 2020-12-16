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
    public class CurrencyService : ICurrencyService<Currency>
    {
        private string where = "CCU";
        public IEnumerable<Currency> Get()
        {
            
            try { return GS.Instance.CurrencyService.Get().Select(c => c.ToClient()); }
            catch (Exception e) { throw e; }
        }

        public Currency Get(string curr)
        {
            try { return GS.Instance.CurrencyService.Get(curr)?.ToClient(); }
            catch (Exception e) { throw e; }
            
        }
        public void Add(Currency cur)
        {
            try
            {
                if (cur is null) throw new DataException("Currency Data empty (" + where + ") (ADD)");
                GS.Instance.CurrencyService.Add(cur.ToGlobal());
            }
            catch (Exception e) { throw e; }
        }

        public bool Upd(Currency cur)
        {
            try
            {
                if (cur is null) throw new DataException("Currency Data empty (" + where + ") (UPD)");
                return GS.Instance.CurrencyService.Upd(cur.ToGlobal());
            }
            catch (Exception e) { throw e; }
        }

        public bool Del(string curr)
        {
            try { return GS.Instance.CurrencyService.Del(curr); }
            catch (Exception e) { throw e; }
        }

        public int CurrencyIsUsed(string curr)
        {
            try { return GS.Instance.CurrencyService.CurrencyIsUsed(curr); }
            catch (Exception e) { throw e; }
        }
    }
}
