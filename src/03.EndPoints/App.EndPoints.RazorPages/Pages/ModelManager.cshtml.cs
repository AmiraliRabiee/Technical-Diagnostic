using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.RazorPages.Pages
{
    public class ModelManagerModel(IVehicleModelAppService vehicleModelApp) : PageModel
    {
        public List<VehicleModel> VehicleModels { get; set; }
        public string ResultMessage { get; set; }
        public bool IsSuccess { get; set; }
        public async void OnGet()
        {
            VehicleModels = await vehicleModelApp.GetAllVehicleModels();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var result = await  vehicleModelApp.DeleteVehicleModel(id);

            ResultMessage = result.Message;
            IsSuccess = result.IsSuccess;

            VehicleModels = await vehicleModelApp.GetAllVehicleModels();
            return Page();
        }
    }
}



