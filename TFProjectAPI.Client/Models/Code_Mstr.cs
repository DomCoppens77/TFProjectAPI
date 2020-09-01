using System;
using System.Collections.Generic;
using System.Text;

namespace TFProjectAPI.Client.Models
{
    public class Code_Mstr
    {

        private string _code_Fldname, _code_Value, _code_Desc;

        public Code_Mstr(string code_fldname, string code_value, string code_desc)
        {
            Code_Fldname = code_fldname;
            Code_Value = code_value;
            Code_Desc = code_desc;
        }

        public Code_Mstr()
        {

        }

        public string Code_Fldname
        {
            get
            {
                return _code_Fldname;
            }

            set
            {
                _code_Fldname = value;
            }
        }

        public string Code_Value
        {
            get
            {
                return _code_Value;
            }

            set
            {
                _code_Value = value;
            }
        }

        public string Code_Desc
        {
            get
            {
                return _code_Desc;
            }

            set
            {
                _code_Desc = value;
            }
        }
    }
}
