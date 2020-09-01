using System.ComponentModel.DataAnnotations;
using TFProjectAPI.Attributes;

namespace TFProjectAPI.Models.API.user
{
    public class Email_API
    {
        [Required]
        [StringLength(320, MinimumLength = 1)]
        [RegExEMAIL]
        public string Email { get; set; }
    }
}
