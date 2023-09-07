using System;
using Microsoft.EntityFrameworkCore;
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
        readonly Status status = new();
        public async Task<Status> AddAsync(ServiceTypes model)
        {
            
            try
            {
                await context.ServiceTypes.AddAsync(model);
                if (context.ServiceTypes.Any(x => x.ServiceType == model.ServiceType))
                {
                    status.StatusCode = 0;
                    status.Message = "Service type already exists.";
                    return status;
                }
                await context.SaveChangesAsync();
                status.StatusCode = 1;
                status.Message = "Added new Service type.";
                return status;
            }
            catch (Exception)
            {
                status.StatusCode = 0;
                status.Message = "Error occured! Couldn't add the service type.";
                return status;
            }
        }
        public async Task<Status> UpdateAsync(ServiceTypes model)
        {
            //var status = new Status();
            try
            {
                context.ServiceTypes.Update(model);
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
                var data = await context.ServiceTypes.FindAsync(id);
                if (data == null)
                {
                    status.StatusCode = 0;
                    status.Message = "Service type not found.";
                    return status;
                }
                context.ServiceTypes.Remove(data);
                await context.SaveChangesAsync();
                status.StatusCode = 1;
                status.Message = "Service type deleted successfully.";
                return status;
            }
            catch (Exception)
            {
                status.StatusCode = 0;
                status.Message = "Error occured.";
                return status;
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


    }
}

