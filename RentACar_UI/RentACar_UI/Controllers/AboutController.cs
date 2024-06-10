using Microsoft.AspNetCore.Mvc;

namespace RentACar_UI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
