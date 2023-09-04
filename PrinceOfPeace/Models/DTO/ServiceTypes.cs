using System;
using System.ComponentModel.DataAnnotations;

namespace PrinceOfPeace.Models.DTO
{
	public class ServiceTypes
	{
        [Key]
        public int Id { get; set; }
        [Required]
        public string? ServiceType { get; set; }
    }
}

