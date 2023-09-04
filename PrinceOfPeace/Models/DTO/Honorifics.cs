using System;
using System.ComponentModel.DataAnnotations;

namespace PrinceOfPeace.Models.DTO
{
	public class Honorifics
	{
        [Key]
        public int Id { get; set; }
        [Required]
        public string? HonorificName { get; set; }
    }
}

