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

        readonly Status status = new();
        public async Task<Status> AddAsync(Occupations model)
        {

            try
            {
                await context.Occupations.AddAsync(model);
                if (context.ServiceTypes.Any(x => x.ServiceType == model.Occupation))
                {
                    status.StatusCode = 0;
                    status.Message = "Occupation already exists.";
                    return status;
                }
                await context.SaveChangesAsync();
                status.StatusCode = 1;
                status.Message = "Added new Occupation.";
                return status;
            }
            catch (Exception)
            {
                status.StatusCode = 0;
                status.Message = "Error occured! Couldn't add the service type.";
                return status;
            }
        }
        public async Task<Status> UpdateAsync(Occupations model)
        {
            //var status = new Status();
            try
            {
                context.Occupations.Update(model);
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
                var data = await context.Occupations.FindAsync(id);
                if (data == null)
                {
                    status.StatusCode = 0;
                    status.Message = "Occupation not found.";
                    return status;
                }
                context.Occupations.Remove(data);
                await context.SaveChangesAsync();
                status.StatusCode = 1;
                status.Message = "Occupation deleted successfully.";
                return status;
            }
            catch (Exception)
            {
                status.StatusCode = 0;
                status.Message = "Error occured.";
                return status;
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
    }
}

