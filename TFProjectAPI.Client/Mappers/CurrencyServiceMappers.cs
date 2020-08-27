using TFProjectAPI.Client.Models;
using GM = TFProjectAPI.Global.Models;

namespace TFProjectAPI.Client.Mappers
{
    internal static class CurrencyServiceMappers
    {
        internal static GM.Currency ToGlobal(this Currency cur)
        {
            return new GM.Currency() { Curr = cur.Curr, Desc = cur.Desc };
        }

        internal static Currency ToClient(this GM.Currency cur)
        {
            if (cur is null) return null;
            else
                return new Currency(cur.Curr, cur.Desc);
        }
    }

}
