namespace RentACar_UI.Areas.AdminPanel.Models
{
    public class VehicleUpdateDto
    {
        public int VehicleID { get; set; }
        public string VehiclePhoto { get; set; }
        public string VehicleBrand { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleColor { get; set; }
        public string VehicleFuel { get; set; }
        public string VehicleFuelAmount { get; set; }
        public int VehiclePrice { get; set; }
        public string CityName { get; set; }
        public string District { get; set; }
    }
}
