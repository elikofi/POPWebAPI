using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrinceOfPeace.Models.DTO;
using PrinceOfPeace.Repositories.Abstract;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrinceOfPeace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChurchMemberController : ControllerBase
    {
        private readonly IHonorificService honorificService;
        private readonly IOccupationService occupationService;
        private readonly IPositionService positionService;
        private readonly IServiceTypeService serviceTypeService;
        private readonly IChurchMemberService churchMemberService;
        //private readonly IWebHostEnvironment _webHostEnvironment;

        public ChurchMemberController(IHonorificService honorificService, IOccupationService occupationService, IPositionService positionService, IServiceTypeService serviceTypeService, IChurchMemberService churchMemberService, IWebHostEnvironment webHostEnvironment)
        {
            this.honorificService = honorificService;
            this.occupationService = occupationService;
            this.positionService = positionService;
            this.serviceTypeService = serviceTypeService;
            this.churchMemberService = churchMemberService;
            //_webHostEnvironment = webHostEnvironment;
        }


        [HttpPost]
        [Route("Add")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Add(ChurchMember model/*, IFormFile file*/)
        {
            model.HonorificList = honorificService.GetAll().Select(a => new SelectListItem { Text = a.HonorificName, Value = a.Id.ToString(), Selected = a.Id == model.HonorificId }).ToList();
            model.OccupationList = occupationService.GetAll().Select(a => new SelectListItem { Text = a.Occupation, Value = a.Id.ToString(), Selected = a.Id == model.OccupationId }).ToList();
            model.PositionList = positionService.GetAll().Select(a => new SelectListItem { Text = a.Position, Value = a.Id.ToString(), Selected = a.Id == model.PositionId }).ToList();
            model.ServicetypeList = serviceTypeService.GetAll().Select(a => new SelectListItem { Text = a.ServiceType, Value = a.Id.ToString(), Selected = a.Id == model.ServicetypeId }).ToList();

            
            //string wwwRootPath = _webHostEnvironment.WebRootPath;
            //if (file != null)
            //{
            //    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            //    string memberPath = Path.Combine(wwwRootPath, @"images/memberphoto");

            //    using var fileStream = new FileStream(Path.Combine(memberPath, fileName), FileMode.Create);
            //    await file.CopyToAsync(fileStream);

            //    model.ImageUrl = @"/images/memberphoto/" + fileName;
            //}


            try
            {
                var result = await churchMemberService.AddAsync(model);
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
        public async Task<IActionResult> Update([FromRoute] Guid id, ChurchMember model)
        {
            try
            {
                var result = await churchMemberService.UpdateAsync(model);
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
    }
}

