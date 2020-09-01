using System;
using System.Collections.Generic;
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
        public IEnumerable<Code_Mstr> Get(string fldname)
        {
            DBCommand command = new DBCommand("[AppUser].[GetCodeMstr]", true);
            command.AddParameter("code_fldname", fldname);
            return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToCodeMstr());
        }

        public IEnumerable<Code_Mstr> Get()
        {
            DBCommand command = new DBCommand("Select * From [AppUser].[V_Code_Mstr];");
            return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToCodeMstr());
        }

        public Code_Mstr Get(Code_Mstr code)
        {
            DBCommand command = new DBCommand("[AppUser].[GetCodeMstrOne]", true);
            command.AddParameter("code_fldname", code.code_fldname);
            command.AddParameter("code_value", code.code_value);
            return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToCodeMstr()).SingleOrDefault();
        }

        public string GetStr(string fldname)
        {
            DBCommand command = new DBCommand("[AppUser].[GetCodeMstrFirst]", true);
            command.AddParameter("code_fldname", fldname);
            return (string)ServiceLocator.Instance.Connection.ExecuteScalar(command);
        }

        public IEnumerable<string> ListFldName()
        {
            DBCommand command = new DBCommand("[AppUser].[ListFldName]", true);
            return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => { return dr["code_fldname"].ToString(); });
        }

        public void Add(Code_Mstr code)
        {
            DBCommand command = new DBCommand("[AppUser].[AddCodeMstr]", true);
            command.AddParameter("code_fldname", code.code_fldname);
            command.AddParameter("code_value", code.code_value);
            command.AddParameter("code_desc", code.code_desc);
            ServiceLocator.Instance.Connection.ExecuteScalar(command);
        }

        public bool Del(string fldname, string value)
        {
            DBCommand command = new DBCommand("[AppUser].[DelCodeMstr]", true);
            command.AddParameter("code_fldname", fldname);
            command.AddParameter("code_value", value);
            return ServiceLocator.Instance.Connection.ExecuteNonQuery(command) == 1;
        }

        public bool Upd(Code_Mstr code)
        {

            DBCommand command = new DBCommand("[AppUser].[UpdCodeMstr]", true);
            command.AddParameter("code_fldname", code.code_fldname);
            command.AddParameter("code_value", code.code_value);
            command.AddParameter("code_desc", code.code_desc);
            return ServiceLocator.Instance.Connection.ExecuteNonQuery(command) == 1;
        }


    }
}
