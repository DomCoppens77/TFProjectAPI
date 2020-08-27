using System.Collections.Generic;
using System.Linq;
using TFProjectAPI.Client.Mappers;
using TFProjectAPI.Client.Models;
using TFProjectAPI.Repo;
using GS = TFProjectAPI.Global.Services.ServiceLocator;

namespace TFProjectAPI.Client.Services
{
    public class CurrencyService : ICurrencyService<Currency>
    {
        public void Add(Currency cur)
        {
            GS.Instance.CurrencyService.Add(cur.ToGlobal());
        }

        public int CurrencyIsUsed(string curr)
        {
            return GS.Instance.CurrencyService.CurrencyIsUsed(curr);
        }

        public bool Del(string curr)
        {
            return GS.Instance.CurrencyService.Del(curr);
        }

        public IEnumerable<Currency> Get()
        {
            return GS.Instance.CurrencyService.Get().Select(c => c.ToClient());
        }

        public Currency Get(string curr)
        {
            return GS.Instance.CurrencyService.Get(curr)?.ToClient();
        }

        public bool Upd(Currency cur)
        {
            return GS.Instance.CurrencyService.Upd(cur.ToGlobal());
        }
    }
}
