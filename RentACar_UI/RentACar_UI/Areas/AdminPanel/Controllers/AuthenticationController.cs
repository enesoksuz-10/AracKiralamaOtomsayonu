using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar_BusinessLayer.Concreate;
using RentACar_UI.ActionFilters;
using RentACar_UI.Models;

namespace RentACar_UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class AuthenticationController : Controller
    {
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LogIn(LogInDto dto)
        {

            var admnBS = new AdminBS();
            var admn = admnBS.LogIn(dto.UserName, dto.Password);
            if (admn != null)
            {
                var jsonStr = JsonConvert.SerializeObject(admn);
                HttpContext.Session.SetString("ActiveAdminUser", jsonStr);
                return Json(new { Result = true });
            }
            else
            {
                return Json(new { Result = false, Message = "Kullanıcı Adı veya Şifre Hatalı." });
            }


        }
    }
}
