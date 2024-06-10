using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar_BusinessLayer.Concreate;
using RentACar_ModelsLayer.Entities.Concreate;
using RentACar_UI.Models;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace RentACar_UI.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly CustomerBS _customerBS;

        public AuthenticationController()
        {
            _customerBS = new CustomerBS();
        }

        public IActionResult LogIn()
        {
            if (HttpContext.Session.GetString("ActiveUser") != null)
            {
                TempData["AlreadyLoggedIn"] = true;
            }
            return View();
        }

        [HttpPost]
        public JsonResult LogIn(LogInDto dto)
        {
            var cust = _customerBS.LogIn(dto.UserName, dto.Password);
            if (cust != null)
            {
                var jsonStr = JsonConvert.SerializeObject(cust);
                HttpContext.Session.SetString("ActiveUser", jsonStr);
                return Json(new { Result = true });
            }
            else
            {
                return Json(new { Result = false, Message = "Hatalı Giriş Yapıldı." });
            }
        }

        [HttpPost]
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("ActiveUser");
            return RedirectToAction("LogIn");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddCustomer(CustomerAddDto dto)
        {
            if (dto.CustomerUserName == "" || dto.CustomerPassword == "")
            {
                return Json(new { Result = false, Message = "Kullanıcı Adı ve Şifre Kısımı Boş Geçilemez." });
            }

            // Kullanıcı adının varlığını kontrol et
            if (_customerBS.CheckUsernameExistence(dto.CustomerUserName))
            {
                return Json(new { Result = false, Message = "Bu kullanıcı adı zaten kullanılıyor. Lütfen farklı bir kullanıcı adı seçin." });
            }

            var customer = new Customer();
            customer.CustomerName = dto.CustomerName;
            customer.CustomerLastName = dto.CustomerLastName;
            customer.CustomerPhoneNumber = dto.CustomerPhoneNumber;
            customer.CustomerEmail = dto.CustomerEmail;
            customer.CustomerUserName = dto.CustomerUserName;
            customer.CustomerPassword = dto.CustomerPassword;

            var insertedCustomer = _customerBS.AddCustomer(customer);
            if (insertedCustomer != null)
            {
                return Json(new { Result = true, BasariliMi = true, Message = "Kayıt İşlemi Başarılı. Giriş Ekranına Yönlendiriliyorsunuz!" });
            }
            else
            {
                return Json(new { Result = false, BasariliMi = false, Message = "Kayıt Esnasında Bir Sorun Oluştu." });
            }
        }
    }
}
