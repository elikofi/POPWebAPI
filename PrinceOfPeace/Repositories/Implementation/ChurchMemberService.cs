using System;
using System.Diagnostics.CodeAnalysis;
using PrinceOfPeace.Models.Domain;
using PrinceOfPeace.Models.DTO;
using PrinceOfPeace.Repositories.Abstract;

namespace PrinceOfPeace.Repositories.Implementation
{
	public class ChurchMemberService : IChurchMemberService
	{
        private readonly DatabaseContext context;

        public ChurchMemberService(DatabaseContext context)
        {
            this.context = context;
        }

        readonly Status status = new();
        public async Task<Status> AddAsync(ChurchMember model)
        {

            try
            {
                await context.ChurchMembers.AddAsync(model);
                if (context.ChurchMembers.Any(x => x.Firstname == model.Firstname))
                {
                    if (context.ChurchMembers.Any(x => x.Lastname == model.Lastname))
                    {
                        status.StatusCode = 0;
                        status.Message = "Church member already exists.";
                        return status;
                    }
                    
                }
                await context.SaveChangesAsync();
                status.StatusCode = 1;
                status.Message = "Added new church member.";
                return status;
            }
            catch (Exception)
            {
                status.StatusCode = 0;
                status.Message = "Error occured! Couldn't add new member.";
                return status;
            }
        }
        public async Task<Status> UpdateAsync(ChurchMember model)
        {
            try
            {
                context.ChurchMembers.Update(model);
                await context.SaveChangesAsync();
                status.StatusCode = 1;
                status.Message = "Updated successfully.";
                return status;
            }
            catch (Exception)
            {
                status.StatusCode = 0;
                status.Message = "Error occured.";
                return status;
            }
        }

        public async Task<Status> DeleteAsync(Guid id)
        {
            try
            {
                var data = await context.ChurchMembers.FindAsync(id);
                if (data == null)
                {
                    status.StatusCode = 0;
                    status.Message = "Church member not found.";
                    return status;
                }
                context.ChurchMembers.Remove(data);
                await context.SaveChangesAsync();
                status.StatusCode = 1;
                status.Message = "Member deleted successfully.";
                return status;
            }
            catch (Exception)
            {
                status.StatusCode = 0;
                status.Message = "Error occured.";
                return status;
            }
        }

        public ChurchMember? FindById(Guid id)
        {
            return context.ChurchMembers.Find(id);
        }


        public IEnumerable<ChurchMember> GetAll()
        {
            var data = (from churchMember in context.ChurchMembers
                        join occupation in context.Occupations on churchMember.OccupationId equals occupation.Id
                        join position in context.Positions on churchMember.PositionId equals position.Id
                        join honorific in context.Honorifics on churchMember.HonorificId equals honorific.Id
                        join serviceType in context.ServiceTypes on churchMember.ServicetypeId equals serviceType.Id
                        select new ChurchMember
                        {
                            Id = churchMember.Id,
                            HonorificId = churchMember.HonorificId,
                            OccupationId = churchMember.OccupationId,
                            PositionId = churchMember.PositionId,
                            ServicetypeId = churchMember.ServicetypeId,
                            Firstname = churchMember.Firstname,
                            Lastname = churchMember.Lastname,
                            Birthday = churchMember.Birthday,
                            Phone1 = churchMember.Phone1,
                            Phone2 = churchMember.Phone2,
                            Email = churchMember.Email,
                            BoxAddress = churchMember.BoxAddress,
                            Housenumber = churchMember.Housenumber,
                            GPSaddress = churchMember.GPSaddress,
                            HonorificName = honorific.HonorificName,
                            OccupationName = occupation.Occupation,
                            PositionName = position.Position,
                            ServicetypeName = serviceType.ServiceType
                        }).ToList();
            return data;

        }

        public IEnumerable<ChurchMember> GetBySearch()
        {
            var data = (from churchMember in context.ChurchMembers
                        join occupation in context.Occupations on churchMember.OccupationId equals occupation.Id
                        join position in context.Positions on churchMember.PositionId equals position.Id
                        join honorific in context.Honorifics on churchMember.HonorificId equals honorific.Id
                        join serviceType in context.ServiceTypes on churchMember.ServicetypeId equals serviceType.Id
                        select new ChurchMember
                        {
                            Id = churchMember.Id,
                            HonorificId = churchMember.HonorificId,
                            OccupationId = churchMember.OccupationId,
                            PositionId = churchMember.PositionId,
                            ServicetypeId = churchMember.ServicetypeId,
                            Firstname = churchMember.Firstname,
                            Middlename = churchMember.Middlename,
                            Lastname = churchMember.Lastname,
                            Birthday = churchMember.Birthday,
                            Phone1 = churchMember.Phone1,
                            Phone2 = churchMember.Phone2,
                            Email = churchMember.Email,
                            BoxAddress = churchMember.BoxAddress,
                            Housenumber = churchMember.Housenumber,
                            GPSaddress = churchMember.GPSaddress,
                            HonorificName = honorific.HonorificName,
                            OccupationName = occupation.Occupation,
                            PositionName = position.Position,
                            ServicetypeName = serviceType.ServiceType
                        }).ToList();
            return data;
        }

        public async Task<Status> DetailsAsync(Guid id)
        {
            var result = await context.ChurchMembers.FindAsync(id);
            if (result != null)
            {
                status.StatusCode = 1;
                status.Message = "Details";
                return status;
            }

            status.StatusCode = 0;
            status.Message = "Bad request";
            return status;
        }
    }
}

