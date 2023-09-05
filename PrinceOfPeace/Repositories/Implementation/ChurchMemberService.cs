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

        public async Task<ChurchMember> Add(ChurchMember model)
        {
            try
            {
                await context.ChurchMembers.AddAsync(model);
                await context.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {
                return model;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                var data = context.ChurchMembers.Find(id);
                if (data != null)
                {
                    context.ChurchMembers.Remove(data);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Details(Guid id)
        {
            try
            {
                var result = this.FindById(id);
                if (result == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
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

        public bool Update(ChurchMember model)
        {
            try
            {
                context.ChurchMembers.Update(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

