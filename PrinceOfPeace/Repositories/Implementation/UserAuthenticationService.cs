using System;
using Microsoft.AspNetCore.Identity;
using PrinceOfPeace.Models.Domain;
using PrinceOfPeace.Models.DTO;
using System.Security.Claims;
using PrinceOfPeace.Repositories.Abstract;

namespace PrinceOfPeace.Repositories.Implementation
{
	public class UserAuthenticationService : IUserAuthenticationService
	{
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;


        public UserAuthenticationService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        //LOGIN METHOD
        //For users who already have an account
        public async Task<Status> LoginAsync(LoginModel model)
        {
            //Checking for the username
            var status = new Status();
            var user = await userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                status.StatusCode = 0;
                status.Message = "Invalid username.";
                return status;
            }

            //Checking for the password if it's incorrect
            if (!await userManager.CheckPasswordAsync(user, model.Password))
            {
                status.StatusCode = 0;
                status.Message = "Incorrect password.";
                return status;
            }

            //If both username and password are correct...let's Sign In

            var signInResult = await signInManager.PasswordSignInAsync(user, model.Password, false, true);
            if (signInResult.Succeeded)
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new(ClaimTypes.Name, user.UserName)
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                status.StatusCode = 1;
                status.Message = "Login successful.";
                return status;
            }
            else if (signInResult.IsLockedOut)
            {
                status.StatusCode = 0;
                status.Message = "User logged out.";
                return status;
            }

            else
            {
                status.StatusCode = 0;
                status.Message = "Login not successful.";
                return status;
            }

        }


        //Logout
        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }



        //USER REGISTRATION
        public async Task<Status> RegistrationAsync(RegistrationModel model)
        {
            //Checking to see if the user already exists.
            var status = new Status();
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                status.StatusCode = 0;
                status.Message = "User already exists.";
                return status;
            }

            //if we don't find the user, then we create the user.
            ApplicationUser user = new()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                Name = model.Name,
                Email = model.Email,
                UserName = model.Username,
                EmailConfirmed = true
            };
            //Creating user
            var result = await userManager.CreateAsync(user, model.Password);
            //if creating doesn't go well...
            if (!result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "Unable to create user.";
                return status;
            }

            //if creating goes well...
            //Role management
            //If the role doesn't exist, we create a new role.
            if (!await roleManager.RoleExistsAsync(model.Role))
            {
                await roleManager.CreateAsync(new IdentityRole(model.Role));
            }

            //if role exists
            //match the user to the role
            if (await roleManager.RoleExistsAsync(model.Role))
            {
                await userManager.AddToRoleAsync(user, model.Role);
            }

            status.StatusCode = 1;
            status.Message = "User registered!";
            return status;
        }
    }
}

