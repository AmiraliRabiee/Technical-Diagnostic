using App.Domain.Core.Entities.Base;
using App.Domain.Core.Entities;


namespace App.Domain.Core.Contracts.Service
{
    public interface IVehicleModelService
    {
        Task<VehicleModel> GetById(int id);
        Task<List<VehicleModel>> GetAll();
        Task<bool> Create(VehicleModel vehicleModel);
        Task<bool> Update(VehicleModel vehicleModel);
        Task<bool> Delete(int id);
    }
}
