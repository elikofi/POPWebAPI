using System;
namespace PrinceOfPeace.Models.DTO
{
	public class ImageEntity
	{
        public Guid Id { get; set; } = Guid.NewGuid();

        public string ImageName { get; set; }

        public byte[] ImageData { get; set; }
    }
}

