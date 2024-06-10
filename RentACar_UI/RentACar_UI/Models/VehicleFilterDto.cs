namespace RentACar_UI.Models
{
    public class VehicleFilterModel
    {
        public List<string> VehicleBrands { get; set; }
        public List<string> VehicleFuels { get; set; }
        public List<string> VehicleColors { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
    }
}
