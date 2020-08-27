using System.ComponentModel.DataAnnotations;

namespace TFProjectAPI.Models.API.Currency
{
    public class Currency
    {
        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string Curr { get; set; }

        [StringLength(20, MinimumLength = 1)]
        public string Desc { get; set; }
    }
}