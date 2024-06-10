using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar_BusinessLayer.Concreate;
using RentACar_ModelsLayer.Entities.Concreate;
using RentACar_UI.ActionFilters;
using RentACar_UI.Areas.AdminPanel.ActionFilters;

namespace RentACar_UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [AdminCheckLoginSession]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var adminBS = new AdminBS();
            var adminCount = adminBS.GetAll().Count;
            var customerBS = new CustomerBS();
            var customerCount = customerBS.GetAll().Count;

            ViewBag.AdminCount = adminCount;
            ViewBag.CustomerCount = customerCount;

            var jsonStr = HttpContext.Session.GetString("ActiveAdminUser");
            var admn = JsonConvert.DeserializeObject<Admin>(jsonStr);
            return View(admn);
        }
    }
}
