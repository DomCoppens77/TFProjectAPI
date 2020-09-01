using System.Data;
using TFProjectAPI.Global.Models;


namespace TFProjectAPI.Global.Mappers
{
    internal static class MusicFormatServiceMappers
    {
        internal static MusicFormat ToMusicFrmt(this IDataRecord dr)
        {
            return new MusicFormat()
            {
                Id = (int)dr["Id"],
                Name = dr["Name"].ToString()
            };
        }
    }
}
