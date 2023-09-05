using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrinceOfPeace.Models.DTO;
using PrinceOfPeace.Repositories.Abstract;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrinceOfPeace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HonorificsController : ControllerBase
    {
        private readonly IHonorificService service;

        public HonorificsController(IHonorificService service)
        {
            this.service = service;
        }

        //Add method

        [HttpPost]
        [Route("Add")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Add(Honorifics model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var result = await service.Add(model);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        //Update method
        //[Authorize(Roles = "admin")]
        //[HttpGet]
        //[Route("Update")]
        //public IActionResult Update(int id)
        //{
        //    var result = service.FindById(id);
        //    return Ok(result);
        //}

        [HttpPost]
        [Route("{id:guid}")]
        [Authorize(Roles = "admin")]
        public IActionResult Update([FromRoute] Guid id, Honorifics model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = service.Update(model);
            if (result)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        //Get all the list
        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles = "admin")]
        public IActionResult GetAll()
        {
            var data = service.GetAll().OrderBy(data => data.HonorificName).ToList();
            return Ok(data);
        }

        //Delete
        [HttpDelete]
        [Route("Delete")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(Guid id)
        {
            var result = service.Delete(id);
            if (result)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}

