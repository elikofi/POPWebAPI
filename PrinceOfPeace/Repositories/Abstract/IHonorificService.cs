using System;
using PrinceOfPeace.Models.DTO;

namespace PrinceOfPeace.Repositories.Abstract
{
	public interface IHonorificService
	{
        Task<Honorifics> Add(Honorifics model);

        public bool Update(Honorifics model);

        public bool Delete(int id);

        Honorifics? FindById(int id);

        public IEnumerable<Honorifics> GetAll();
    }
}

