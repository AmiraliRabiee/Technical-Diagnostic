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
        public async Task<IActionResult> AddVehicleModel([FromQuery] string apiKey
            , [FromBody] Domain.Core.Entities.VehicleModel model)
        {
            if (apiKey != _apiKey)
            {
                return Unauthorized("Invalid API Key.");
            }

            if (model == null)
            {
                return BadRequest("Invalid model data.");
            }
            var result = await _vehicleModelAppService.CreateVehicleModel(model);

            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }


        [HttpDelete("Delete-VehicleModel/{id}")]
        public async Task<IActionResult> DeleteModel([FromQuery] string apiKey, int id)
        {
            if (apiKey != _apiKey)
            {
                return Unauthorized("Invalid API Key.");
            }
            var result = await _vehicleModelAppService.DeleteVehicleModel(id);

            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message); 
        }


        [HttpGet("Get-DetailsOfModels")]
        public async Task<List<VehicleModel>> ShowModelsAsync([FromHeader] string apiKey)
        {
            return await _vehicleModelAppService.GetAllVehicleModels() ?? new List<VehicleModel>();
        }


        [HttpPost("Update-DetailsOfModel")]
        public async Task<ActionResult<string>> UpdateModel([FromQuery] string apiKey, [FromBody] VehicleModel model)
        {
            if (apiKey != _apiKey)
            {
                return Unauthorized("Invalid API Key.");
            }

            if (model == null)
            {
                return BadRequest("Invalid model data.");
            }

            var result = await _vehicleModelAppService.UpdateVehicleModel(model);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
