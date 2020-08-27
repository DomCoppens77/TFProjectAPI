using TFProjectAPI.Client.Models;
using GM = TFProjectAPI.Global.Models;

namespace TFProjectAPI.Client.Mappers
{
    internal static class Currency_ExchangeMappers
    {

        internal static GM.Currency_Exchange ToGlobal(this Currency_Exchange curx)
        {
            return new GM.Currency_Exchange() { Id = curx.Id, CurrFrom = curx.CurrFrom, CurrTo = curx.CurrTo, DateFrom = curx.DateFrom, DateTo = curx.DateTo, Rate = curx.Rate };
        }

        internal static Currency_Exchange ToClient(this GM.Currency_Exchange curx)
        {
            if (curx is null) return null;
            else
                return new Currency_Exchange(curx.Id, curx.CurrFrom, curx.CurrTo, curx.DateFrom, curx.DateTo, curx.Rate);
        }
    }
}
