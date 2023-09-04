using System;
using PrinceOfPeace.Models.DTO;

namespace PrinceOfPeace.Repositories.Abstract
{
	public interface IOccupationService
	{
        Task<Occupations> Add(Occupations model);

        public bool Update(Occupations model);

        public bool Delete(int id);

        Occupations? FindById(int id);

        public IEnumerable<Occupations> GetAll();
    }
}

