using RentACar_ModelsLayer.Entities.Concreate;

namespace RentACar_UI.Areas.AdminPanel.Models
{
    public class ReservationIndexViewModel
    {
        public List<Reservation> Reservations { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public Customer Customer { get; set; }
        public Reservation Reservation { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
