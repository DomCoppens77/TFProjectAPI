using System.Collections.Generic;
using System.Linq;
using TFProjectAPI.Client.Mappers;
using TFProjectAPI.Client.Models;
using TFProjectAPI.Repo;
using GS = TFProjectAPI.Global.Services.ServiceLocator;

namespace TFProjectAPI.Client.Services
{
    public class Currency_ExchangeService : ICurrency_Exchange<Currency_Exchange>
    {
        public void Add(Currency_Exchange cxc)
        {
            GS.Instance.Currency_ExchangeService.Add(cxc.ToGlobal());
        }

        public int Check_DateF(Currency_Exchange cxc)
        {
            return GS.Instance.Currency_ExchangeService.Check_DateF(cxc.ToGlobal());
        }

        public int Check_DateT(Currency_Exchange cxc)
        {
            return GS.Instance.Currency_ExchangeService.Check_DateF(cxc.ToGlobal());
        }

        public bool Del(int id)
        {
            return GS.Instance.Currency_ExchangeService.Del(id);
        }

        public IEnumerable<Currency_Exchange> Get()
        {
            return GS.Instance.Currency_ExchangeService.Get().Select(cxc => cxc.ToClient());
        }

        public Currency_Exchange Get(int id)
        {
            return GS.Instance.Currency_ExchangeService.Get(id)?.ToClient();
        }

        public bool Upd(Currency_Exchange cxc)
        {
            return GS.Instance.Currency_ExchangeService.Upd(cxc.ToGlobal());
        }
    }
}
