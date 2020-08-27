using System;
using System.Data;
using TFProjectAPI.Global.Models;

namespace TFProjectAPI.Global.Mappers
{
    internal static class MusicServiceMappers
    {
        internal static Music ToMusic(this IDataRecord dr)
        {

			return new Music()
			{
				ID        = (int)dr["Id"],
				Band      = (string)dr["Band"],
				Title     = (string)dr["Title"],
				YEAR      = (int)dr["Year"],
				TRACKS    = (string)dr["TRACKS"],
				NbCDs     = (int)dr["NbCDs"],
				NbDvds    = (int)dr["NbDvds"],
				NbLps     = (int)dr["NbLps"],
				MTypeId   = (int)dr["MTypeId"],
				FormatId  = (int)dr["FormatId"],
				SerialNbr = (string)dr["SerialNbr"],
                Ctry      = (string)dr["Ctry"],

                Price = (float)(double)dr["Price"],
                Curr = (string)dr["Curr"],
                ShopId = (int)dr["ShopId"],
                Date = (DateTime)dr["Date"],
                //TypeId = (int)dr["TypeId"],
                Signed = (bool)dr["Signed"],
                SignedBy = (string)dr["SignedBy"],
                EAN = (string)dr["EAN"],
                EAN_EXT = (string)dr["EAN_EXT"],
                Comment1 = (string)dr["Comment1"],
                Comment2 = (string)dr["Comment2"],
                Onwed = (bool)dr["Onwed"]
            };
        }
    }
}
