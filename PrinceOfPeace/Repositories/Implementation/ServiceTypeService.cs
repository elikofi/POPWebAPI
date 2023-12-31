﻿using System;
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

        //Add method for the service type
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

        // Update method for the service type
        public async Task<Status> UpdateAsync(ServiceTypes model)
        {
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

        //Delete method
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

        //Find
        public ServiceTypes? Find(Guid id)
        {
            return context.ServiceTypes.Find(id);
        }

        //Get all
        public IEnumerable<ServiceTypes> GetAll()
        {
            return context.ServiceTypes.ToList();
        }


    }
}

