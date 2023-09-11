using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrinceOfPeace.Models.Domain;
using PrinceOfPeace.Models.DTO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrinceOfPeace.Controllers
{
    [Route("api/images")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ImagesController(DatabaseContext context)
        {
            _context = context;
        }

        //Adding image of church member
        [HttpPost]
        public async Task<IActionResult> UploadImage([FromBody] ImageEntity imageEntity)
        {
            _context.Images.Add(imageEntity);
            await _context.SaveChangesAsync();
            return Ok(imageEntity.Id);
        }

        //Getting the image of a church member
        [HttpGet("{id}")]
        public IActionResult GetImage(Guid id)
        {
            var image = _context.Images.FirstOrDefault(i => i.Id == id);
            if (image == null)
            {
                return NotFound();
            }

            return File(image.ImageData, "image/jpeg"); // Adjust content type as needed
        }
    }

}

