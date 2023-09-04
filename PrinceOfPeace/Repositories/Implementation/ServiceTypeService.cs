using System;
using PrinceOfPeace.Models.Domain;
using PrinceOfPeace.Models.DTO;
using PrinceOfPeace.Repositories.Abstract;

namespace PrinceOfPeace.Repositories.Implementation
{
	public class ServiceTypeService : IServiceTypeService
	{
        private readonly DatabaseContext context;

        public ServiceTypeService(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<ServiceTypes> Add(ServiceTypes model)
        {
            try
            {
                await context.ServiceTypes.AddAsync(model);
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
                var data = this.FindById(id);
                if (data == null)
                {
                    return false;
                }
                context.ServiceTypes.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ServiceTypes? FindById(Guid id)
        {
            return context.ServiceTypes.Find(id);
        }

        public IEnumerable<ServiceTypes> GetAll()
        {
            return context.ServiceTypes.ToList();
        }

        public bool Update(ServiceTypes model)
        {
            try
            {
                context.ServiceTypes.Update(model);
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

