using RentACar_ModelsLayer.Entities.Concreate;

namespace RentACar_UI.Models
{
    public class VehicleIndexModel
    {
        public List<Vehicle> Vehicles { get; set; }
        public List<City> Cities { get; set; }
        public List<VehicleFilterModel> Filter { get; set; }
    }
}
