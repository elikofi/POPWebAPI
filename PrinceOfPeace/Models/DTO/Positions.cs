using System;
using System.ComponentModel.DataAnnotations;

namespace PrinceOfPeace.Models.DTO
{
	public class Positions
	{
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Position { get; set; }
    }
}

