using TFProjectAPI.Client.Models;
using GM = TFProjectAPI.Global.Models;

namespace TFProjectAPI.Client.Mappers
{
    internal static class MusicMappers
    {
        internal static GM.Music ToGlobal(this Music mu)
        {
            return new GM.Music { Id = mu.Id, Band = mu.Band, Title = mu.Title, YEAR = mu.YEAR, TRACKS = mu.TRACKS, NbCDs = mu.NbCDs, NbDvds = mu.NbDvds, NbLps = mu.NbLps 
                , MTypeId  =mu.MTypeId, FormatId = mu.FormatId , SerialNbr = mu.SerialNbr, Ctry = mu.Ctry, // Music FIELDs
                TypeStr = mu.TypeStr, FormatStr = mu.FormatStr,  // NON DB FIELDs
                Price = mu.Price, Curr = mu.Curr, ShopId = mu.ShopId, ShopName = mu.ShopName, Date = mu.Date, TypeId = mu.TypeId, Signed = mu.Signed, SignedBy = mu.SignedBy, 
                EAN = mu.EAN, EAN_EXT = mu.EAN_EXT, Comment1 = mu.Comment1, Comment2 = mu.Comment2, Onwed = mu.Onwed // Object FIELDs
            };
        }

        internal static Music ToClient( this GM.Music mu)
        {
            if (mu is null) return null;
            else
            {
                return new Music(mu.Id, mu.Band, mu.Title, mu.YEAR, mu.TRACKS, mu.NbCDs, mu.NbDvds, mu.NbLps, mu.MTypeId, mu.FormatId, mu.SerialNbr, mu.Ctry, // Music FIELDs
                    mu.TypeStr, mu.FormatStr, // NON DB FIELDs
                    mu.Price, mu.Curr, mu.ShopId, mu.ShopName, mu.Date, mu.TypeId, mu.Signed, mu.SignedBy, mu.EAN, mu.EAN_EXT, mu.Comment1, mu.Comment2, mu.Onwed); //Object Fields
                
            }
        }
    }
}
