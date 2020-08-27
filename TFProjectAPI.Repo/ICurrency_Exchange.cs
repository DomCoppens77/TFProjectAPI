using System.Collections.Generic;

namespace TFProjectAPI.Repo
{
    public interface ICurrency_Exchange<TCurrXCHG>
    {
        IEnumerable<TCurrXCHG> Get();

        TCurrXCHG Get(int id);

        void Add(TCurrXCHG cxc);

        bool Upd(TCurrXCHG cxc);

        bool Del(int id);

        int Check_DateF(TCurrXCHG cxc);
        int Check_DateT(TCurrXCHG cxc);
    }
}
