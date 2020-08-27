using System.Collections.Generic;
using System.Linq;
using TFProjectAPI.Client.Mappers;
using TFProjectAPI.Client.Models;
using TFProjectAPI.Repo;
using GS = TFProjectAPI.Global.Services.ServiceLocator;

namespace TFProjectAPI.Client.Services
{
    public class MusicFormatService : IMusicFormatService<MusicFormat>
    {
        public MusicFormat Add(MusicFormat mf)
        {
            return GS.Instance.MusicFormatService.Add(mf.ToGlobal()).ToClient();
        }

        public bool Del(int id)
        {
            return GS.Instance.MusicFormatService.Del(id);
        }

        public IEnumerable<MusicFormat> Get()
        {
            return GS.Instance.MusicFormatService.Get().Select(mf => mf.ToClient());
        }

        public MusicFormat Get(int id)
        {
            return GS.Instance.MusicFormatService.Get(id)?.ToClient();
        }

        public int MusicFormatIsUsed(int id)
        {
            return GS.Instance.MusicFormatService.MusicFormatIsUsed(id);
        }

        public bool Upd(MusicFormat mf)
        {
            return GS.Instance.MusicFormatService.Upd(mf.ToGlobal());
        }
    }
}
