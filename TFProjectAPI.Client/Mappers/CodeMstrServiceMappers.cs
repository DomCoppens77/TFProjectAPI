
using TFProjectAPI.Client.Models;
using GM = TFProjectAPI.Global.Models;

namespace TFProjectAPI.Client.Mappers
{
    internal static class CodeMstrServiceMappers
{
        internal static GM.Code_Mstr ToGlobal(this Code_Mstr cm)
        {
            return new GM.Code_Mstr() { code_fldname = cm.Code_Fldname, code_value = cm.Code_Value, code_desc = cm.Code_Desc };
        }

        internal static Code_Mstr ToClient(this GM.Code_Mstr cm)
        {
            if (cm is null) return null;
            else
                return new Code_Mstr(cm.code_fldname, cm.code_value, cm.code_desc);
        }
    }
}
