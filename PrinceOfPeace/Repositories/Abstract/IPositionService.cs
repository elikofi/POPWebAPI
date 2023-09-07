using System;
using PrinceOfPeace.Models.DTO;

namespace PrinceOfPeace.Repositories.Abstract
{
	public interface IPositionService
	{
        Task<Status> AddAsync(Positions model);

        Task<Status> UpdateAsync(Positions model);

        Task<Status> DeleteAsync(Guid id);

        Positions? FindById(Guid id);

        public IEnumerable<Positions> GetAll();
    }
}

    