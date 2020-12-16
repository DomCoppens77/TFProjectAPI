using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TFProjectAPI.Attributes;

namespace TFProjectAPI.Models.API.user
{
    public class ResetPassword
    {
        [Required]
        [StringLength(320, MinimumLength = 1)]
        [RegExEMAIL]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        [DataType(DataType.Password)]
        //[RegExPasswd]
        public string SecretAnswer { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        [DataType(DataType.Password)]
        //[RegExPasswd]
        public string Passwd { get; set; }
    }
}
