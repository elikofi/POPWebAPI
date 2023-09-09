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
    public class ServiceTypesController : ControllerBase
    {
        private readonly IServiceTypeService service;

        public ServiceTypesController(IServiceTypeService service)
        {
            this.service = service;
        }

        //Add method
        
        [HttpPost]
        [Route("Add")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddAsync(ServiceTypes model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var result = await service.AddAsync(model);
                if (result.StatusCode == 1)
                {
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        [HttpPost]
        [Route("{id:guid}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, ServiceTypes model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await service.UpdateAsync(model);
            if (result.StatusCode == 1)
            {
                return Ok(result);
            }

            
            return BadRequest();
        }
        //Delete
        [HttpDelete]
        [Route("Delete")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await service.DeleteAsync(id);
            if (result.StatusCode == 1)
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
            var data = service.GetAll().OrderBy(data => data.ServiceType).ToList();
            return Ok(data);
        }

        [HttpGet]
        [Route("FindById")]
        public IActionResult FindById(Guid id)
        {
            var result = service.Find(id);
            return Ok(result);
        }
    }
}

