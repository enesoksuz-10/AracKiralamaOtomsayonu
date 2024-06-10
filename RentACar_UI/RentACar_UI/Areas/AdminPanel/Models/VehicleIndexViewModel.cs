using RentACar_ModelsLayer.Entities.Concreate;

namespace RentACar_UI.Areas.AdminPanel.Models
{
    public class VehicleIndexViewModel
    {
        public List<Vehicle> Vehicles { get; set; }
        public List<City> Cities { get; set; }
    }
}
