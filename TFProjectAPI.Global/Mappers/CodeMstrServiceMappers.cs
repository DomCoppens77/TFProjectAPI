using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TFProjectAPI.Global.Models;

namespace TFProjectAPI.Global.Mappers
{
    internal static class CodeMstrServiceMappers
    {
        internal static Code_Mstr ToCodeMstr(this IDataRecord dr)
        {
            return new Code_Mstr()
            {
                code_fldname = dr["code_fldname"].ToString(),
                code_value = dr["code_value"].ToString(),
                code_desc = dr["code_desc"].ToString()
            };
        }
    }
}
