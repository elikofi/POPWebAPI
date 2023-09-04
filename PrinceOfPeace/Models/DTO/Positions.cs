using System;
using System.ComponentModel.DataAnnotations;

namespace PrinceOfPeace.Models.DTO
{
	public class Positions
	{
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string? Position { get; set; }
    }
}

