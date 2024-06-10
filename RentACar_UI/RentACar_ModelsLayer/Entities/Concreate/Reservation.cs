using RentACar_ModelsLayer.Entities.Concreate;

public class Reservation
{
    public int ReservationID { get; set; }
    public string? CityName { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerLastName { get; set; }
    public string? CustomerEmail { get; set; } 
    public string? ReservationDay { get; set; } 
    public string? ReservationPrice { get; set; } 
    public string? CustomerPhoneNumber { get; set; } 
    public string? VehicleBrand { get; set; }
    public string? VehicleModel { get; set; }
    public string? District { get; set; }
    public DateTime? ReservationStart { get; set; }
    public DateTime? ReservationFinish { get; set; }
    public bool ReservationOn { get; set; }
    public int VehicleID { get; set; }
    public Vehicle Vehicle { get; set; }
}
