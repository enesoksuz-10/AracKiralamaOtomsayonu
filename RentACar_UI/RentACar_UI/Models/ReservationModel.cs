namespace RentACar_UI.Models
{
    public class ReservationModel
    {
        public string CustomerName { get; set; }
        public string VehicleBrand { get; set; }
        public string VehicleModel { get; set; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationFinish { get; set; }
    }
}
