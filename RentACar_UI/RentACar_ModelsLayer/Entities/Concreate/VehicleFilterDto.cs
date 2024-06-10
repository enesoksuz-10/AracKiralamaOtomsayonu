namespace RentACar_DataAccessLayer.Repository
{
    public class VehicleFilterDto
    {
        public int VehicleID { get; set; }
        public string VehicleBrand { get; set; }
        public string CityName { get; set; }
        public string District { get; set; }
        public string VehicleColor { get; set; }
        public string VehicleFuel { get; set; }
        public int VehiclePrice { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
    }
}