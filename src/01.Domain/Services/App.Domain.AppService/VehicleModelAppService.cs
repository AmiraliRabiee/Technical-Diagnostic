using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Domain.AppService
{
    public class VehicleModelAppService(IVehicleModelService modelService) : IVehicleModelAppService
    {
        public async Task<Result> CreateVehicleModel(VehicleModel vehicleModel)
        {
            var result = await modelService.Create(vehicleModel);
            if (result)
            {
                return new Result { IsSuccess = true, Message = "با موفقیت ثبت شد" };
            }
            return new Result { IsSuccess = false, Message = "عملیات با خطا مواجه شد" };
        }

        public async Task<Result> DeleteVehicleModel(int id)
        {
            var model = await modelService.GetById(id);
            if (model is null)
                return new Result { IsSuccess = false, Message = "مدلی با این شناسه پیدا نشد" };

            var result = await modelService.Delete(id);
            if (result)
            {
                return new Result { IsSuccess = true, Message = "با موفقیت حذف شد" };
            }
            return new Result { IsSuccess = false, Message = "عملیات با خطا مواجه شد" };
        }

        public async Task<List<VehicleModel>> GetAllVehicleModels()
        {
            return await modelService.GetAll();
        }

        public async Task<VehicleModel> GetVehicleModel(int id)
        {
            return await modelService.GetById(id);
        }

        public async Task<Result> UpdateVehicleModel(VehicleModel vehicleModel)
        {
            var existingModel = await modelService.GetById(vehicleModel.Id);
            if (existingModel is null)
                return new Result { IsSuccess = false, Message = "مدلی با این شناسه پیدا نشد" };

            var result = await modelService.Update(vehicleModel);
            if (result)
            {
                return new Result { IsSuccess = true, Message = "با موفقیت بروزرسانی شد" };
            }
            return new Result { IsSuccess = false, Message = "عملیات با خطا مواجه شد" };
        }
    }
}
