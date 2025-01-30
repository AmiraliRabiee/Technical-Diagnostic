using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities;

namespace App.Domain.Service
{
    public class VehicleModelService(IVehicleModelRepository modelRepository) : IVehicleModelService
    {
        public async Task<bool> Create(VehicleModel vehicleModel)
        {
            return await modelRepository.Create(vehicleModel);    
        }

        public async Task<bool> Delete(int id)
        {
            return await modelRepository.Delete(id);
        }

        public async Task<List<VehicleModel>> GetAll()
        {
            return await modelRepository.GetAll();
        }

        public async Task<VehicleModel> GetById(int id)
        {
            return await modelRepository.GetById(id);
        }

        public async Task<bool> Update(VehicleModel vehicleModel)
        {
            return await modelRepository.Update(vehicleModel);        
        }
    }
}
