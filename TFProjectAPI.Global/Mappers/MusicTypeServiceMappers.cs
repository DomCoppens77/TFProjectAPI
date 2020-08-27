using System.Data;
using TFProjectAPI.Global.Models;


namespace TFProjectAPI.Global.Mappers
{
    internal static class MusicTypeServiceMappers
    {
        internal static MusicType ToMusicType(this IDataRecord dr)
        {
            return new MusicType()
            {
                Id = (int)dr["Id"],
                Name = (string)dr["Name"]
            };
        }
    }
}
