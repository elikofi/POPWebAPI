﻿using System;
using System.Collections.Generic;
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
    public class UserAuthenticationController : ControllerBase
    {
        private readonly IUserAuthenticationService service;

        public UserAuthenticationController(IUserAuthenticationService service)
        {
            this.service = service;
        }

        

        //Registering a new user who wouldn't be an admin.
        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            model.Role = "user";
            var result = await service.RegistrationAsync(model);

            return Ok(result);
        }


        //Login method
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return Ok("Unable to login.");
            }

            var result = await service.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                return Ok("Login successful.");
            }
            else
            {
                return NotFound();
            }
        }


        //Logout
        [Authorize]
        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await service.LogoutAsync();
            return Ok();
        }




        //This method is deactivated on purpose



        //Admin
        //[HttpGet(Name = "Admin register")]
        //public async Task<IActionResult> Register()
        //{
        //    var model = new RegistrationModel
        //    {
        //        Username = "admin",
        //        Name = "Elijah Amoako",
        //        Email = "elijahamoako72@gmail.com",
        //        Password = "Elijah@12345#",
        //        Role = "admin"
        //    };
        //    var result = await service.RegistrationAsync(model);
        //    return Ok(result);
        //}
    }
}

