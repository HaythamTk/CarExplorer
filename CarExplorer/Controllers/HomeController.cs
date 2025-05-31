using System.Diagnostics;
using CarExplorer.IServices;
using CarExplorer.Models;
using CarExplorer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarExplorer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarService _carService;

        public HomeController(ILogger<HomeController> logger, ICarService carService)
        {
            _logger = logger;
            _carService = carService;
        }


        public async Task<IActionResult> Index()
        {
            var makes = await _carService.GetAll();

            var viewModel = new CarViewModel
            {
                Makes = makes.Select(x => new SelectListItem
                {
                    Value = x.MakeId.ToString(),
                    Text = x.MakeName
                }).ToList()
            };

            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> GetVehicleTypes(int makeId)
        {
            var vehicleTypes = await _carService.GetVehicleTypesByMakeId(makeId);

            var list = vehicleTypes.Select(x => new SelectListItem
            {
                Value = x.VehicleTypeName,
                Text = x.VehicleTypeName
            }).ToList();

            return Json(list);
        }

        
        [HttpGet]
        public async Task<IActionResult> GetModels(int makeId, int year, string vehicleType)
        {
            var models = await _carService.GetModels(makeId, year, vehicleType);
            var modelNames = models.Select(x => x.ModelName).ToList();

            return PartialView("_CarListPartial", modelNames);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
