using System.ComponentModel.DataAnnotations;

namespace TFProjectAPI.Models.API.MusicType
{
    public class MusicType
    {
        [Required]
        [StringLength(10, MinimumLength = 1)]
        public string Name { get; set; }
    }
}
