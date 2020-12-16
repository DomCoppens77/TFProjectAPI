using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TFProjectAPI.Global.Mappers;
using TFProjectAPI.Global.Models;
using TFProjectAPI.Repo;
using TFProjectAPI.ToolBox.Database;

namespace TFProjectAPI.Global.Services
{
    class CodeMstrService : ICodeMstrService<Code_Mstr>

    {
        private string where = "GCDM";
        private string str_Get = "Select * From [AppUser].[V_Code_Mstr]";
        public IEnumerable<Code_Mstr> Get(string fldname)
        {
            try
            {
                DBCommand command = new DBCommand("[AppUser].[GetCodeMstr]", true);
                command.AddParameter("code_fldname", fldname);
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToCodeMstr());
            }
            catch (Exception e) { throw e; }
        }

        public IEnumerable<Code_Mstr> Get()
        {
            try
            {
                DBCommand command = new DBCommand(str_Get + ";");
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToCodeMstr());
            }
            catch (Exception e) { throw e; }
        }

        public Code_Mstr Get(Code_Mstr code)
        {
            try
            {
                if (code is null) throw new DataException("Shop Data empty (" + where + ") (GET)");
                DBCommand command = new DBCommand("[AppUser].[GetCodeMstrOne]", true);
                command.AddParameter("code_fldname", code.code_fldname);
                command.AddParameter("code_value", code.code_value);
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToCodeMstr()).SingleOrDefault();
            }
            catch (Exception e) { throw e; }
        }

        public string GetStr(string fldname)
        {
            try
            {
                DBCommand command = new DBCommand("[AppUser].[GetCodeMstrFirst]", true);
                command.AddParameter("code_fldname", fldname);
                return (string)ServiceLocator.Instance.Connection.ExecuteScalar(command);
            }
            catch (Exception e) { throw e; }
        }

        public IEnumerable<string> ListFldName()
        {
            try
            {
                DBCommand command = new DBCommand("[AppUser].[ListFldName]", true);
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => { return dr["code_fldname"].ToString(); });
            }
            catch (Exception e) { throw e; }
        }

        public void Add(Code_Mstr code)
        {
            try
            {
                if (code is null) throw new DataException("Shop Data empty (" + where + ") (ADD)");
                DBCommand command = new DBCommand("[AppUser].[AddCodeMstr]", true);
                command.AddParameter("code_fldname", code.code_fldname);
                command.AddParameter("code_value", code.code_value);
                command.AddParameter("code_desc", code.code_desc);
                ServiceLocator.Instance.Connection.ExecuteScalar(command);
            }
            catch (Exception e) { throw e; }
        }

        public bool Upd(Code_Mstr code)
        {
            try
            {
                if (code is null) throw new DataException("Shop Data empty (" + where + ") (UPD)");
                DBCommand command = new DBCommand("[AppUser].[UpdCodeMstr]", true);
                command.AddParameter("code_fldname", code.code_fldname);
                command.AddParameter("code_value", code.code_value);
                command.AddParameter("code_desc", code.code_desc);
                return ServiceLocator.Instance.Connection.ExecuteNonQuery(command) == 1;
            }
            catch (Exception e) { throw e; }
        }

        public bool Del(string fldname, string value)
        {
            try
            {
                DBCommand command = new DBCommand("[AppUser].[DelCodeMstr]", true);
                command.AddParameter("code_fldname", fldname);
                command.AddParameter("code_value", value);
                return ServiceLocator.Instance.Connection.ExecuteNonQuery(command) == 1;
            }
            catch (Exception e) { throw e; }
        }
    }
}
