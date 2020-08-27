using System.Collections.Generic;

namespace TFProjectAPI.Repo
{
    public interface ICurrencyService<TCurrrency>
    {
        IEnumerable<TCurrrency> Get();

        TCurrrency Get(string curr);

        void Add(TCurrrency cur);

        bool Upd(TCurrrency cur);

        bool Del(string curr);

        int CurrencyIsUsed(string curr);
    }
}
