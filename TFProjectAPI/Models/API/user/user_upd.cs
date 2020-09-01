﻿using System.ComponentModel.DataAnnotations;
using TFProjectAPI.Attributes;

namespace TFProjectAPI.Models.API.user
{
    public class user_upd
    {
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [StringLength(320, MinimumLength = 1)]
        [RegExEMAIL]
        public string Email { get; set; }
    }
}
