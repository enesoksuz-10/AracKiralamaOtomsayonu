namespace RentACar_UI.Areas.AdminPanel.Models
{
    public class CustomerUpdateDto
    {
        public int CustomerID { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerLastName { get; set; }
        public string? CustomerPhoneNumber { get; set; }
        public string? CustomerEmail { get; set; }
    }
}
