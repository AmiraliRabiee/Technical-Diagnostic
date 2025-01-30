using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Endpoints.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudVehicleModelsController : ControllerBase
    {
        #region Inject
        private readonly IVehicleModelAppService _vehicleModelAppService;
        private readonly string _apiKey;
        private readonly string Model;

        public CrudVehicleModelsController(IVehicleModelAppService vehicleModelAppService, IConfiguration configuration)
        {
            _vehicleModelAppService = vehicleModelAppService;
            _apiKey = configuration["ApiSettings:ApiKey"];
        }
        #endregion

        [HttpPost("Add-VehicleModel")]
        public string AddVehicleModel([FromHeader] string apiKey, [FromBody] VehicleModel model)
        {
            if (apiKey != _apiKey)
            {
                return "Invalid API Key.";
            }

            var result = _vehicleModelAppService.CreateVehicleModel(model);
            return result.Message;
        }


        [HttpDelete("Delete-VehicleModel/{id}")]
        public string DeleteModel([FromHeader] string apiKey, int id)
        {
            if (apiKey != _apiKey)
            {
                return "Invalid API Key.";
            }

            var result = _vehicleModelAppService.DeleteVehicleModel(id);
            return result.Message;
        }

        [HttpGet("Get-DetailsOfModels")]
        public List<VehicleModel> ShowModels([FromHeader] string apiKey)
        {
            return _vehicleModelAppService.GetAllVehicleModels() ?? new List<VehicleModel>();
        }

        [HttpPut("Update-DetailsOfModel")]
        public string UpdateModel([FromHeader] string apiKey, int id, [FromBody] VehicleModel model)
        {
            if (apiKey != _apiKey)
            {
                return "Invalid API Key.";
            }

            var vehicle = _vehicleModelAppService.GetVehicleModel(id);
            if (vehicle == null)
            {
                return "Vehicle model not found.";
            }

            model.Id = id;
            var result = _vehicleModelAppService.UpdateVehicleModel(model);

            return result.Message;
        }

    }
}
