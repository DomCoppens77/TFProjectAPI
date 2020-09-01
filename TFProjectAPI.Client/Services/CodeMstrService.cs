using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFProjectAPI.Client.Mappers;
using TFProjectAPI.Client.Models;
using TFProjectAPI.Repo;
using GS = TFProjectAPI.Global.Services.ServiceLocator;

namespace TFProjectAPI.Client.Services
{
    public class CodeMstrService : ICodeMstrService<Code_Mstr>
    {
        public IEnumerable<Code_Mstr> Get()
        {
            return GS.Instance.CodeMstrService.Get().Select(c => c.ToClient()); ;
        }

        public IEnumerable<Code_Mstr> Get(string fldname)
        {
            return GS.Instance.CodeMstrService.Get(fldname)?.Select(c => c.ToClient()); ;
        }

        public Code_Mstr Get(Code_Mstr code)
        {
            return GS.Instance.CodeMstrService.Get(code.ToGlobal())?.ToClient();
        }
        public string GetStr(string fldname)
        {
            return GS.Instance.CodeMstrService.GetStr(fldname);
        }

        public IEnumerable<string> ListFldName()
        {
            return GS.Instance.CodeMstrService.ListFldName();
        }

        public void Add(Code_Mstr code)
        {
            GS.Instance.CodeMstrService.Add(code.ToGlobal());
        }

        public bool Upd(Code_Mstr code)
        {
            return GS.Instance.CodeMstrService.Upd(code.ToGlobal());
        }

        public bool Del(string fldname, string value)
        {
            return GS.Instance.CodeMstrService.Del(fldname, value);
        }


    }
}
