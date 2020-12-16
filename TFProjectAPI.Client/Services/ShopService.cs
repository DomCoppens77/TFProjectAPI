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
    public class ShopService : IShopService<Shop>
    {
        private string where = "CS";
        public IEnumerable<Shop> Get()
        {
            try { return GS.Instance.ShopService.Get().Select(S => S.ToClient()); }
            catch (Exception e) { throw e; }
        }

        public Shop Get(int id)
        {
            try { return GS.Instance.ShopService.Get(id)?.ToClient(); }
            catch (Exception e) { throw e; }
        }
        public Shop Add(Shop shop)
        {
            try
            {
                if (shop is null) throw new DataException("Shop Data empty (" + where + ") (ADD)");
                return GS.Instance.ShopService.Add(shop.ToGlobal()).ToClient();
            }
            catch (Exception e) { throw e; }
        }

        public bool Upd(Shop shop)
        {
            try
            {
                if (shop is null) throw new DataException("Shop Data empty (" + where + ") (UPD)");
                return GS.Instance.ShopService.Upd(shop.ToGlobal());
            }
            catch (Exception e) { throw e; }
        }

        public bool Del(int id)
        {
            try { return GS.Instance.ShopService.Del(id); }
            catch (Exception e) { throw e; }
        }

        public int ShopIsUsed(int id)
        {
            try { return GS.Instance.ShopService.ShopIsUsed(id); }
            catch (Exception e) { throw e; }
        }
    }
}
