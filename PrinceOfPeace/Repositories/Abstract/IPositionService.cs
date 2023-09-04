using System;
using PrinceOfPeace.Models.DTO;

namespace PrinceOfPeace.Repositories.Abstract
{
	public interface IPositionService
	{
        Task<Positions> Add(Positions model);

        public bool Update(Positions model);

        public bool Delete(int id);

        Positions? FindById(int id);

        public IEnumerable<Positions> GetAll();
    }
}

