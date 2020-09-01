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
                ID = (int)dr["Id"],
                Band = dr["Band"].ToString(),
                Title = dr["Title"].ToString(),
                YEAR = (int)dr["Year"],
                TRACKS = (dr["TRACKS"] == DBNull.Value) ? "" : dr["TRACKS"].ToString(),
                NbCDs = (int)dr["NbCDs"],
                NbDvds = (int)dr["NbDvds"],
                NbLps = (int)dr["NbLps"],
                MTypeId = (int)dr["MTypeId"],
                FormatId = (int)dr["FormatId"],
                SerialNbr = (dr["SerialNbr"] == DBNull.Value) ? "" : dr["SerialNbr"].ToString(),
                Ctry = (dr["Ctry"] == DBNull.Value) ? "" : dr["Ctry"].ToString(),

                TypeStr = (dr["MusicTypeName"] == DBNull.Value) ? "" : (string)dr["MusicTypeName"].ToString(),
                FormatStr = (dr["MusicFormatName"] == DBNull.Value) ? "" : (string)dr["MusicFormatName"].ToString(),


                Price = (float)(double)dr["Price"],
                Curr = dr["Curr"].ToString(),
                ShopId = (int)dr["ShopId"],
                ShopName = dr["ShopName"].ToString(),
                Date = (dr["Date"] == DBNull.Value) ? null : (DateTime?)dr["Date"],
                //TypeId = (int)dr["TypeId"],
                Signed = (bool)dr["Signed"],
                SignedBy = (dr["SignedBy"] == DBNull.Value) ? "" : dr["SignedBy"].ToString(),
                EAN = (dr["EAN"] == DBNull.Value) ? "" : dr["EAN"].ToString(),
                EAN_EXT = (dr["EAN_EXT"] == DBNull.Value) ? "" : dr["EAN_EXT"].ToString(),
                Comment1 = (dr["Comment1"] == DBNull.Value) ? "" : dr["Comment1"].ToString(),
                Comment2 = (dr["Comment2"] == DBNull.Value) ? "" : dr["Comment2"].ToString(),
                Onwed = (bool)dr["Onwed"]


            };
        }
    }
}
