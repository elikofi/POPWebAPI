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

        readonly Status status = new();

        //Add method
        public async Task<Status> AddAsync(Positions model)
        {

            try
            {
                await context.Positions.AddAsync(model);
                if (context.ServiceTypes.Any(x => x.ServiceType == model.Position))
                {
                    status.StatusCode = 0;
                    status.Message = "Position already exists.";
                    return status;
                }
                await context.SaveChangesAsync();
                status.StatusCode = 1;
                status.Message = "Added new Position.";
                return status;
            }
            catch (Exception)
            {
                status.StatusCode = 0;
                status.Message = "Error occured! Couldn't add the Position.";
                return status;
            }
        }

        //Update method
        public async Task<Status> UpdateAsync(Positions model)
        {
            try
            {
                context.Positions.Update(model);
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
                var data = await context.Positions.FindAsync(id);
                if (data == null)
                {
                    status.StatusCode = 0;
                    status.Message = "Position not found.";
                    return status;
                }
                context.Positions.Remove(data);
                await context.SaveChangesAsync();
                status.StatusCode = 1;
                status.Message = "Position deleted successfully.";
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
        public Positions? FindById(Guid id)
        {
            return context.Positions.Find(id);
        }

        //Get all
        public IEnumerable<Positions> GetAll()
        {
            return context.Positions.ToList();
        }

    }
}

