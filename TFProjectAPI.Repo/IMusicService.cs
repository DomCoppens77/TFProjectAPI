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

        IEnumerable<string> ListBand();

        IEnumerable<TMusic> FindBand(string band);

        IEnumerable<TMusic> FindEan(string ean);

        IEnumerable<TMusic> GetPage(int page,int jump);

        int GetPageCount(int jump);
    }
}
