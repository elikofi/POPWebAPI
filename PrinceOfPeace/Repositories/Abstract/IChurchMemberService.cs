using System;
using PrinceOfPeace.Models.DTO;

namespace PrinceOfPeace.Repositories.Abstract
{
	public interface IChurchMemberService
	{
        Task<Status> AddAsync(ChurchMember model);

        Task<Status> UpdateAsync(ChurchMember model);

        Task<Status> DeleteAsync(Guid id);  

        ChurchMember? FindById(Guid id);

        public IEnumerable<ChurchMember> GetAll();

        public IEnumerable<ChurchMember> GetBySearch();

        Task<Status> DetailsAsync(Guid id); 
    }
}

