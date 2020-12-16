using System.ComponentModel.DataAnnotations;
using TFProjectAPI.Attributes;

namespace TFProjectAPI.Models.API.user
{
    public class user_add
    {
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [StringLength(320, MinimumLength = 1)]
        [RegExEMAIL]
        //[RegularExpression(@"^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        [DataType(DataType.Password)]
        //[RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-=]).{7,50}$")]
        public string Passwd { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string SecretAnswer { get; set; }

        public string Avatar { get; set; }

    }
}
