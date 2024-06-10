using Microsoft.AspNetCore.Mvc;
using RentACar_BusinessLayer.Concreate;
using RentACar_UI.Areas.AdminPanel.ActionFilters;
using RentACar_UI.Areas.AdminPanel.Models;

namespace RentACar_UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [AdminCheckLoginSession]
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            var custBS = new CustomerBS();
            var model = new CustomerIndexViewModel
            {
                ListCustomers = custBS.GetAll()
            };

            return View(model);
        }

        [HttpPost]
        public JsonResult DeleteCustomer(int id)
        {
            if (id <= 0)
            {
                return Json(new { Result = false, Message = "Silme İşlemi esnasında bir sorun ile karşılaşıldı." });
            }

            var customerBS = new CustomerBS();
            customerBS.Delete(id);

            return Json(new { Result = true, Message = "Üye Başarılı Bir Şekilde Silindi." });
        }

        public JsonResult GetCustomerById(int id)
        {
            if (id <= 0)
            {
                return Json(new { Result = false, Message = "Müşteri bulunamadı." });
            }

            var customerBS = new CustomerBS();
            var customer = customerBS.GetById(id);

            return Json(new { Result = true, Message = "Müşteri bulundu.", Customer = customer });
        }

        public JsonResult EditCustomer(CustomerUpdateDto dto)
        {

            var customerBs = new CustomerBS();


            var customerOrjinal = customerBs.GetById(dto.CustomerID);
            customerOrjinal.CustomerName = dto.CustomerName;
            customerOrjinal.CustomerLastName = dto.CustomerLastName;
            customerOrjinal.CustomerPhoneNumber = dto.CustomerPhoneNumber;
            customerOrjinal.CustomerEmail = dto.CustomerEmail;

            var updateCustomer = customerBs.Update(customerOrjinal);
            if (updateCustomer != null)
            {
                return Json(new { Result = true, Message = "Kullanıcı Başarılı bir şekilde güncellendi." });
            }
            else
            {
                return Json(new { Result = false, Message = "Kullanıcı Güncellenemedi." });
            }

        }
    }
}
