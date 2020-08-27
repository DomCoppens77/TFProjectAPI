using TFProjectAPI.Client.Models;
using GM = TFProjectAPI.Global.Models;

namespace TFProjectAPI.Client.Mappers
{
    internal static class MusicTypeServiceMappers
    {
        internal static GM.MusicType ToGlobal(this MusicType mt)
        {
            return new GM.MusicType() { Id = mt.Id, Name = mt.Name };
        }

        internal static MusicType ToClient(this GM.MusicType mt)
        {
            if (mt is null) return null;
            else
                return new MusicType(mt.Id, mt.Name);
        }
    }
}
