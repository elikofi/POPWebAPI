using System;
using System.ComponentModel.DataAnnotations;

namespace PrinceOfPeace.Models.DTO
{
	public class Honorifics
	{
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string? HonorificName { get; set; }
    }
}

