using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.EFCore.Repositories
{
    public class VehicleModelRepository(AppDbContext context) : IVehicleModelRepository
    {
        public async Task<bool> Create(VehicleModel vehicleModel)
        {
            await context.Models.AddAsync(vehicleModel);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var model = await context.Models.FirstOrDefaultAsync(x => x.Id == id);
            if (model == null) return false;

            context.Models.Remove(model);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<List<VehicleModel>> GetAll()
        {
            return await context.Models.ToListAsync();
        }

        public async Task<VehicleModel?> GetById(int id)
        {
            return await context.Models.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Update(VehicleModel vehicleModel)
        {
            var existingModel = await context.Models.FirstOrDefaultAsync(x => x.Id == vehicleModel.Id);
            if (existingModel == null) return false;

            existingModel.Name = vehicleModel.Name;

            return await context.SaveChangesAsync() > 0;
        }
    }
}
