using System;
using PrinceOfPeace.Models.DTO;

namespace PrinceOfPeace.Repositories.Abstract
{
	public interface IOccupationService
	{
        Task<Status> AddAsync(Occupations model);

        Task<Status> UpdateAsync(Occupations model);

        Task<Status> DeleteAsync(Guid id);

        Occupations? FindById(Guid id);

        public IEnumerable<Occupations> GetAll();
    }
}

