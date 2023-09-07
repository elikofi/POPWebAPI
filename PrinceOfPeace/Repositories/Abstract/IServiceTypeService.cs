using System;
using PrinceOfPeace.Models.DTO;

namespace PrinceOfPeace.Repositories.Abstract
{
	public interface IServiceTypeService
	{
        Task<Status> AddAsync(ServiceTypes model);

        Task<Status> UpdateAsync(ServiceTypes model);   

        Task<Status> DeleteAsync(Guid id);

        ServiceTypes? FindById(Guid id);

        public IEnumerable<ServiceTypes> GetAll();
    }
}

