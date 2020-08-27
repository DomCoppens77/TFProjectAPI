using System.Collections.Generic;

namespace TFProjectAPI.Repo
{
    public interface IMusicTypeService<TMusicType>
    {
        IEnumerable<TMusicType> Get();

        TMusicType Get(int id);

        TMusicType Add(TMusicType mt);

        bool Upd(TMusicType mt);

        bool Del(int id);

        int MusicTypeIsUsed(int id);
    }
}
