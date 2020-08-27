using System.Collections.Generic;
using System.Linq;
using TFProjectAPI.Client.Mappers;
using TFProjectAPI.Client.Models;
using TFProjectAPI.Repo;
using GS = TFProjectAPI.Global.Services.ServiceLocator;

namespace TFProjectAPI.Client.Services
{
    public class MusicTypeService : IMusicTypeService<MusicType>

    {
        public MusicType Add(MusicType mt)
        {
            return GS.Instance.MusicTypeService.Add(mt.ToGlobal()).ToClient();
        }

        public bool Del(int id)
        {
            return GS.Instance.MusicTypeService.Del(id);
        }

        public IEnumerable<MusicType> Get()
        {
            return GS.Instance.MusicTypeService.Get().Select(mt => mt.ToClient());
        }

        public MusicType Get(int id)
        {
            return GS.Instance.MusicTypeService.Get(id)?.ToClient();
        }

        public int MusicTypeIsUsed(int id)
        {
            return GS.Instance.MusicTypeService.MusicTypeIsUsed(id);
        }

        public bool Upd(MusicType mt)
        {
            return GS.Instance.MusicTypeService.Upd(mt.ToGlobal());
        }
    }
}
