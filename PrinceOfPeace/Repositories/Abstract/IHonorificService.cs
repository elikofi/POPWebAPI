using System;
using PrinceOfPeace.Models.DTO;

namespace PrinceOfPeace.Repositories.Abstract
{
	public interface IHonorificService
	{
        Task<Status> AddAsync(Honorifics model);

        Task<Status> UpdateAsync(Honorifics model);

        Task<Status> DeleteAsync(Guid id);

        Honorifics? FindById(Guid id);

        public IEnumerable<Honorifics> GetAll();
    }
}

