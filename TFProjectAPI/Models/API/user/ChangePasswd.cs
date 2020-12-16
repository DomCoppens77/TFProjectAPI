using System.ComponentModel.DataAnnotations;
using TFProjectAPI.Attributes;

namespace TFProjectAPI.Models.API.user
{
    public class ChangePasswd
    {
        [Required]
        [StringLength(320, MinimumLength = 1)]
        [RegExEMAIL]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        [DataType(DataType.Password)]
        //[RegExPasswd]
        public string OldPasswd { get; set; }
        
        [Required]
        [StringLength(20, MinimumLength = 6)]
        [DataType(DataType.Password)]
        //[RegExPasswd]
        public string Passwd { get; set; }
    }
}
