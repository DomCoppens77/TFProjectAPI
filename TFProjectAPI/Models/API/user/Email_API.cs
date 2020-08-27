using System.ComponentModel.DataAnnotations;

namespace TFProjectAPI.Models.API.user
{
    public class Email_API
    {
        [Required]
        [StringLength(320, MinimumLength = 1)]
        [RegularExpression(@"^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")]
        public string Email { get; set; }
    }
}
