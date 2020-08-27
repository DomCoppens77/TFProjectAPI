using System.Collections.Generic;

namespace TFProjectAPI.Repo
{
    public interface IMusicFormatService<TMusicFormat>
    {
        IEnumerable<TMusicFormat> Get();

        TMusicFormat Get(int id);

        TMusicFormat Add(TMusicFormat mf);

        bool Upd(TMusicFormat mf);

        bool Del(int id);

        int MusicFormatIsUsed(int id);
    }
}
