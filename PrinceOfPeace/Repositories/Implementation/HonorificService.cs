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

        readonly Status status = new();

        //Add 
        public async Task<Status> AddAsync(Honorifics model)
        {

            try
            {
                await context.Honorifics.AddAsync(model);
                if (context.ServiceTypes.Any(x => x.ServiceType == model.HonorificName))
                {
                    status.StatusCode = 0;
                    status.Message = "Honorific already exists.";
                    return status;
                }
                await context.SaveChangesAsync();
                status.StatusCode = 1;
                status.Message = "Added new Honorific.";
                return status;
            }
            catch (Exception)
            {
                status.StatusCode = 0;
                status.Message = "Error occured! Couldn't add Honorific.";
                return status;
            }
        }

        //Update
        public async Task<Status> UpdateAsync(Honorifics model)
        {
            try
            {
                context.Honorifics.Update(model);
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

        //Delete
        public async Task<Status> DeleteAsync(Guid id)
        {
            try
            {
                var data = await context.Honorifics.FindAsync(id);
                if (data == null)
                {
                    status.StatusCode = 0;
                    status.Message = "Honorific not found.";
                    return status;
                }
                context.Honorifics.Remove(data);
                await context.SaveChangesAsync();
                status.StatusCode = 1;
                status.Message = "Honorific deleted successfully.";
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
        public Honorifics? FindById(Guid id)
        {
            return context.Honorifics.Find(id);
        }

        //Get all
        public IEnumerable<Honorifics> GetAll()
        {
            return context.Honorifics.ToList();
        }
    }
}

