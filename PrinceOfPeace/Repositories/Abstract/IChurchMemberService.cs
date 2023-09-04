using System;
using PrinceOfPeace.Models.DTO;

namespace PrinceOfPeace.Repositories.Abstract
{
	public interface IChurchMemberService
	{
        Task<ChurchMember> Add(ChurchMember model);

        public bool Update(ChurchMember model);

        public bool Delete(int id);

        ChurchMember? FindById(int id);

        public IEnumerable<ChurchMember> GetAll();

        public IEnumerable<ChurchMember> GetBySearch();

        public bool Details(int id);
    }
}

