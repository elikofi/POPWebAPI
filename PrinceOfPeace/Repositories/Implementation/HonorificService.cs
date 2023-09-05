using System;
using PrinceOfPeace.Models.Domain;
using PrinceOfPeace.Models.DTO;
using PrinceOfPeace.Repositories.Abstract;

namespace PrinceOfPeace.Repositories.Implementation
{
    public class HonorificService : IHonorificService
    {
        private readonly DatabaseContext context;

        public HonorificService(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<Honorifics> Add(Honorifics model)
        {
            try
            {
                await context.Honorifics.AddAsync(model);
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
                var result = context.Honorifics.Find(id);
                if (result == null)
                {
                    return false;
                }
                context.Honorifics.Remove(result);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Honorifics? FindById(Guid id)
        {
            return context.Honorifics.Find(id);
        }

        public IEnumerable<Honorifics> GetAll()
        {
            return context.Honorifics.ToList();
        }

        public bool Update(Honorifics model)
        {
            try
            {
                context.Honorifics.Update(model);
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

