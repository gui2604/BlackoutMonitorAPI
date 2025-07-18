﻿using System.ComponentModel.DataAnnotations;

namespace BlackoutMonitorAPI.Dto
{
    public class UserRegisterDto
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MinLength(6)]
        public required string Password { get; set; }
    }
}
