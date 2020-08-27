using System.ComponentModel.DataAnnotations;

namespace TFProjectAPI.Models.API.Country
{
    public class Country
    {
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string ISO { get; set; }

        [StringLength(20, MinimumLength = 1)]
        public string Ctry { get; set; }
        public bool IsEU { get; set; }
    }
}
