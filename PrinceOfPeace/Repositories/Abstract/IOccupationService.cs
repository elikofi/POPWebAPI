using System;
using PrinceOfPeace.Models.DTO;

namespace PrinceOfPeace.Repositories.Abstract
{
	public interface IOccupationService
	{
        Task<Occupations> Add(Occupations model);

        public bool Update(Occupations model);

        public bool Delete(Guid id);

        Occupations? FindById(Guid id);

        public IEnumerable<Occupations> GetAll();
    }
}

