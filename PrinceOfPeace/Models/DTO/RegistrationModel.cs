using System;
using System.ComponentModel.DataAnnotations;

namespace PrinceOfPeace.Models.DTO
{
	public class RegistrationModel
	{
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Password must have a minimum of * characters, at least 1 uppercase and lowercase english letters, at least 1 digit and at least 1 special character.")]
        public string Password { get; set; }


        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string? Role { get; set; }
    }
}

