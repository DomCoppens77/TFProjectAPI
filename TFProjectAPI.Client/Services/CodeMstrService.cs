using System;
using System.Collections.Generic;
using System.Data;
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
        private string where = "CCDM";
        public IEnumerable<Code_Mstr> Get()
        {
            
            try { return GS.Instance.CodeMstrService.Get().Select(c => c.ToClient()); }
            catch (Exception e) { throw e; }
        }

        public IEnumerable<Code_Mstr> Get(string fldname)
        {
            try { return GS.Instance.CodeMstrService.Get(fldname)?.Select(c => c.ToClient()); }
            catch (Exception e) { throw e; }
        }

        public Code_Mstr Get(Code_Mstr code)
        {
            try {
                if (code is null) throw new DataException("Shop Data empty (" + where + ") (GET)");
                return GS.Instance.CodeMstrService.Get(code.ToGlobal())?.ToClient(); }
            catch (Exception e) { throw e; }
        }
        public string GetStr(string fldname)
        {
            try { return GS.Instance.CodeMstrService.GetStr(fldname); }
            catch (Exception e) { throw e; }
        }

        public IEnumerable<string> ListFldName()
        {
            try { return GS.Instance.CodeMstrService.ListFldName(); }
            catch (Exception e) { throw e; }
        }

        public void Add(Code_Mstr code)
        {
            try {
                if (code is null) throw new DataException("Shop Data empty (" + where + ") (ADD)");
                GS.Instance.CodeMstrService.Add(code.ToGlobal()); }
            catch (Exception e) { throw e; }
            
        }

        public bool Upd(Code_Mstr code)
        {
            try
            {
                if (code is null) throw new DataException("Shop Data empty (" + where + ") (UPD)");
                return GS.Instance.CodeMstrService.Upd(code.ToGlobal());
            }
            catch (Exception e) { throw e; }
        }

        public bool Del(string fldname, string value)
        {
            try { return GS.Instance.CodeMstrService.Del(fldname, value); }
            catch (Exception e) { throw e; }
        }
    }
}
