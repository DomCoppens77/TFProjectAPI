using TFProjectAPI.Client.Models;
using GM = TFProjectAPI.Global.Models;

namespace TFProjectAPI.Client.Mappers
{
    internal static class MusicFormatServiceMappers
    {
        internal static GM.MusicFormat ToGlobal(this MusicFormat mf)
        {
            return new GM.MusicFormat() { Id = mf.Id, Name = mf.Name };
        }

        internal static MusicFormat ToClient(this GM.MusicFormat mf)
        {
            if (mf is null) return null;
            else
                return new MusicFormat(mf.Id, mf.Name);
        }
    }
}
