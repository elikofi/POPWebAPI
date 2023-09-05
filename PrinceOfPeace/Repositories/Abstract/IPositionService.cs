using System;
using PrinceOfPeace.Models.DTO;

namespace PrinceOfPeace.Repositories.Abstract
{
	public interface IPositionService
	{
        Task<Positions> Add(Positions model);

        public bool Update(Positions model);

        public bool Delete(Guid id);

        Positions? FindById(Guid id);

        public IEnumerable<Positions> GetAll();
    }
}

