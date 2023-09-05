using System;
using PrinceOfPeace.Models.Domain;
using PrinceOfPeace.Models.DTO;
using PrinceOfPeace.Repositories.Abstract;

namespace PrinceOfPeace.Repositories.Implementation
{
	public class OccupationService : IOccupationService
	{
		private readonly DatabaseContext context;

        public OccupationService(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<Occupations> Add(Occupations model)
        {
            try
            {
                await context.Occupations.AddAsync(model);
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
                var result = context.Occupations.Find(id);
                if (result == null)
                {
                    return false;
                }
                context.Occupations.Remove(result);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Occupations? FindById(Guid id)
        {
            return context.Occupations.Find(id);
        }

        public IEnumerable<Occupations> GetAll()
        {
            return context.Occupations.ToList();
        }

        public bool Update(Occupations model)
        {
            try
            {
                context.Occupations.Update(model);
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

