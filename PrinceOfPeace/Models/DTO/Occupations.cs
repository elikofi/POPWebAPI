using System;
using System.ComponentModel.DataAnnotations;

namespace PrinceOfPeace.Models.DTO
{
	public class Occupations
	{
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Occupation { get; set; }
    }
}

