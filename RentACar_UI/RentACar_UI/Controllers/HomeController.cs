using Microsoft.AspNetCore.Mvc;
using RentACar_UI.Models;
using RentACar_BusinessLayer.Concreate;
using System.Linq;
using RentACar_ModelsLayer.Entities.Concreate;

namespace RentACar_UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly VehicleBS _vehicleBS;

        public HomeController()
        {
            _vehicleBS = new VehicleBS();
        }

        public IActionResult Index()
        {
            var citBs = new CityBS();
            var vehicles = _vehicleBS.GetAll()
                .Where(v => v.VehiclePrice < 1500)
                .OrderBy(v => v.VehiclePrice);

            var model = new VehicleIndexModel
            {
                Vehicles = vehicles.ToList(),
                Cities = citBs.GetAllCities()
            };

            return View(model);
        }
    }
}
