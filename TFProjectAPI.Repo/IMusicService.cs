using System.Collections.Generic;

namespace TFProjectAPI.Repo
{
    public interface IMusicService<TMusic>
    {
        IEnumerable<TMusic> Get();

        TMusic Get(int id);

        TMusic Add(TMusic mu);

        bool Upd(TMusic mu);

        bool Del(int id);
    }
}
