using Microsoft.AspNetCore.Mvc;
using RentACar_BusinessLayer.Concreate;
using RentACar_ModelsLayer.Entities.Concreate;
using RentACar_UI.Areas.AdminPanel.ActionFilters;
using RentACar_UI.Areas.AdminPanel.Models;
using RentACar_UI.Models;
using RentACar_UI.ViewComponents;

namespace RentACar_UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [AdminCheckLoginSession]
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            var vehBS = new VehicleBS();
            var citBs = new CityBS();
            var model = new VehicleIndexViewModel();

            model.Vehicles = vehBS.GetAll();
            model.Cities = citBs.GetAllCities();
            return View(model);
        }

        [HttpPost]
        public JsonResult AddVehicle(IFormFile selectedFile, VehicleAddDto dto)
        {
            var randomFiles = "";
            if (selectedFile != null)
            {
                if (selectedFile.ContentType.StartsWith("image/"))
                {
                    if (!(selectedFile.Length > 1024 * 1024))
                    {
                        randomFiles = Guid.NewGuid() + Path.GetExtension(selectedFile.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\VehicleImages\", randomFiles);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            selectedFile.CopyTo(stream);
                        }
                    }
                }
            }

            var vehicle = new Vehicle();

            vehicle.VehicleBrand = dto.VehicleBrand;
            vehicle.VehicleModel = dto.VehicleModel;
            vehicle.VehicleColor = dto.VehicleColor;
            vehicle.VehicleFuel = dto.VehicleFuel;
            vehicle.VehiclePrice = dto.VehiclePrice;
            vehicle.VehicleFuelAmount = dto.VehicleFuelAmount;
            vehicle.CityName = dto.CityName;
            vehicle.District = dto.District;
            vehicle.VehiclePhoto = "\\VehicleImages\\" + randomFiles;

            var vehicleBS = new VehicleBS();
            var insertedVehicle = vehicleBS.AddVehicle(vehicle);

            if (insertedVehicle != null)
            {
                return Json(new { Result = true, BasariliMi = true, Message = "Araç Başarılı bir şekilde Kayıt Edildi." });
            }
            else
            {
                return Json(new { Result = false, BasariliMi = false, Message = "Kayıt Esnasında bir sorun oldu." });
            }
        }

        [HttpPost]
        public JsonResult EditVehicle(IFormFile selectedFile, VehicleUpdateDto dto)
        {
            var randomFiles = "";
            if (selectedFile != null)
            {
                if (selectedFile.ContentType.StartsWith("image/"))
                {
                    if (!(selectedFile.Length > 1024 * 1024))
                    {
                        randomFiles = Guid.NewGuid() + Path.GetExtension(selectedFile.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\VehicleImages\", randomFiles);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            selectedFile.CopyTo(stream);
                        }
                    }
                }
            }
            var vehicleBs = new VehicleBS();
            var vehicleOrjinal = vehicleBs.GetById(dto.VehicleID);
            vehicleOrjinal.VehicleBrand = dto.VehicleBrand;
            vehicleOrjinal.VehicleModel = dto.VehicleModel;
            vehicleOrjinal.VehicleColor = dto.VehicleColor;
            vehicleOrjinal.VehicleFuel = dto.VehicleFuel;
            vehicleOrjinal.VehiclePrice = dto.VehiclePrice;
            vehicleOrjinal.VehicleFuelAmount = dto.VehicleFuelAmount;
            vehicleOrjinal.CityName = dto.CityName;
            vehicleOrjinal.District = dto.District;
            vehicleOrjinal.VehiclePhoto = "\\VehicleImages\\" + randomFiles;


            var updateVehicle = vehicleBs.Update(vehicleOrjinal);
            if (updateVehicle != null)
            {
                return Json(new { Result = true, Message = "Ürün Başarılı bir şekilde güncellendi." });
            }
            else
            {
                return Json(new { Result = false, Message = "Ürün Güncellenemedi." });
            }
        }

        [HttpPost]
        public JsonResult DeleteVehicle(int id)
        {
            if (id <= 0)
            {
                return Json(new { Result = false, Message = "Silme İşlemi esneasında bir sorun ile karşılaşıldı." });
            }
            var vehicleBs = new VehicleBS();
            vehicleBs.Delete(id);
            return Json(new { Result = true, Message = "Ürün Silindi." });
        }

        public JsonResult GetVehicleById(int id)
        {
            if (id <= 0)
            {
                return Json(new { Result = false, Message = "Silme İşlemi esneasında bir sorun ile karşılaşıldı." });
            }
            var vehicleBs = new VehicleBS();
            var vehicle = vehicleBs.GetById(id);
            return Json(new { Result = true, Message = "Ürün Silindi.", Vehicle = vehicle });
        }
    }
}
