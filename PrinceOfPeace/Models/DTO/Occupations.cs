using System;
using System.ComponentModel.DataAnnotations;

namespace PrinceOfPeace.Models.DTO
{
	public class Occupations
	{
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string? Occupation { get; set; }
    }
}

