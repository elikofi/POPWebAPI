using System;
using PrinceOfPeace.Models.DTO;

namespace PrinceOfPeace.Repositories.Abstract
{
	public interface IChurchMemberService
	{
        Task<ChurchMember> Add(ChurchMember model);

        public bool Update(ChurchMember model);

        public bool Delete(Guid id);

        ChurchMember? FindById(Guid id);

        public IEnumerable<ChurchMember> GetAll();

        public IEnumerable<ChurchMember> GetBySearch();

        public bool Details(Guid id);
    }
}

