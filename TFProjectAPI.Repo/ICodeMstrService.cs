using System;
using System.Collections.Generic;
using System.Text;

namespace TFProjectAPI.Repo
{
    public interface ICodeMstrService<TCode>
    {
        IEnumerable<TCode> Get();

        IEnumerable<TCode> Get(string fldname);

        TCode Get(TCode code);
        
        string GetStr(string fldname);

        IEnumerable<string> ListFldName();

        void Add(TCode code);

        bool Upd(TCode code);

        bool Del(string fldname, string value);

    }
}
