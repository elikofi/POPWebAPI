using System;
using PrinceOfPeace.Models.DTO;

namespace PrinceOfPeace.Repositories.Abstract
{
	public interface IUserAuthenticationService
	{
        Task<Status> LoginAsync(LoginModel model);

        Task<Status> RegistrationAsync(RegistrationModel model);

        Task LogoutAsync();
    }
}

