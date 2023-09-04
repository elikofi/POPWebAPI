using System;
using PrinceOfPeace.Models.Domain;
using PrinceOfPeace.Models.DTO;
using PrinceOfPeace.Repositories.Abstract;

namespace PrinceOfPeace.Repositories.Implementation
{
	public class PositionService : IPositionService
	{
        private readonly DatabaseContext context;

        public PositionService(DatabaseContext context)
        {
            this.context = context;
        }


        public async Task<Positions> Add(Positions model)
        {
            try
            {
                await context.Positions.AddAsync(model);
                await context.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {
                return model;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var result = context.Positions.Find(id);
                if (result == null)
                {
                    return false;
                }
                context.Positions.Remove(result);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Positions? FindById(int id)
        {
            return context.Positions.Find(id);
        }

        public IEnumerable<Positions> GetAll()
        {
            return context.Positions.ToList();
        }

        public bool Update(Positions model)
        {
            try
            {
                context.Positions.Update(model);
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

