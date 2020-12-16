using System;
using System.Collections.Generic;

namespace TFProjectAPI.Repo
{
    public interface IShopService<TShop>
    {
        IEnumerable<TShop> Get();

        TShop Get(int id);

        TShop Add(TShop shop);

        bool Upd(TShop shop);

        bool Del(int id);

        int ShopIsUsed(int id);

    }
}
