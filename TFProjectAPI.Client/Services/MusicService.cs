using System.Collections.Generic;
using System.Linq;
using TFProjectAPI.Client.Mappers;
using TFProjectAPI.Client.Models;
using TFProjectAPI.Repo;
using GS = TFProjectAPI.Global.Services.ServiceLocator;

namespace TFProjectAPI.Client.Services
{
    public class MusicService : IMusicService<Music>
    {
        public Music Add(Music mu)
        {
            return GS.Instance.MusicService.Add(mu.ToGlobal()).ToClient();
        }

        public bool Del(int id)
        {
            return GS.Instance.MusicService.Del(id);
        }

        public IEnumerable<Music> Get()
        {
            return GS.Instance.MusicService.Get().Select(m => m.ToClient());
        }

        public Music Get(int id)
        {
            return GS.Instance.MusicService.Get(id)?.ToClient();
        }

        public bool Upd(Music mu)
        {
            return GS.Instance.MusicService.Upd(mu.ToGlobal());
        }


    }
}
