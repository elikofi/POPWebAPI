using System;
using System.ComponentModel.DataAnnotations;

namespace PrinceOfPeace.Models.DTO
{
	public class ServiceTypes
	{
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string? ServiceType { get; set; }
    }
}

