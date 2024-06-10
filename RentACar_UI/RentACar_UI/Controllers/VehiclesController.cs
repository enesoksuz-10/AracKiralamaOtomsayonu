
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar_BusinessLayer.Concreate;
using RentACar_DataAccessLayer.Repository;
using RentACar_ModelsLayer.Entities.Concreate;
using RentACar_UI.Models;

namespace RentACar_UI.Controllers
{
    public class VehiclesController : Controller
    {
        [HttpGet]
        public IActionResult Index(string city, string district)
        {
            var vehicleBS = new VehicleBS();
            var vehicles = vehicleBS.GetAll();

            if (!string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(district))
            {
                vehicles = vehicles.Where(v => v.CityName.ToLower() == city.ToLower() && v.District.ToLower() == district.ToLower()).ToList();
            }

            var model = new VehicleIndexModel
            {
                Vehicles = vehicles
            };

            if (!vehicles.Any())
            {
                ViewBag.Message = "Bu il-ilçede araç bulunmamaktadır.";
            }

            return View(model);
        }
        [HttpPost]
        public IActionResult Filter(VehicleFilterDto filter)
        {
            var vehicleBS = new VehicleBS();
            var vehicles = vehicleBS.GetFilteredVehicles(filter);
            var model = new VehicleIndexModel
            {
                Vehicles = vehicles
            };
            return View("Index", model);
        }

        public IActionResult Details(int id)
        {
            var vehicleBS = new VehicleBS();
            var vehicle = vehicleBS.GetById(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            var model = new VehicleDetailsModel
            {
                VehiclePhoto = vehicle.VehiclePhoto,
                VehicleBrand = vehicle.VehicleBrand,
                VehicleModel = vehicle.VehicleModel,
                VehicleColor = vehicle.VehicleColor,
                VehicleFuel = vehicle.VehicleFuel,
                VehicleFuelAmount = vehicle.VehicleFuelAmount,
                VehiclePrice = vehicle.VehiclePrice,
                CityName = vehicle.CityName,
                District = vehicle.District
            };
            return View(model);
        }
        [HttpGet]
        public JsonResult CheckActiveUser()
        {
            var jsonStr = HttpContext.Session.GetString("ActiveUser");
            if (string.IsNullOrEmpty(jsonStr))
            {
                return Json(new { isLoggedIn = false });
            }

            var activeUser = JsonConvert.DeserializeObject<Customer>(jsonStr);
            return Json(new { isLoggedIn = true, user = activeUser });
        }

        [HttpPost]
        public IActionResult AddReservation([FromBody] Reservation reservation)
        {
            if (reservation == null)
            {
                return BadRequest("Geçersiz rezervasyon verisi.");
            }

            var reservationBS = new ReservationBS();
            if (!reservationBS.IsVehicleAvailable(reservation.VehicleID, reservation.ReservationStart.Value, reservation.ReservationFinish.Value))
            {
                return BadRequest("Şu anda bu aracı kiralayamazsınız. Araç zaten rezerve.");
            }

            reservationBS.AddReservation(reservation);
            return Ok("Rezervasyon başarılı.");
        }



    }
}
