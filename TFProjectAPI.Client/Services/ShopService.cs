using System.Collections.Generic;
using System.Linq;
using TFProjectAPI.Client.Mappers;
using TFProjectAPI.Client.Models;
using TFProjectAPI.Repo;
using GS = TFProjectAPI.Global.Services.ServiceLocator;

namespace TFProjectAPI.Client.Services
{
    public class ShopService : IShopService<Shop>
    {
        public Shop Add(Shop shop)
        {
            return GS.Instance.ShopService.Add(shop.ToGlobal()).ToClient();
        }

        public bool Del(int id)
        {
            return GS.Instance.ShopService.Del(id);
        }

        public IEnumerable<Shop> Get()
        {
            return GS.Instance.ShopService.Get().Select(S => S.ToClient());
        }

        public Shop Get(int id)
        {
            return GS.Instance.ShopService.Get(id)?.ToClient();
        }

        public int ShopIsUsed(int id)
        {
            return GS.Instance.ShopService.ShopIsUsed(id);
        }

        public bool Upd(Shop shop)
        {
            return GS.Instance.ShopService.Upd(shop.ToGlobal());
        }
    }
}
