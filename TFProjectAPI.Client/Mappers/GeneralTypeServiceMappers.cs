using TFProjectAPI.Client.Models;
using GM = TFProjectAPI.Global.Models;

namespace TFProjectAPI.Client.Mappers
{
    internal static class GeneralTypeServiceMappers
    {
        internal static GM.GeneralType ToGlobal(this GeneralType gt)
        {
            return new GM.GeneralType() { Id = gt.Id, Name = gt.Name};
        }

        internal static GeneralType ToClient(this GM.GeneralType gt)
        {
            if (gt is null) return null;
            else
                return new GeneralType(gt.Id, gt.Name);
        }

        internal static GM.GenYearPurch ToGlobal(this GenYearPurch yp)
        {
            return new GM.GenYearPurch() { Year = yp.Year, TypeId = yp.TypeId, GenTypeName = yp.GenTypeName, Price = yp.Price };
        }

        internal static GenYearPurch ToClient(this GM.GenYearPurch yp)
        {
            if (yp is null) return null;
            else
                return new GenYearPurch(yp.Year, yp.TypeId, yp.GenTypeName,yp.Price);
        }

        internal static GM.GenObjectSearch ToGlobal(this GenObjectSearch gos)
        {
            return new GM.GenObjectSearch() { Id = gos.Id, PRICE_EUR = gos.PRICE_EUR, TypeId = gos.TypeId, GenTypeName = gos.GenTypeName, EAN = gos.EAN, EAN_EXT = gos.EAN_EXT, ShopId = gos.ShopId, ShopName = gos.ShopName, OBJTEXT = gos.OBJTEXT };
        }

        internal static GenObjectSearch ToClient(this GM.GenObjectSearch gos)
        {
            if (gos is null) return null;
            else
                return new GenObjectSearch(gos.Id, gos.PRICE_EUR, gos.TypeId, gos.GenTypeName, gos.EAN, gos.EAN_EXT, gos.ShopId, gos.ShopName, gos.OBJTEXT);
        }
    }
}
