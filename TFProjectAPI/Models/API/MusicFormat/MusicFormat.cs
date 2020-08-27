using System.ComponentModel.DataAnnotations;

namespace TFProjectAPI.Models.API.MusicFormat
{
    public class MusicFormat
    {
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Name { get; set; }
    }
}
