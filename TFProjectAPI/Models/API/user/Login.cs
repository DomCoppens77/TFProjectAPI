using System.ComponentModel.DataAnnotations;

namespace TFProjectAPI.Models.API.user
{
    public class Login
    {
        [Required]
        [StringLength(320, MinimumLength = 1)]
        [RegularExpression(@"^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        [DataType(DataType.Password)]
        //[RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-=]).{7,50}$")]
        public string Passwd { get; set; }
    }
}
