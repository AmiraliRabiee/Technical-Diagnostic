using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppService
{
    public interface IVehicleModelAppService
    {
        //cw crud
        Task<VehicleModel> GetVehicleModel(int id);
        Task<List<VehicleModel>> GetAllVehicleModels();   
        Task<Result> CreateVehicleModel(VehicleModel vehicleModel);
        Task<Result> UpdateVehicleModel(VehicleModel vehicleModel);
        Task<Result> DeleteVehicleModel(int id);

    }
}
